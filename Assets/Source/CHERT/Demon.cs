using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Demon : MonoBehaviour
{
    [SerializeField] private Collider _demonCollider;
    [SerializeField] private float _moveSpeed = 5f;
    private Transform _playerTransform;

    private bool _activated = false;

    private void Start()
    {
        _playerTransform = GameObject.FindWithTag("Player").transform;
        if (_playerTransform != null)
        {
            Debug.Log("target");
            Invoke("Activate", 2f);
        }
        else
        {
            Debug.LogError("Player object not found with tag 'Player'.");
        }
    }

    private void Update()
    {
        if (_activated)
        {
            MoveTowardsPlayer();
        }
    }

    private void Activate()
    {
        _demonCollider.enabled = true;
        _activated = true;
    }

    private void MoveTowardsPlayer()
    {
        if (_playerTransform != null)
        {
            Vector3 direction = (_playerTransform.position - transform.position).normalized;
            direction.y = 0f;

            transform.rotation = Quaternion.LookRotation(direction);

            transform.Translate(Vector3.forward * _moveSpeed * Time.deltaTime);
        }
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

}