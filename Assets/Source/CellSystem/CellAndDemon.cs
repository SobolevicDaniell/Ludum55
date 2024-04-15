using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class CellAndDemon : MonoBehaviour
{
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private GameObject _spawnArea;
    [SerializeField] private GameObject _demonPrefab;

    [SerializeField] private GameObject _demonSpawnPosition;

    
    [SerializeField] private AudioClip _groundImpactSound;
    [SerializeField] private AudioClip _applause;
    [SerializeField] private AudioClip _screams;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other)
    {
        MaterialObject materialObject = other.gameObject.GetComponent<MaterialObject>();
        if (materialObject != null)
        {
            if (materialObject._material == MaterialObject.Materials.explosive_potion)
            {
                Destroy(materialObject.gameObject);
                Applauses();
                SpawnCoin(6);
                
            }
            else if (materialObject._material == MaterialObject.Materials.fire_poison_potion)
            {
                Destroy(materialObject.gameObject);
                Applauses();
                SpawnCoin(9);
            }
            else if (materialObject._material == MaterialObject.Materials.tornado_potion)
            {
                Destroy(materialObject.gameObject);
                Applauses();
                SpawnCoin(13);
            }
            else if (materialObject._material == MaterialObject.Materials.gap_potion)
            {
                Destroy(materialObject.gameObject);
                Applauses();
                SpawnCoin(16);
            }
            else if (materialObject._material == MaterialObject.Materials.blue_flame_potion)
            {
                Destroy(materialObject.gameObject);
                Applauses();
                SpawnCoin(26);
            }
            else if (materialObject._material == MaterialObject.Materials.infernal_potion)
            {
                Destroy(materialObject.gameObject);
                Applauses();
                SpawnCoin(38);
            }
            else if (materialObject._material == MaterialObject.Materials.summoning_potion)
            {
                Destroy(materialObject.gameObject);
                SpawnDemon();
            }
        }
    }

    // private void CoinSound()
    // {
    //     _audioSource.PlayOneShot(_groundImpactSound);
    // }

    private void Applauses()
    {
        _audioSource.PlayOneShot(_applause);
        _audioSource.PlayOneShot(_screams);
    }

    private void SpawnDemon()
    {
        Vector3 spawnPosition = _demonSpawnPosition.transform.position;
        Instantiate(_demonPrefab, spawnPosition, Quaternion.identity);
    }

    private void SpawnCoin(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 spawnPosition = GetRandomSpawnPosition();
            Instantiate(_coinPrefab, spawnPosition, Quaternion.identity);
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        Vector3 spawnPosition = _spawnArea.transform.position;
        float offsetX = Random.Range(-_spawnArea.transform.localScale.x / 2f, _spawnArea.transform.localScale.x / 2f);
        float offsetY = Random.Range(-_spawnArea.transform.localScale.y / 2f, _spawnArea.transform.localScale.y / 2f);
        float offsetZ = Random.Range(-_spawnArea.transform.localScale.z / 2f, _spawnArea.transform.localScale.z / 2f);
        spawnPosition += new Vector3(offsetX, offsetY, offsetZ);
        return spawnPosition;
    }
}