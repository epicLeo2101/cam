using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public bool CanMove { get; private set; } = true;

    [Header("Look Parameters")]
    [SerializeField, Range(1, 10)] private float lookSpeedX = 2.0f;
    [SerializeField, Range(1, 10)] private float lookSpeedY = 2.0f;
    [SerializeField, Range(1, 180)] private float upperLookLimit = 50.0f;
    [SerializeField, Range(1, 180)] private float lowerLookLimit = 50.0f;

    private Camera playerCamera;

    private Vector2 currentInput;

    private float rotationX = 0;

    void Awake()
    {
        playerCamera = GetComponent<Camera>();
        //Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {

        if (CanMove)
        {
            //Ask help on how to add look limit on left and right Also see if it possible to add it on the player controll script. 
        }

    }
}
