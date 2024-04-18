using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [Header("Controls")]                                 //<<<----- What inputs must be pressed to do what.
    [SerializeField] private KeyCode switchRight = KeyCode.D;
    [SerializeField] private KeyCode switchLeft = KeyCode.A;

    [Header("Cameras")]
    [SerializeField] private List<GameObject> _cameras = new ();

    private float coolDownTime = 1f;
    private bool isCoolDown = false;
    private int currentCameraIndex;

    //CameraMovement cameraMovement;    <<<<<<<<<<<------- REMOVE THE COMMENT!!!!!! 

    // Start is called before the first frame update
    private void Awake()
    {
        FindCameras();
        UpdateCurrentCam();
    }

    // Update is called once per frame
    void Update()
    {
        //cameraMovement = GetComponentInChildren<CameraMovement>(); <<<<<<<<<<<------- REMOVE THE COMMENT!!!!!! 

        if (Input.GetKey(switchRight) && !isCoolDown)
        {
            SwitchToRight();
            StartCoroutine(CoolDown());
            //cameraMovement.staticEffect.SetActive(true); <<<<<<<<<<<------- REMOVE THE COMMENT!!!!!! 
        }

        if (Input.GetKey(switchLeft) && !isCoolDown)
        {
            SwitchToLeft();
            StartCoroutine(CoolDown());
            //cameraMovement.staticEffect.SetActive(true); <<<<<<<<<<<------- REMOVE THE COMMENT!!!!!! 
        }
    }

    private void FindCameras()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            _cameras.Add(transform.GetChild(i).gameObject);
        }
    }

    private void UpdateCurrentCam()
    {
        foreach(GameObject cam in _cameras)
        {
            cam.SetActive(false);
        }

        _cameras[currentCameraIndex].SetActive(true);
    }

    public void SwitchToRight()
    {
        currentCameraIndex++;

        if (currentCameraIndex >= _cameras.Count)
        {
            currentCameraIndex = 0;
        }

        UpdateCurrentCam();
    }

    public void SwitchToLeft()
    {
        currentCameraIndex--;

        if (currentCameraIndex < 0)
        {
            currentCameraIndex = _cameras.Count - 1;
        }

        UpdateCurrentCam();
    }

    private IEnumerator CoolDown()
    {
        isCoolDown = true;
        yield return new WaitForSeconds(coolDownTime);
        isCoolDown = false;
    }
}
