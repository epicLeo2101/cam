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

    // Start is called before the first frame update
    void Start()
    {
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

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Death")
        {
            m_Animator.SetTrigger("Stop");
            objectApperance.enabled = false;
            Debug.Log("It works");
        }
    }

    private void OnTriggerExit(Collider collider)
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
