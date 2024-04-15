using System;
using GoldSystem;
using InputSystem;
using ItemSystem;
using PlayerSystem;
using UnityEngine;
using UnityEngine.Serialization;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private InputListener inputListener;
        [SerializeField] private Player player;
        [SerializeField] private PickUp pickUp;
        [SerializeField] private BookSystem book;
        [SerializeField] private GoldView goldView;
        private Movement _movement;
        private Gold _gold;

        private void Awake()
        {
            _gold = new Gold();
            _movement = new Movement();
            inputListener.Construct(player, _movement, book);
            pickUp.Construct(player);
            book.Construct(player);
            goldView.Construct(_gold);
        }
    }
}
