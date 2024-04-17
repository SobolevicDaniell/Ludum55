using PlayerSystem;
using UnityEngine;
using UnityEngine.Serialization;

namespace GoldSystem
{
    public class PickUpGold : MonoBehaviour
    {
        private Player _player;
        private Gold _gold;
        [SerializeField] private AudioClip _money;

        public void Construct(Player player, Gold gold)
        {
            _player = player;
            _gold = gold;
        }
        
        private void OnTriggerEnter (Collider other)
        {
            if ((_player.Gold  & (1 << other.gameObject.layer)) != 0)
            {
                    _gold.AddScore(1);
                    Destroy(other.gameObject);
                    _audioSource.PlayOneShot(_money);
                    Debug.Log("Get Gold");
            }
           
        }
        
        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

    }
}
