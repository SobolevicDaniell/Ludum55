using PlayerSystem;
using UnityEngine;
using Camera = UnityEngine.Camera;

namespace ItemSystem
{
    public class PickUp : MonoBehaviour
    {
        [SerializeField] private GameObject _theDest;
        private bool _pickedUp;
        private Player _player;
        [SerializeField] private LayerMask _pickUpLayer;

        private void Update()
        {
            DropDown();
            PickingUp();
        }

        public void Construct(Player player)
        {
            _player = player;
        }
        
        private void DropDown()
        {
            if (_pickedUp && Input.GetKeyDown(KeyCode.Q))
            {
                Transform child = _theDest.transform.GetChild(0);
                Rigidbody childRb = child.GetComponent<Rigidbody>();
                childRb.isKinematic = false;
                childRb.useGravity = true;
                child.GetComponent<Collider>().enabled = true;
                child.parent = null;
                _pickedUp = false;
            }
        }

        private void PickingUp()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
                if (Physics.Raycast(ray, out hit, 2f, _pickUpLayer))
                {
                    Debug.Log(hit.collider.gameObject);
                    if (!_pickedUp)
                    {
                        Collider hitColl = hit.collider;
                        hitColl.transform.parent = _theDest.transform;
                        Rigidbody collRb = hitColl.GetComponent<Rigidbody>();
                        collRb.isKinematic = true;
                        collRb.useGravity = false;
                        hitColl.GetComponent<Collider>().enabled = false;
                        hitColl.transform.position = _theDest.transform.position;
                        //hitColl.transform.rotation = _theDest.transform.rotation;
                        _pickedUp = true;
                    }
                }
            }
        }
    }
}
