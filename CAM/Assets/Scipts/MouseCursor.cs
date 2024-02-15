using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    Camera laptopCam;
    public PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        laptopCam = GameObject.Find("POVUsingLaptop").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = laptopCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5)); //<<--Not perfect it needs Boundaries so the mouse doesn't get too far!

        if(Input.GetKey(KeyCode.Q))
        {
            playerMovement.enabled = true;
            GetComponent<MouseCursor>().enabled = false;
        }
    }
}
