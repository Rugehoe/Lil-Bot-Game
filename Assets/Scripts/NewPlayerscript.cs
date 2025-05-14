using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
public class NewPlayerscript : MonoBehaviour
{

    [SerializeField]
    private Tilemap groundTileMap;

    [SerializeField]
    private Tilemap collisionTileMap;

    [SerializeField]
    private Tilemap WoodMap;

    [SerializeField]
    private Tile woodTile;

    [SerializeField]
    GameObject loreTab;

    [SerializeField]
    private bool woodFront = false;
    private bool signFront = false;

    [SerializeField]
    private bool heldWood = false;

    

    public PlayerInput PI;


    InputAction movementAction;
        bool Maymove = true;

    private void Start()
    {
        movementAction = InputSystem.actions.FindAction("Move");     

    }
    void OnInteract()
    {
        if (woodFront) StartCoroutine(PicknDrop());

        if (signFront) Opensign();        

    }

    void Opensign()
    {
        loreTab.SetActive(true);
    }






    IEnumerator PicknDrop()
    {
        GameObject wood = GameObject.Find("Wood");
        if (wood != null && !heldWood)
        {
            wood.transform.parent = this.transform;
            heldWood = true;
            Debug.Log("PickUp");
            SetNRemoveTiles(false);
        }
        else if (heldWood)
        {
            wood.transform.parent = null;
            heldWood = false;
            Debug.Log("LayDown");
            SetNRemoveTiles(true);
        }
        yield return null;
    }

    public void SetNRemoveTiles(bool set)
    {
        if (set)
        {
            WoodMap.SetTile(WoodMap.WorldToCell(GameObject.Find("Wood Point1").transform.position), woodTile);
            WoodMap.SetTile(WoodMap.WorldToCell(GameObject.Find("Wood Point2").transform.position), woodTile);
            WoodMap.SetTile(WoodMap.WorldToCell(GameObject.Find("Wood Point3").transform.position), woodTile);
        }
        else 
        {
            WoodMap.SetTile(WoodMap.WorldToCell(GameObject.Find("Wood Point1").transform.position), null);
            WoodMap.SetTile(WoodMap.WorldToCell(GameObject.Find("Wood Point2").transform.position), null);
            WoodMap.SetTile(WoodMap.WorldToCell(GameObject.Find("Wood Point3").transform.position), null);
        }
    }




    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wood"))
        {
            woodFront = true;
        }
        if (other.gameObject.CompareTag("Sign"))
        {
            signFront = true;
        }




    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Wood"))
        {
            woodFront = false;
        }
        if (other.gameObject.CompareTag("Sign"))
        {
            signFront = false;
        }
    }


    #region Movement
    private void FixedUpdate()
    {
        Move(movementAction.ReadValue<Vector2>());
    }

    public void Move(Vector2 direction)
    {
        if (CanMove(direction) && Maymove)
        {
            if (direction.normalized.x == 1)
                transform.rotation = Quaternion.Euler(0, 0, -90);
            else if (direction.normalized.x == -1)
                transform.rotation = Quaternion.Euler(0, 0, 90);
            else if (direction.normalized.y == 1)
                transform.rotation = Quaternion.Euler(0, 0, 0);
            else if (direction.normalized.y == -1)
                transform.rotation = Quaternion.Euler(0, 0, 180);

            transform.position += (Vector3)direction;
            Maymove = false;
            Invoke("resetmove", 0.2f);
        }
    }
    void resetmove()
    {
        Maymove = true;
    }

    public bool CanMove(Vector2 direction0)
    {
        Vector3Int gridPosition = groundTileMap.WorldToCell(transform.position + (Vector3)direction0);
        if (WoodMap.HasTile(gridPosition) && !collisionTileMap.HasTile(gridPosition))
        {
            return true;
        }
        if (!groundTileMap.HasTile(gridPosition) || collisionTileMap.HasTile(gridPosition))
        {
            return false;
        }
        if ((direction0.y < 1 && direction0.y > 0) || (direction0.y > -1 && direction0.y < 0))
        {
            return false;
        }
        

        return true;
    }
    #endregion


}
