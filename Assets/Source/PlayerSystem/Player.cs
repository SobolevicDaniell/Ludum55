using System;
using UnityEngine;

namespace PlayerSystem
{
    public class Player : MonoBehaviour
    {
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public Rigidbody Rb { get; private set; }
        [field: SerializeField] public Transform PlayerTransform { get; private set; }
        [field: SerializeField] public float Height { get; private set; }
        [field: SerializeField] public LayerMask Ground { get; private set; }
        [field: SerializeField] public LayerMask Items { get; private set; }
        [field: SerializeField] public float groundDrag;
        private bool _grounded;
        private void Update()
        {
            _grounded = Physics.Raycast(transform.position, Vector3.down, Height * 0.5f + 0.3f, Ground);

            if (_grounded)
            {
                Rb.drag = groundDrag;
            }
            else
            {
                Rb.drag = 0;
            }
        }
    }
}