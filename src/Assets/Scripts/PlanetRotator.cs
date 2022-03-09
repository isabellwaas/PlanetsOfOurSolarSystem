using UnityEngine;

public sealed class PlanetRotator : MonoBehaviour 
{
    [SerializeField] private float movementSpeed = 1f;
    private Vector3 clickStartPosition;
    private GameObject targetObject;

    //Identifying target object that was clicked and rotating the object when mouse button is released
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 mousePosition = Input.mousePosition;
            
            RaycastHit raycastHit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(mousePosition), out raycastHit))
            {
                targetObject = raycastHit.transform.gameObject;
                clickStartPosition = Camera.main.ScreenToViewportPoint(new Vector3(mousePosition.x, mousePosition.y, 0));
            }
            else targetObject = null;
        }
        else
        {
            if(Input.GetKey(KeyCode.Mouse0) && targetObject!=null)
            {
                RotatePlanet(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            }
        }
    }
    
    //Rotating target object depending on mouse position
    private void RotatePlanet(Vector3 currentMousePosition)
    {
        Vector3 newPosition = Camera.main.ScreenToViewportPoint(currentMousePosition);
        Vector3 direction = clickStartPosition - newPosition;
        clickStartPosition = newPosition;

        targetObject.transform.Rotate(new Vector3(0,1,0), direction.x * 180 * movementSpeed, Space.World);
        targetObject.transform.Rotate(Vector3.forward, direction.y * 180 * movementSpeed * -1, Space.World);
    }
}