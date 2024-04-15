using System;
using InputSystem;
using ItemSystem;
using PlayerSystem;
using UnityEngine;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private InputListener inputListener;
        [SerializeField] private Player player;
        [SerializeField] private PickUp pickUp;
        [SerializeField] private BookSystem book;
        private Movement _movement;

        private void Awake()
        {
            _movement = new Movement();
            inputListener.Construct(player, _movement, book);
            pickUp.Construct(player);
            book.Construct(player);
        }
    }
}
