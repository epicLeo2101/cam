using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlanState : MonoBehaviour
{
    [Header("Controls")]                                
    [SerializeField] private KeyCode playVideoKey = KeyCode.Space;

    public float animationDuration = 1f; //<<<<---- just so the player does't spam the Space button however it may not be there for long.

    private bool isCoolDown = false;
    private MeshRenderer objectApperance;
    private Animator m_Animator;

    CheckPoint checkPointReach;

    // Start is called before the first frame update
    void Start()
    {
        checkPointReach = GameObject.FindGameObjectWithTag("Sections").GetComponent<CheckPoint>();
        m_Animator = GetComponent<Animator>();
        objectApperance = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_Animator != null)
        {
            if(Input.GetKeyDown(playVideoKey) && !isCoolDown)
            {
                m_Animator.SetTrigger("Play");
                objectApperance.enabled = true;
                StartCoroutine(CoolDown());
            }
        }
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Death")
        {
            m_Animator.SetTrigger("Stop");
            objectApperance.enabled = false;
            Debug.Log("It works");
        }

        if (collider.gameObject.tag == "CheckPoint")
        {
            checkPointReach.CheckPointReach();
            Debug.Log("Check Point!");
        }
    }

    public void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Essential")
        {
            m_Animator.SetTrigger("Stop");
            objectApperance.enabled = false;
            Debug.Log("It works");
        }
    }

    private IEnumerator CoolDown()
    {
        isCoolDown = true;
        yield return new WaitForSeconds(animationDuration);
        isCoolDown = false;
    }
}
