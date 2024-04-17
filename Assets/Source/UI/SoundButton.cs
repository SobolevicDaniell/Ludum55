using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundButton : MonoBehaviour
{
    [SerializeField] private AudioClip _byeSound;
    private AudioSource _audioSource;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonSound()
    {
        _audioSource.PlayOneShot(_byeSound);
    }
}
