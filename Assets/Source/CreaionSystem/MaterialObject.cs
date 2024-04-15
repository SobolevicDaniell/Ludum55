using UnityEngine;

public class MaterialObject : MonoBehaviour
{
    [SerializeField] private Materials _material;
    [SerializeField] private GameObject _newObject;

    [SerializeField] private GameObject _sulfur;
    [SerializeField] private GameObject _coal;
    [SerializeField] private GameObject _mercury;
    [SerializeField] private GameObject _carrot;
    [SerializeField] private GameObject _destructive_mix;
    [SerializeField] private GameObject _leaf_tree_life_Prefab;
    [SerializeField] private GameObject _heart_black_dragon;
    [SerializeField] private GameObject _explosive_potion;
    [SerializeField] private GameObject _tornado_potion;
    [SerializeField] private GameObject _gap_potion;
    [SerializeField] private GameObject _blue_flame_potion;
    [SerializeField] private GameObject _infernal_potion;
    [SerializeField] private GameObject _summoning_potion;

    private Collider _table;
    private bool _newObjectSpawned = false;

    private void Start()
    {
        _table = GameObject.FindWithTag("Table").GetComponent<Collider>();

        MeshFilter meshFilter = GetComponent<MeshFilter>();
        MeshCollider meshCollider = GetComponent<MeshCollider>();

        if (meshFilter != null && meshCollider != null)
        {
            GameObject prefab = GetPrefabByMaterial(_material); // Получаем соответствующий префаб по материалу
            if (prefab != null)
            {
                // Получаем меш и текстуру из префаба
                Mesh newMesh = prefab.GetComponent<MeshFilter>().sharedMesh;
                Texture newTexture = prefab.GetComponent<Renderer>().sharedMaterial.mainTexture;

                // Устанавливаем меш и текстуру на создаваемый объект
                meshFilter.mesh = newMesh;
                meshCollider.sharedMesh = newMesh;
                GetComponent<Renderer>().material.mainTexture = newTexture; // Устанавливаем текстуру

                // Регулировка размера объекта в зависимости от типа материала
                AdjustSize(prefab);
            }
            else
            {
                Debug.LogWarning("Prefab for material " + _material.ToString() + " is missing.");
            }
        }
        else
        {
            Debug.LogWarning("MeshFilter or MeshCollider component is missing. Unable to change mesh or collider.");
        }
    }

    private GameObject GetPrefabByMaterial(Materials material)
    {
        switch (material)
        {
            case Materials.sulfur:
                return _sulfur;
            case Materials.coal:
                return _coal;
            case Materials.mercury:
                return _mercury;
            case Materials.carrot:
                return _carrot;
            case Materials.destructive_mix:
                return _destructive_mix;
            case Materials.leaf_tree_life:
                return _leaf_tree_life_Prefab;
            case Materials.heart_black_dragon:
                return _heart_black_dragon;
            case Materials.explosive_potion:
                return _explosive_potion;
            case Materials.tornado_potion:
                return _tornado_potion;
            case Materials.gap_potion:
                return _gap_potion;
            case Materials.blue_flame_potion:
                return _blue_flame_potion;
            case Materials.infernal_potion:
                return _infernal_potion;
            case Materials.summoning_potion:
                return _summoning_potion;
            default:
                return null;
        }
    }

    private void AdjustSize(GameObject prefab)
    {
        // Регулировка размера объекта в зависимости от типа материала
        if (prefab == _sulfur || prefab == _coal)
        {
            transform.localScale = new Vector3(18f, 18f, 18f);
        }
        else if (prefab == _leaf_tree_life_Prefab)
        {
            transform.localScale = new Vector3(190f, 190f, 190f);
        }
        else if (prefab == _heart_black_dragon)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (prefab == _mercury)
        {
            transform.localScale = new Vector3(2, 2, 2);
        }
        else if (prefab == _carrot)
        {
            transform.localScale = new Vector3(100, 100, 100);
        }
        
        // Добавьте аналогичные условия для остальных префабов
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
