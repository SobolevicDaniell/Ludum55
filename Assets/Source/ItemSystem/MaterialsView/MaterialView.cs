using System;
using UnityEngine;
using UnityEngine.UI;

namespace ItemSystem.MaterialsView
{
    [RequireComponent(typeof(Image))]
    public class MaterialView : MonoBehaviour
    {
        [SerializeField] private MaterialObject.Materials materialType;
        private Image _icon;

        private void Start()
        {
            _icon = GetComponent<Image>();
            if (MaterialsViewService.Instance.GetMaterialIcon(materialType,
                    out Sprite processIcon))
            {
                _icon.sprite = processIcon;
                Debug.Log("E");
            }
        }
    }
}
