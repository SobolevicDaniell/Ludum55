using System;
using ItemSystem;
using PlayerSystem;
using UnityEngine;

namespace InputSystem
{
    public class InputListener : MonoBehaviour
    {
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";
        private bool _canMove = true;
        private Movement _movement;
        private Player _player;
        private BookSystem _bookSystem;

        public void Construct(Player player, Movement movement, BookSystem bookSystem)
        {
            _player = player;
            _movement = movement;
            _bookSystem = bookSystem;
            bookSystem.startCamera += ChangeMoveState;
            bookSystem.stopCamera += ChangeMoveState;
        }

        private void ChangeMoveState()
        {
            _canMove = !_canMove;
        }
        private void FixedUpdate()
        {
            if (_canMove)
            {
                ReadMove();
            }
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
