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

    //[Header("All death scenes")]
    //[SerializeField] private List<Animation> deathAnimations = new List<Animation>(); //<<<<<------ WIP

    private bool isCoolDown = false;
    public MeshRenderer objectApperance;
    private Animator m_Animator;
    private GameObject alanPOVCamera;

    public AnalogGlitch staticEffect;


    [SerializeField] private float disableStaticIn = 0.2f;
    [SerializeField] private float animationDuration = 1f; //<<<<---- just so the player does't spam the Space button however it may not be there for long.
    private float regainCollision = 0.3f; //<<<<<<------ Here so alan collision can be turn on but delete it later when it is improve, but it may stick who knows.

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
        if (collider.gameObject.tag == "Death")  //<<<<<---- Plays Death Animation 1
        {
            m_Animator.SetTrigger("Death_1");
            GetComponent<Collider>().enabled = false;
            ///alanPOVCamera.SetActive(false);  //<-- You may not need it but most likely it'll be useless now.
            ///objectApperance.enabled = false;
            Debug.Log("Alan Died");
        }

        if (collider.gameObject.tag == "DeleteLater_1") //<<<<<---- Plays Death Animation 3
        {
            m_Animator.SetTrigger("Death_3");
            GetComponent<Collider>().enabled = false;
        }

        if(collider.gameObject.tag == "DeleteLater_2")
        {
            m_Animator.SetTrigger("Death_4");
            GetComponent<Collider>().enabled = false;
        }

        if (collider.gameObject.tag == "CheckPoint")
        {
            checkPointReach.CheckPointReach();
            Debug.Log("Check Point!");
        }
    }

    public void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Essential")  //<<<<<---- Plays Death Animation 2
        {
            m_Animator.SetTrigger("Death_2");
            GetComponent<Collider>().enabled = false;
            //alanPOVCamera.SetActive(false);
            //objectApperance.enabled = false;
            Debug.Log("Alan Died");
        }
    }

    public void StopAnimation()
    {
        m_Animator.SetTrigger("Stop");
        alanPOVCamera.SetActive(false);
        objectApperance.enabled = false;
        StartCoroutine(RegainCollsionCoolDown());
    }

    private IEnumerator CoolDown()
    {
        isCoolDown = true;
        yield return new WaitForSeconds(animationDuration);
        isCoolDown = false;
    }

    private IEnumerator RegainCollsionCoolDown()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(regainCollision);

        // Enable Collision for Alan
        GetComponent<Collider>().enabled = true;
    }

    public IEnumerator DisableStatic()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(disableStaticIn);

        // Disable the GameObject
        staticEffect.enabled = false;
    }
}
