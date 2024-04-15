using ItemSystem.MaterialsDatas;
using UnityEngine;

namespace ItemSystem.MaterialsView
{
    public class MaterialsViewService 
    {
        private static MaterialsViewService instance;
        private MaterialsDataSO _materialViewDataSo = 
            Resources.Load("MaterialsView" ) as MaterialsDataSO;
        
        public static MaterialsViewService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MaterialsViewService();
                }

                return instance;
            }
        }

        public bool GetMaterialIcon(MaterialObject.Materials type, out Sprite icon, out string info, out int cost)
        {
            icon = null;
            info = null;
            cost = 0;
            if (_materialViewDataSo)
            {
                foreach (var viewData in _materialViewDataSo.MaterialsViewDatas)
                {
                    if (viewData.MaterialsType == type)
                    {
                        icon = viewData.MaterialsIcon;
                        info = viewData.MaterialInfo;
                        cost = viewData.MaterialCost;
                        return true;
                    }
                }
            }
            return false;
        }
        public bool GetDecayResourceIcon(MaterialObject.Materials type, out Sprite icon)
        {
            icon = null;
            if (_materialViewDataSo)
            {
                foreach (var viewData in _materialViewDataSo.MaterialsViewDatas)
                {
                    if (viewData.MaterialsType == type)
                    {
                        icon = viewData.MaterialsIcon;
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
