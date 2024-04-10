using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelUnlocked : MonoBehaviour
{
    [Header("What Level is Unlocked")]
    [SerializeField] private bool FilmIcon2 = false;
    [SerializeField] private bool FilmIcon3 = false;
    [SerializeField] private bool FilmIcon4 = false;

    [Header("Disable this Script when PlayTesting")]
    [SerializeField] private string IgnoreThis;

    DontDestroy dontDestroy;

    // Start is called before the first frame update
    void Start()
    {
        dontDestroy = GameObject.FindGameObjectWithTag("Unlocks&Collectables").GetComponent<DontDestroy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Alan" && FilmIcon2 == true)
        {
            Debug.Log("Film Icon 2 is unlocked!");
            dontDestroy.UnlockedFilmIcon2();
        }
    }
}
