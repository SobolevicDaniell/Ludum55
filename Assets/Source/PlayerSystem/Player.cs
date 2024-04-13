using UnityEngine;

namespace PlayerSystem
{
    public class Player : MonoBehaviour
    {
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public Rigidbody Rb { get; private set; }
        [field: SerializeField] public Transform PlayerTransform { get; private set; }
        
    }
}