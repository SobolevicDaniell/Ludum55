using System;
using PlayerSystem;
using UnityEngine;
using Camera = UnityEngine.Camera;

namespace ItemSystem
{
    public class PickUp : MonoBehaviour
    {
        [SerializeField] private GameObject theDest;
        private bool _pickedUp;
        private Player _player;

        private void Update()
        {
            DropDown();
            PickingUp(_player.Items);
        }

        public void Construct(Player player)
        {
            _player = player;
        }
        
        private void DropDown()
        {
            if (_pickedUp)
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    Transform child = theDest.transform.GetChild(0);
                    Rigidbody childRb = child.GetComponent<Rigidbody>();
                    childRb.isKinematic = false;
                    childRb.useGravity = true;
                    child.GetComponent<SphereCollider>().enabled = true;
                    child.parent = null;
                    _pickedUp = false;
                }
            }
        }
        private void PickingUp(LayerMask pickUpLayer)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            if (Physics.Raycast(ray, out hit, 2f))
            {
                if ((pickUpLayer & (1 << hit.collider.gameObject.layer)) != 0)
                {
                    if (_pickedUp == false)
                    {
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            Collider hitColl = hit.collider;
                            hitColl.transform.parent = theDest.transform;
                            Rigidbody collRb = hitColl.GetComponent<Rigidbody>();
                            collRb.isKinematic = true;
                            collRb.useGravity = false;
                            hitColl.GetComponent<SphereCollider>().enabled = false;
                            hitColl.transform.position = theDest.transform.position;
                            hitColl.transform.rotation = theDest.transform.rotation;
                            _pickedUp = true;
                        }
                    }
                }
            }
        }
    }
}
