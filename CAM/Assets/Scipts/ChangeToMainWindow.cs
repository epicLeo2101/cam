using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeToMainWindow : MonoBehaviour
{
    private bool canClick = false;

    public GameObject loreGameObject;

    public GameObject mainScreen;

    // Start is called before the first frame update
    void Start()
    {
        //screenChange = false;
        canClick = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && canClick == true)
        {
            loreGameObject.SetActive(false);
            mainScreen.SetActive(true);
            canClick = false;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Cursor")
        {
            Debug.Log("It Works!");
            canClick = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.name == "Cursor")
        {
            canClick = false;
            Debug.Log("It Left!");
        }
    }
}
