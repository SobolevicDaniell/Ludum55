using System;
using ItemSystem;
using UnityEngine;
using UnityEngine.Serialization;

namespace PlayerSystem
{
    public class PlayerCamera : MonoBehaviour
    {
        [SerializeField] private BookSystem bookSystem;
        private bool _isCameraActive = true;
        public float sensX;
        public float sensY;

        public Transform orientation;

        private float xRot;
        private float yRot;

        private void Start()
        {
            bookSystem.stopCamera += ChangeState;
            bookSystem.stopCamera += StopCamera;
            bookSystem.startCamera += ChangeState;
            bookSystem.startCamera += StartCamera;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void ChangeState()
        {
            _isCameraActive = !_isCameraActive;
        }
        public void StopCamera()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        public void StartCamera()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        public void ContinueCamera()
        {
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

            yRot += mouseX;
            xRot -= mouseY;

            xRot = Math.Clamp(xRot, -90f, 90f);
            transform.rotation = Quaternion.Euler(xRot, yRot, 0);
            orientation.rotation = Quaternion.Euler(0, yRot, 0);
        }
        private void Update()
        {
            if (_isCameraActive)
            {
                ContinueCamera();
            }
        }
    }
}
