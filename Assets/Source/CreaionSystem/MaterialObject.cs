using System;
using UnityEngine;

public class MaterialObject : MonoBehaviour
{
    [SerializeField] private Materials _material;
    [SerializeField] private GameObject _newObject;
    [SerializeField] private GameObject _leaf_tree_life_Prefab;
    
    private Collider _table;
    private bool _newObjectSpawned = false;

    private void Start()
    {
        _table = GameObject.FindWithTag("Table").GetComponent<Collider>();
        if (_material == Materials.leaf_tree_life)
        {
            Debug.Log("Ok");
            MeshFilter meshFilter = GetComponent<MeshFilter>();
            MeshCollider meshCollider = GetComponent<MeshCollider>();

            meshFilter.mesh = _leaf_tree_life_Prefab.GetComponent<Mesh>();
            meshCollider = _leaf_tree_life_Prefab.GetComponent<MeshCollider>();
        }
    }

    

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("MaterialObject") &&
            other.gameObject.GetComponent<MaterialObject>() != null &&
            _table.bounds.Contains(other.gameObject.transform.position) &&
            other.gameObject.GetComponent<MaterialObject>()._table == _table)
        {
            MaterialObject otherMaterialObject = other.gameObject.GetComponent<MaterialObject>();
            if (!_newObjectSpawned && !otherMaterialObject._newObjectSpawned)
            {
                if (CanCombine(_material, otherMaterialObject._material))
                {
                    CreateNewObject(otherMaterialObject);
                    _newObjectSpawned = true;
                    otherMaterialObject._newObjectSpawned = true;
                
                    Destroy(gameObject);
                    Destroy(other.gameObject);
                }
            }
        }
    }

    private bool CanCombine(Materials material1, Materials material2)
    {
        return (material1 == Materials.sulfur && material2 == Materials.coal) ||
               (material1 == Materials.coal && material2 == Materials.sulfur) ||
               (material1 == Materials.mercury && material2 == Materials.carrot) ||
               (material1 == Materials.carrot && material2 == Materials.mercury) ||
               (material1 == Materials.destructive_mix && material2 == Materials.leaf_tree_life) ||
               (material1 == Materials.leaf_tree_life && material2 == Materials.destructive_mix) ||
               (material1 == Materials.explosive_potion && material2 == Materials.fire_poison_potion) ||
               (material1 == Materials.fire_poison_potion && material2 == Materials.explosive_potion) ||
               (material1 == Materials.tornado_potion && material2 == Materials.fire_poison_potion) ||
               (material1 == Materials.fire_poison_potion && material2 == Materials.tornado_potion) ||
               (material1 == Materials.gap_potion && material2 == Materials.blue_flame_potion) ||
               (material1 == Materials.blue_flame_potion && material2 == Materials.gap_potion) ||
               (material1 == Materials.infernal_potion && material2 == Materials.heart_black_dragon) ||
               (material1 == Materials.heart_black_dragon && material2 == Materials.infernal_potion);
    }

    private void CreateNewObject(MaterialObject otherMaterialObject)
    {
        Destroy(otherMaterialObject.gameObject);
        SpawnNewObject(_newObject, GetCombinedMaterial(_material, otherMaterialObject._material));
    }

    private void SpawnNewObject(GameObject prefab, Materials materials)
    {
        GameObject newObject = Instantiate(prefab, transform.position, Quaternion.identity);
        MaterialObject newMaterialObject = newObject.GetComponent<MaterialObject>();
        newMaterialObject._material = materials;
        newMaterialObject._table = _table;
        newMaterialObject._leaf_tree_life_Prefab = _leaf_tree_life_Prefab;
    }

    private Materials GetCombinedMaterial(Materials material1, Materials material2)
    {
        if ((material1 == Materials.sulfur && material2 == Materials.coal) ||
            (material1 == Materials.coal && material2 == Materials.sulfur))
        {
            return Materials.explosive_potion;
        }
        else if ((material1 == Materials.mercury && material2 == Materials.carrot) ||
                 (material1 == Materials.carrot && material2 == Materials.mercury))
        {
            return Materials.fire_poison_potion;
        }
        else if ((material1 == Materials.destructive_mix && material2 == Materials.leaf_tree_life) ||
                 (material1 == Materials.leaf_tree_life && material2 == Materials.destructive_mix))
        {
            return Materials.tornado_potion;
        }
        else if ((material1 == Materials.explosive_potion && material2 == Materials.fire_poison_potion) ||
                 (material1 == Materials.fire_poison_potion && material2 == Materials.explosive_potion))
        {
            return Materials.gap_potion;
        }
        else if ((material1 == Materials.tornado_potion && material2 == Materials.fire_poison_potion) ||
                 (material1 == Materials.fire_poison_potion && material2 == Materials.tornado_potion))
        {
            return Materials.blue_flame_potion;
        }
        else if ((material1 == Materials.gap_potion && material2 == Materials.blue_flame_potion) ||
                 (material1 == Materials.blue_flame_potion && material2 == Materials.gap_potion))
        {
            return Materials.infernal_potion;
        }
        else if ((material1 == Materials.infernal_potion && material2 == Materials.heart_black_dragon) ||
                 (material1 == Materials.heart_black_dragon && material2 == Materials.infernal_potion))
        {
            return Materials.summoning_potion;
        }
        
        return Materials.sulfur;
        
    }

    public enum Materials
    {
        sulfur,
        coal,
        mercury,
        carrot,
        destructive_mix,
        leaf_tree_life,
        heart_black_dragon,
        explosive_potion,
        fire_poison_potion,
        tornado_potion,
        gap_potion,
        blue_flame_potion,
        infernal_potion,
        summoning_potion
    }
}
