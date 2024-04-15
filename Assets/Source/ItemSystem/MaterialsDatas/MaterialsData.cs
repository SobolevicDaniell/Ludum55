using System;
using UnityEngine;

namespace ItemSystem.MaterialsDatas
{
    [Serializable]
    public class MaterialsData 
    {
        [field: SerializeField] public MaterialObject.Materials MaterialsType {get; private set;}
        [field: SerializeField] public Sprite MaterialsIcon {get; private set;}
        [field: SerializeField] public string MaterialInfo { get; private set;}
    }
}
