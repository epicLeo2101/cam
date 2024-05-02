using Kino;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AlanState : MonoBehaviour
{
    [Header("Controls")]                                
    [SerializeField] private KeyCode playVideoKey = KeyCode.Space;
    [SerializeField] private bool checkPointYOrN = false;

    public float animationDuration = 1f; //<<<<---- just so the player does't spam the Space button however it may not be there for long.

    private bool isCoolDown = false;
    public MeshRenderer objectApperance;
    private Animator m_Animator;
    private GameObject alanPOVCamera;

    public AnalogGlitch staticEffect;


    [SerializeField] private float disableStaticIn = 0.2f;

    CheckPoint checkPointReach;


    // Start is called before the first frame update
    void Start()
    {
        if (checkPointYOrN == true)
        {
            Debug.Log("Remember the Component 'CheckPoint' must have a tag with 'Sections'");
            checkPointReach = GameObject.FindGameObjectWithTag("Sections").GetComponent<CheckPoint>();
        }

        else
        {
            Debug.Log("If there's a gameObject with tag named 'chekcpoint.' It will not work");
        }

        m_Animator = GetComponent<Animator>();
        objectApperance = GetComponent<MeshRenderer>();
        alanPOVCamera = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(m_Animator != null)
        {
            if(Input.GetKeyDown(playVideoKey) && !isCoolDown)
            {
                m_Animator.SetTrigger("Play");
                alanPOVCamera.SetActive(true);
                objectApperance.enabled = true;
                staticEffect.enabled = true;

                StartCoroutine(CoolDown());
                StartCoroutine(DisableStatic());
            }
        }
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Death")
        {
            m_Animator.SetTrigger("Stop");
            alanPOVCamera.SetActive(false);
            objectApperance.enabled = false;
            Debug.Log("Alan Died");
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
            alanPOVCamera.SetActive(false);
            objectApperance.enabled = false;
            Debug.Log("Alan Died");
        }
    }

    private IEnumerator CoolDown()
    {
        isCoolDown = true;
        yield return new WaitForSeconds(animationDuration);
        isCoolDown = false;
    }

    public IEnumerator DisableStatic()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(disableStaticIn);

        // Disable the GameObject
        staticEffect.enabled = false;
    }
}
