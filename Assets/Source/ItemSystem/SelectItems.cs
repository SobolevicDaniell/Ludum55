using System;
using System.Collections.Generic;
using ItemSystem.MaterialsView;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace ItemSystem
{
    public class SelectItems : MonoBehaviour
    {
        [SerializeField] private List<MaterialView> materialViews;
        [SerializeField] private Button buyButton;
        [SerializeField] private MaterialObject materialPrefab;
        [SerializeField] private Transform buyPosition;
        private MaterialObject.Materials _selectedMaterial;
        
        private void Start()
        {
            foreach (MaterialView view in materialViews)
            {
                view.OnMaterialSelected += SelectItem;
            }
            buyButton.onClick.AddListener(BuyItem);
        }

        private void SelectItem(MaterialObject.Materials material)
        {
            _selectedMaterial = material;
        }

        private void BuyItem()
        {
            Debug.Log($"You bought {_selectedMaterial.ToString()}");
            materialPrefab._material = _selectedMaterial;
            Instantiate(materialPrefab, buyPosition);
        }
    }
}
