using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour
{
    private bool readyForNextLevel = false;
    private float waitToLoad = 3f;

    public int levelNum;

    // Start is called before the first frame update
    void Start()
    {
        readyForNextLevel = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && readyForNextLevel == true)
        {
            SceneManager.LoadScene(levelNum);
            readyForNextLevel = false;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Cursor")
        {
            Debug.Log("It Works!");
            readyForNextLevel = true;
        }

        if (collider.gameObject.name == "Alan")
        {
            Debug.Log("Its going to load in 3s!");
            StartCoroutine(WaitToLoad());
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.name == "Cursor")
        {
            readyForNextLevel = false;
            Debug.Log("It Left!");
        }
    }

    private IEnumerator WaitToLoad()
    { 
        yield return new WaitForSeconds(waitToLoad);
        SceneManager.LoadScene(levelNum);
    }
}
