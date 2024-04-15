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

        public bool GetMaterialIcon(MaterialObject.Materials type, out Sprite icon, out string info)
        {
            icon = null;
            info = null;
            if (_materialViewDataSo)
            {
                foreach (var viewData in _materialViewDataSo.MaterialsViewDatas)
                {
                    if (viewData.MaterialsType == type)
                    {
                        icon = viewData.MaterialsIcon;
                        info = viewData.MaterialInfo;
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
