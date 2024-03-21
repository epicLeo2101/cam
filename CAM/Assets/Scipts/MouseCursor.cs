using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseCursor : MonoBehaviour
{
    Camera laptopCam;

    private GameObject showPressQ;

    public PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        laptopCam = GameObject.Find("POVUsingLaptop").GetComponent<Camera>();
        showPressQ = GameObject.Find("Button Promnt: press Q");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = laptopCam.ScreenToWorldPoint(new Vector3((Input.mousePosition.x / Screen.width) * laptopCam.pixelWidth, (Input.mousePosition.y / Screen.height) * laptopCam.pixelHeight, 5)); // <<< ----- needs some teaking but it works!

        if (Input.GetKey(KeyCode.Q))
        {
            playerMovement.enabled = true;
            GetComponent<MouseCursor>().enabled = false;
            Cursor.lockState = CursorLockMode.Locked;
            showPressQ.SetActive(false);
        }
    }
}