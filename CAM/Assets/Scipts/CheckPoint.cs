using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [Header("Camera Sections")]
    [SerializeField] private List<GameObject> _sections = new();

    private int currentSectionsIndex;

    // Start is called before the first frame update
    private void Awake()
    {
        FindSections();
        UpdateCurrentCamSection();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FindSections()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            _sections.Add(transform.GetChild(i).gameObject);
        }
    }

    private void UpdateCurrentCamSection()
    {
        foreach (GameObject cam in _sections)
        {
            cam.SetActive(false);
        }

        _sections[currentSectionsIndex].SetActive(true);
    }

    public void CheckPointReach()
    {
        currentSectionsIndex++;

        if (currentSectionsIndex >= _sections.Count)
        {
            currentSectionsIndex = 0;
        }

        UpdateCurrentCamSection();
    }
}
