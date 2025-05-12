using System.Collections;
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

    public PlayerInput PI;


    InputAction movementAction;
    InputAction doAction;
    bool Maymove = true;

    private void Start()
    {
        movementAction = InputSystem.actions.FindAction("Move");
        doAction = InputSystem.actions.FindAction("Interact");
      

    }
    void OnInteract()
    {
        Debug.Log("done");
    }

    private void FixedUpdate()
    {
        if (false)
        {
            Debug.Log("Done");
        }
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





    void PickUpWood()
    {
    
    }

    public bool CheckForWood()
    {
        return false;
    }


















   
}
