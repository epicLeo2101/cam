using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CameraMovement : MonoBehaviour
{
    public bool CanMove { get; private set; } = true;


    [Header("Functional Options")]                       //<<<----- Stuff like Headbobs, Zooming in, interact, crouch, Running, etc....
    [SerializeField] private bool canInteract = true;

    [Header("Controls")]                                 //<<<----- What inputs must be pressed to do what.
    [SerializeField] private KeyCode interactKey = KeyCode.E;

    [Header("Look Parameters")]
    [SerializeField, Range(1, 200)] private float lookSpeed = 100.0f;
    [SerializeField, Range(1, 360)] private float clampHorizontalAngle = 180f;
    [SerializeField, Range(1, 180)] private float clampVerticalAngle = 180f;

    [Header("Interaction")]
    [SerializeField] private Vector3 interactionRayPoint = default;
    [SerializeField] private float interactionDistance = default;
    [SerializeField] private LayerMask interactionLayer = default;
    private Interractable currentInteractable;


    private Camera playerCamera;
    private CharacterController characterController;

    private Vector3 moveDirection;
    private Vector2 currentInput;

    private float rotationX = 0;

    private float rotY = 0.0f;
    private float rotX = 0.0f;

    void Awake()
    {
        playerCamera = GetComponentInChildren<Camera>();
        characterController = GetComponent<CharacterController>();
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
        }
     
    }

    //-------------------------------------------- I know it looks confusing but this will allow us to interact with items anyway we like.
    private void HandleInteractionCheck()
    {
        if(Physics.Raycast(playerCamera.ViewportPointToRay(interactionRayPoint), out RaycastHit hit, interactionDistance))
        {
            if(hit.collider.gameObject.layer == 6 && (currentInteractable == null || hit.collider.gameObject.GetInstanceID() != currentInteractable.GetInstanceID()))
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
            playerCamera.transform.localRotation = Quaternion.Euler(rotX, rotY, 0.0f); // This is the cause why it is inverted. now you need to figure out how to change that.
            //transform.rotation = localRotation; //This may be usefull plus "Quaternion localRotation" may need to replace the start of line 112
        }
    }
}