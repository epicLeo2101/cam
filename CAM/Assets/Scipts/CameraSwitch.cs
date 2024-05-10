using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraSwitch : MonoBehaviour
{
    [Header("Controls")]                                 //<<<----- What inputs must be pressed to do what.
    [SerializeField] private KeyCode switchRight = KeyCode.D;
    [SerializeField] private KeyCode switchLeft = KeyCode.A;
    [SerializeField] private KeyCode pauseKey = KeyCode.Escape;

    [Header("Cameras")]
    [SerializeField] private List<GameObject> _cameras = new ();

    private float coolDownTime = 1f;
    private float pauseCoolDownTime = 0.3f;
    private bool isCoolDown = false;
    private bool CanMove = true;
    private int currentCameraIndex;

    CameraMovement cameraMovement;
    public GameObject pauseMenu;

    // Start is called before the first frame update
    private void Awake()
    {
        FindCameras();
        UpdateCurrentCam();
        pauseMenu.SetActive(false);
        Debug.Log("Remember: All the 'Sections # (all Cameras)' must have the 'Exit Panels' in the 'Pasue Menu' or it will not work.");
    }

    // Update is called once per frame
    void Update()
    {
        cameraMovement = GetComponentInChildren<CameraMovement>();

        if (CanMove)
        {
            if (Input.GetKey(switchRight) && !isCoolDown)
            {
                SwitchToRight();
                StartCoroutine(CoolDown());
                cameraMovement.staticEffect.enabled = true;
            }

            if (Input.GetKey(switchLeft) && !isCoolDown)
            {
                SwitchToLeft();
                StartCoroutine(CoolDown());
                cameraMovement.staticEffect.enabled = true;
            }

            if (Input.GetKeyDown(pauseKey) && !isCoolDown)
            {
                CanMove = false;
                cameraMovement.enabled = false;
                //Debug.Log("paused Game");
                pauseMenu.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                StartCoroutine(PauseCoolDown());
            }
        }

        if (!CanMove)
        {
            if (Input.GetKeyDown(pauseKey) && !isCoolDown)
            {
                CanMove = true;
                cameraMovement.enabled = true;
                Debug.Log("Resume Game");
                pauseMenu.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                StartCoroutine(CoolDown());
            }
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

    private IEnumerator PauseCoolDown()
    {
        isCoolDown = true;
        yield return new WaitForSeconds(pauseCoolDownTime);
        isCoolDown = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResumeGame()
    {
        CanMove = true;
        cameraMovement.enabled = true;
        Debug.Log("Resume Game");
        pauseMenu.SetActive(false);
        Cursor.visible = false;
        StartCoroutine(CoolDown());
    }

    public void ResetTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Game Reset");
    }
}
