using System;
using InputSystem;
using PlayerSystem;
using UnityEngine;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private InputListener inputListener;
        [SerializeField] private Player player;
        private Movement _movement;

        private void Awake()
        {
            _movement = new Movement();
            inputListener.Construct(player, _movement);
        }
    }
}
