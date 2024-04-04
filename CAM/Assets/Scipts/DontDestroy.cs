using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public static DontDestroy Instance;

    public GameObject filmIcon2;

    public GameObject DocumentIcon1;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0;i < Object.FindObjectsOfType<DontDestroy>().Length; i++)
        {
            if (Object.FindObjectsOfType<DontDestroy>()[i] != this)
            {
                if (Object.FindObjectsOfType<DontDestroy>()[i].name == gameObject.name)
                {
                    Destroy(gameObject);
                }
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UnlockedFilmIcon2()
    {
        filmIcon2.SetActive(true);
    }

    public void UnlockedFilmIcon3()
    {
        //....etc...
    }


    public void UnlockedDocumentIcon1()
    {
        DocumentIcon1.SetActive(true);
    }
}
