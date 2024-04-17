using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ItemSystem.MaterialsView
{
    [RequireComponent(typeof(Image))]
    public class MaterialView : MonoBehaviour
    {
        public event Action<MaterialObject.Materials, int> OnMaterialSelected; 
        [SerializeField] private MaterialObject.Materials materialType;
        [SerializeField] private Image mainImage;
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private Button thisButton;
        private string _info;
        private Image _icon;
        private int _cost;

        private void Start()
        {
            text.text = "";
            Color newColor = new Color(0, 0, 0, 0);
            mainImage.color = newColor;
            _icon = GetComponent<Image>();
            if (MaterialsViewService.Instance.GetMaterialIcon(materialType,
                    out Sprite processIcon, out _info, out _cost))
            {
                _icon.sprite = processIcon;
            }
            thisButton.onClick.AddListener(ChangeMainImg);
        }

        private void ChangeMainImg()
        {
            Color newColor = new Color(1, 1, 1, 1);
            mainImage.color = newColor;
            if (MaterialsViewService.Instance.GetMaterialIcon(materialType,
                    out Sprite processIcon, out _info, out _cost))
            {
                mainImage.sprite = processIcon;
                text.text = _info;
                OnMaterialSelected?.Invoke(materialType, _cost);
            }
        }
    }
}
