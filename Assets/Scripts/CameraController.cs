using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private int OldMouseXPos;
    private int OldMouseYPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float movementSpeed = 16f;
        float dragMovementSpeed = 1.5f;
        float scrollSpeed = 380f;

        Vector3 newCameraPos = this.transform.position;

        if (Input.GetMouseButton(0))
        {
            float diffX, diffY;
            Vector3 diffVector = new Vector3();

            diffX = this.OldMouseXPos - Input.mousePosition.x;
            diffY = this.OldMouseYPos - Input.mousePosition.y;

            diffVector.Set(diffX, 0, diffY);

            diffVector = diffVector * dragMovementSpeed * Time.deltaTime;
            newCameraPos += diffVector;

        } else
        {
            
            

            if(Input.GetKey("w"))
            {
                newCameraPos.z += movementSpeed * Time.deltaTime;
            }

            if (Input.GetKey("s"))
            {
                newCameraPos.z -= movementSpeed * Time.deltaTime;
            }

            if (Input.GetKey("a"))
            {
                newCameraPos.x -= movementSpeed * Time.deltaTime;
            }

            if (Input.GetKey("d"))
            {
                newCameraPos.x += movementSpeed * Time.deltaTime;
            }

        }

        
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        
        newCameraPos.y -= scroll * Time.deltaTime * scrollSpeed;
        if (newCameraPos.y > 2.5) newCameraPos.z += scroll * Time.deltaTime * scrollSpeed;
        if (newCameraPos.y < 2.5) newCameraPos.y = 2.5f;
        

        this.transform.position = newCameraPos;

        this.OldMouseXPos = (int)Input.mousePosition.x;
        this.OldMouseYPos = (int)Input.mousePosition.y;


        RaycastHit hit;
        Camera camera = GetComponent<Camera>();
        Debug.Log(camera.name);
        Ray cameraRay = camera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));

        if (Physics.Raycast(cameraRay, out hit)) {

            Transform objectHit = hit.transform;

            Debug.Log("I hit " + objectHit.name);
        
        }       





    }
}
