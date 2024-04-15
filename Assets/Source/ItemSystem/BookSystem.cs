using System;
using PlayerSystem;
using UnityEngine;
using Camera = UnityEngine.Camera;

namespace ItemSystem
{
    public class BookSystem : MonoBehaviour
    {
        public event Action stopCamera;
        public event Action startCamera;
        [SerializeField] private GameObject bookMenu;
        [SerializeField] private GameObject[] allBookPages;
        private bool _isBookOpened = false;
        private Player _player;

        public void Construct(Player player)
        {
            _player = player;
        }
        
        private void Update()
        {
            OpenBook();
            CloseBook();
        }

        public void OpenBook()
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            if (Physics.Raycast(ray, out hit, 2f))
            {
                if ((_player.Book & (1 << hit.collider.gameObject.layer)) != 0)
                {
                    if (_isBookOpened == false)
                    {
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            bookMenu.SetActive(true);
                            _isBookOpened = true;
                            stopCamera?.Invoke();
                        }
                    }
                }
            }
        }

        public void CloseBook()
        {
            if (_isBookOpened)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    for (int i = 0; i < allBookPages.Length; i++)
                    {
                        allBookPages[i].SetActive(false);
                    }
                    _isBookOpened = false;
                    startCamera?.Invoke();
                }
            }
        }
    }
}
