using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private Vector3 _forceDirection = new Vector3(-2, 1, 0);
    [SerializeField] private float _forceMagnitude = 5f; 
    [SerializeField] private AudioClip _groundImpactSound;

    private Rigidbody _rigidbody;
    private AudioSource _audioSource;
    private bool _soundPlayed = false;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
        Vector3 force = _forceDirection.normalized * _forceMagnitude;
        _rigidbody.AddForce(force, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!_soundPlayed && other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            if (_audioSource != null && _groundImpactSound != null)
            {
                _audioSource.PlayOneShot(_groundImpactSound);
                _soundPlayed = true;
            }
        }
    }
}