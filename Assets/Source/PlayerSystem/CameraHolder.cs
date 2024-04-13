using System;
using UnityEngine;

namespace PlayerSystem
{
    public class CameraHolder : MonoBehaviour
    {
        [SerializeField] private Transform cameraPos;
        private void Update()
        {
            transform.position = cameraPos.position;
        }
    }
}
