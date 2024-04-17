using System.Collections.Generic;
using UnityEngine;

namespace ItemSystem.MaterialsDatas
{
    [CreateAssetMenu(menuName = "SO/New Material View Data", fileName = "NewMaterialViewData")]
    public class MaterialsDataSO : ScriptableObject
    {
        [field: SerializeField] public List<MaterialsData> MaterialsViewDatas { get; private set; }
    }
}
