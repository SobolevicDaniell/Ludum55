using System;
using UnityEngine;

namespace PlayerSystem
{
    public class Camera : MonoBehaviour
    {
        public float sensX;
        public float sensY;

        public Transform orientation;

        private float xRot;
        private float yRot;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

            yRot += mouseX;
            xRot -= mouseY;

            xRot = Math.Clamp(xRot, -90f, 90f);
            transform.rotation = Quaternion.Euler(xRot, yRot, 0);
            orientation.rotation = Quaternion.Euler(0, yRot, 0);
        }
    }
}
