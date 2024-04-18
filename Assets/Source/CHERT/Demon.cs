using UnityEngine;
using UnityEngine.SceneManagement;

public class Demon : MonoBehaviour
{
    [SerializeField] private Collider _demonCollider;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _turnSpeed = 5f;
    private Transform _playerTransform;
    private bool _activated = false;
    private Quaternion _initialRotation;

    private void Start()
    {
        _playerTransform = GameObject.FindWithTag("Player").transform;
        if (_playerTransform != null)
        {
            Debug.Log("target");
            Invoke("Activate", 8f);
        }
        else
        {
            Debug.LogError("Player object not found with tag 'Player'.");
        }
        
        // Сохраняем начальную ориентацию демона
        _initialRotation = transform.rotation;
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

        // Устанавливаем начальную ориентацию демона после активации
        transform.rotation = _initialRotation * Quaternion.Euler(0f,-90f,0f);
    }

    private void MoveTowardsPlayer()
    {
        if (_playerTransform != null)
        {
            // Находим направление к игроку
            Vector3 direction = (_playerTransform.position - transform.position).normalized;
            // Оставляем только горизонтальное направление
            direction.y = 0f;

            // Поворачиваем объект к игроку только по оси Y
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            // Применяем только поворот по оси Y, сохраняя остальные оси
            Quaternion targetYRotation = Quaternion.Euler(_initialRotation.eulerAngles.x, targetRotation.eulerAngles.y, _initialRotation.eulerAngles.z);
            // Применяем поворот
            transform.rotation = Quaternion.Slerp(transform.rotation, targetYRotation, Time.deltaTime * _turnSpeed);

            // Двигаемся вперед
            transform.Translate(Vector3.forward * _moveSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("MainMenu");
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
