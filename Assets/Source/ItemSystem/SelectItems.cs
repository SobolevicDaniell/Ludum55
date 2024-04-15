using System;
using System.Collections.Generic;
using GoldSystem;
using ItemSystem.MaterialsView;
using TMPro;
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
        [SerializeField] private TextMeshProUGUI costOfMaterial;

        private int _cost;
        private Gold _gold;
        private MaterialObject.Materials _selectedMaterial;


        public void Construct(Gold gold)
        {
            _gold = gold;
        }
        private void Start()
        {
            foreach (MaterialView view in materialViews)
            {
                view.OnMaterialSelected += SelectItem;
            }

            costOfMaterial.text = "";
            buyButton.onClick.AddListener(BuyItem);
        }

        private void SelectItem(MaterialObject.Materials material , int cost)
        {
            _selectedMaterial = material;
            _cost = cost;
            costOfMaterial.text = _cost.ToString();
        }

        private void BuyItem()
        {
            if (_gold.GoldValue >= _cost)
            {
                Debug.Log($"You bought {_selectedMaterial.ToString()}");
                materialPrefab._material = _selectedMaterial;
                Instantiate(materialPrefab, buyPosition);
                _gold.AddScore(-_cost);
            }
        }
    }
}
