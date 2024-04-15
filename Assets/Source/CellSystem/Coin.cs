using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private Vector3 _forceDirection = new Vector3(0, 1, 1);
    [SerializeField] private float _forceMagnitude = 5f; 

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        Vector3 force = _forceDirection.normalized * _forceMagnitude;
        
        _rigidbody.AddForce(force, ForceMode.Impulse);
    }
}