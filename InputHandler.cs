using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JS
{
    public class InputHandler : MonoBehaviour
    {
        public float horizontal;
        public float vertical;
        public float moveAmount;
        public float mouseX;
        public float mouseY;

        public bool b_input;
        public bool rollFlag;
        public bool isInteracting;

        InputMaster inputActions;
        CameraHandler cameraHandler;
        Vector2 movementInput;
        Vector2 cameraInput;

        private void Awake()
        {
            cameraHandler = CameraHandler.singleton;
        }

        private void FixedUpdate()
        {
            float delta = Time.fixedDeltaTime;
            if(cameraHandler != null)
            {
                cameraHandler.FollowTarget(delta);
                cameraHandler.HandleCameraRotation(delta, mouseX, mouseY);
            }
        }

        public void OnEnable()
        {
            if(inputActions == null) 
            {
                inputActions = new InputMaster();
                inputActions.PlayerMovement.Movement.performed += inputActions => movementInput = inputActions.ReadValue<Vector2>();
                inputActions.PlayerMovement.Camera.performed += i =>cameraInput = i.ReadValue<Vector2>();
            }

            inputActions.Enable();
        }


        public void OnDisable()
        {
            inputActions.Disable();
        }

        public void tickInput(float delta)
        {
            MoveInput(delta);
            HandleRollingInput(delta);
        }

        private void MoveInput(float delta)
        {
            horizontal = movementInput.x;
            vertical = movementInput.y;
            moveAmount = Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(vertical));
            mouseX = cameraInput.x;
            mouseY = cameraInput.y;
        }

        private void HandleRollingInput(float delta)
        {
            b_input = inputActions.PlayerActions.Roll.phase == UnityEngine.InputSystem.InputActionPhase.Started;
            if (b_input)
            {
                rollFlag = true;
            }
        }
    }
}

