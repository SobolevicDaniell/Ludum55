using System;
using UnityEngine;

namespace PlayerSystem
{
    public class PlayerCollisionDetecter : MonoBehaviour
    {
        [SerializeField] private LayerMask obstacle;
        [SerializeField] private Player player;
        private void OnCollisionEnter(Collision other)
        {
            if ((obstacle & (1 << other.gameObject.layer)) != 0)
            {
                player.ChangeSpeed(1);
            }
        }

        private void OnCollisionExit(Collision other)
        {
            if ((obstacle & (1 << other.gameObject.layer)) != 0)
            {
                player.ChangeSpeed(8);
            }
        }
    }
}
