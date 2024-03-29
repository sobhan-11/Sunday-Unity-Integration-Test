using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallRoller : MonoBehaviour
{
    [Header("Components"), Space] 
    private Camera _camera;
    private Rigidbody _ballRigidbody;
    private GameObject _ballGameObject;

    [Header("Configs"), Space]
    //Move
    [SerializeField] private float torqueAmount;
    //Input
    private Vector3 cameraOffset = new();
    private Vector2 inputVector = Vector2.zero;
    private Vector2 originalPressPoint = Vector2.zero;
    private bool isPressing = false;

    private void Awake()
    {
        MyEventSystem.I.StartLevel(LevelManager.instance.currentLevelIndex + 1);

        Init();
    }

    private void Start()
    {
        cameraOffset = _ballGameObject.transform.position - Camera.main.transform.position;
    }

    private void Update()
    {
        GatherInput(); // Gather Input in update for avoid missing any inputs
    }

    private void FixedUpdate()
    {
        ApplyMove(); // apply movement and physics calculations in fixed update for better performance
    }

    private void LateUpdate()
    {
        CameraFollow(); // put camera follow in late update for better performance
    }

    #region Initialize

    private void Init()
    {
        // We should catch components for improve performance
        _ballGameObject = GameObject.Find("PlayerBall"); // it's better to create a const string for ball name!
        _ballRigidbody = _ballGameObject.GetComponent<Rigidbody>();
        _camera = Camera.main; // Don't use camera.main in every frame , its a heavy call

        cameraOffset = _ballGameObject.transform.position - _camera.transform.position;
    }

    #endregion

    #region BallMovement

    private void GatherInput()
    {
        if (Input.GetMouseButton(0))
        {
            if (isPressing)
            {
                inputVector = (originalPressPoint - new Vector2(Input.mousePosition.x, Input.mousePosition.y)).normalized;
                return;
            }
            originalPressPoint = Input.mousePosition;
            isPressing = true;
        }
    }

    private void ApplyMove()
    {
        // Multiply torque with fixed delta time to independent movement and input from frame rate 
        var torque = (Vector3.forward * inputVector.x + Vector3.right * -inputVector.y) * (torqueAmount * Time.fixedDeltaTime);
        _ballRigidbody.AddTorque(torque, ForceMode.VelocityChange);
    }

    #endregion

    #region Camera

    private void CameraFollow() => _camera.transform.position = _ballGameObject.transform.position - cameraOffset;

    #endregion
}