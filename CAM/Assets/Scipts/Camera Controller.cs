using Kino;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CameraMovement : MonoBehaviour
{
    public bool CanMove { get; private set; } = true;

    public bool InActive = true;


    [Header("Functional Options")]                       //<<<----- Stuff like Headbobs, Zooming in, interact, crouch, Running, etc....
    [SerializeField] private bool canInteract = true;
    [SerializeField] private bool canZoom = true;

    [Header("Controls")]                                 //<<<----- What inputs must be pressed to do what.
    [SerializeField] private KeyCode interactKey = KeyCode.E;
    [SerializeField] private KeyCode zoomKey = KeyCode.Mouse1;

    [Header("Look Parameters")]
    [SerializeField, Range(1, 200)] private float lookSpeed = 100.0f;
    [SerializeField, Range(1, 360)] private float clampHorizontalAngle = 180f;
    [SerializeField, Range(1, 180)] private float clampVerticalAngle = 180f;

    [Header("Zoom Parameters")]
    [SerializeField] private float timeToZoom = 0.3f;
    [SerializeField] private float zoomFOV = 30f;
    private float defaultFOV;
    private Coroutine zoomRoutine;

    [Header("Interaction")]
    [SerializeField] private Vector3 interactionRayPoint = default;
    [SerializeField] private float interactionDistance = default;
    [SerializeField] private LayerMask interactionLayer = default;
    private Interractable currentInteractable;


    private Camera playerCamera;
    private CharacterController characterController;

    public AnalogGlitch staticEffect;

    private Vector3 moveDirection;
    private Vector2 currentInput;

    private float rotationX = 0;

    private float rotY = 0.0f;
    private float rotX = 0.0f;

    [SerializeField] private float disableStaticIn = 0.2f;

    void Awake()
    {
        staticEffect = GetComponentInChildren<AnalogGlitch>();
        playerCamera = GetComponentInChildren<Camera>();
        characterController = GetComponent<CharacterController>();
        defaultFOV = playerCamera.fieldOfView;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {

        if (CanMove)
        {
            HandleMouseLook();

            if (canInteract)
            {
                HandleInteractionCheck();
                HandleInteractionInput();
            }

            if (canZoom)
            {
                HandleZoom(); 
            }
        }

        if (this.gameObject.activeSelf)
        {
            StartCoroutine(DisableStatic());
        }

    }

    //-------------------------------------------- I know it looks confusing but this will allow us to interact with items anyway we like.
    private void HandleInteractionCheck()
    {
        if(Physics.Raycast(playerCamera.ViewportPointToRay(interactionRayPoint), out RaycastHit hit, interactionDistance))
        {
            if(hit.collider.gameObject.layer == 6 && (currentInteractable == null || hit.collider.gameObject.GetInstanceID() != currentInteractable.gameObject.GetInstanceID()))
            {
                hit.collider.TryGetComponent(out currentInteractable);

                if (currentInteractable)
                    currentInteractable.OnFocus();
            }
        }
        else if (currentInteractable)
        {
            currentInteractable.OnLoseFocus();
            currentInteractable = null;
        }
    }

    private void HandleInteractionInput()
    {
        if (Input .GetKeyDown(interactKey) && currentInteractable != null && Physics.Raycast(playerCamera.ViewportPointToRay(interactionRayPoint), out RaycastHit hit, interactionDistance, interactionLayer))
        {
            currentInteractable.OnInteract();
        }
    }

    //-----------------------------------------------------------------------

    private void HandleMouseLook()
    {

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");
        if (mouseX != 0 || mouseY != 0)
        {
            rotY += mouseX * lookSpeed * Time.deltaTime;
            rotX += mouseY * lookSpeed * Time.deltaTime;


            rotX = Mathf.Clamp(rotX, -clampVerticalAngle, clampVerticalAngle);
            rotY = Mathf.Clamp(rotY, -clampHorizontalAngle, clampHorizontalAngle);

            //forces player body movement alongside the camera
            playerCamera.transform.localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        }
    }

    private void HandleZoom()
    {
        if(Input.GetKeyDown(zoomKey))
        {
            if(zoomRoutine != null)
            {
                StopCoroutine(zoomRoutine);
                zoomRoutine = null;
            }

            zoomRoutine = StartCoroutine(ToggleZoom(true));
        }

        if (Input.GetKeyUp(zoomKey))
        {
            if (zoomRoutine != null)
            {
                StopCoroutine(zoomRoutine);
                zoomRoutine = null;
            }

            zoomRoutine = StartCoroutine(ToggleZoom(false));
        }
    }

    private IEnumerator ToggleZoom(bool isEnter)
    {
        float targetFOV = isEnter ? zoomFOV : defaultFOV;
        float startingFOV = playerCamera.fieldOfView;
        float timeElapse = 0;

        while (timeElapse < timeToZoom)
        {
            playerCamera.fieldOfView = Mathf.Lerp(startingFOV, targetFOV, timeElapse / timeToZoom);
            timeElapse += Time.deltaTime;
            yield return null;
        }

        playerCamera.fieldOfView = targetFOV;
        zoomRoutine = null;
    }

    public IEnumerator DisableStatic()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(disableStaticIn);

        // Disable the GameObject
        staticEffect.enabled = false;
    }
}