using PlayerSystem;
using UnityEngine;
using UnityEngine.Serialization;

namespace GoldSystem
{
    public class PickUpGold : MonoBehaviour
    {
        private Player _player;
        private Gold _gold;

        public void Construct(Player player, Gold gold)
        {
            _player = player;
            _gold = gold;
        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            if ((_player.Gold  & (1 << other.gameObject.layer)) != 0)
            {
                    _gold.AddScore(1);
                    Debug.Log("Get Gold");
            }
           
        }
    }
}
