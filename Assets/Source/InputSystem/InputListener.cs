using System;
using PlayerSystem;
using UnityEngine;

namespace InputSystem
{
    public class InputListener : MonoBehaviour
    {
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";
        private Movement _movement;
        private Player _player;

        public void Construct(Player player, Movement movement)
        {
            _player = player;
            _movement = movement;
        }
        private void Update()
        {
            
        }

        private void FixedUpdate()
        {
            ReadMove();
        }

        private void ReadMove()
        {
            float horizontal = Input.GetAxis(Horizontal);
            float vertical = Input.GetAxis(Vertical);
            Vector3 moveDir = new Vector3(horizontal, vertical);
            _movement.Move(_player.Rb, _player.PlayerTransform,_player.Speed,moveDir);
        }
    }
}
