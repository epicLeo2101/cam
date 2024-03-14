using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    Camera laptopCam;
    public PlayerMovement playerMovement;

    private Vector3 screenBounds;
    private float objectWidth;
    private float objectHeight;

    // Start is called before the first frame update
    void Start()
    {
        laptopCam = GameObject.Find("POVUsingLaptop").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //float mouseX = Input.GetAxis("Mouse X");
        //float mouseY = -Input.GetAxis("Mouse Y");
        //if (mouseX != 0 || mouseY != 0)
        //{
        //    rotY += mouseX * lookSpeed * Time.deltaTime;
        //    rotX += mouseY * lookSpeed * Time.deltaTime;


        //    rotX = Mathf.Clamp(rotX, -clampVerticalAngle, clampVerticalAngle);
        //    rotY = Mathf.Clamp(rotY, -clampHorizontalAngle, clampHorizontalAngle);

        //    //forces player body movement alongside the camera
        //    playerCamera.transform.localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        //    //transform.rotation = localRotation; //This may be usefull plus "Quaternion localRotation" may need to replace the start of line 112
        //}

        //screenBounds = laptopCam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 5));
        //transform.position = laptopCam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 5));
        //objectWidth = transform.GetComponent<MeshRenderer>().bounds.extents.x; //extents = size of width / 2
        //objectHeight = transform.GetComponent<MeshRenderer>().bounds.extents.y; //extents = size of height / 2
        //Vector3 viewPos = transform.position;
        //viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        //viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
        //transform.position = viewPos;


        /* transform.position = laptopCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5));*/ //<<--Not perfect it needs Boundaries so the mouse doesn't get too far!

        if (Input.GetKey(KeyCode.Q))
        {
            playerMovement.enabled = true;
            GetComponent<MouseCursor>().enabled = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}