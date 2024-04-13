using UnityEngine;

public class MaterialObject : MonoBehaviour
{
    [SerializeField] private Materials _material;
    [SerializeField] private Collider _table;
    [SerializeField] private GameObject Material_Object;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MaterialObject") && other.GetComponent<MaterialObject>() != null && other.GetComponent<MaterialObject>()._table == _table)
        {
            MaterialObject otherMaterialObject = other.GetComponent<MaterialObject>();

            if ((_material == Materials.sulfur && otherMaterialObject._material == Materials.coal) ||
                (_material == Materials.coal && otherMaterialObject._material == Materials.sulfur))
            {
                Destroy(gameObject);
                Destroy(other.gameObject);

                // Проверяем, является ли текущий объект sulfur, чтобы вызвать SpawnNewObject только один раз
                if (_material == Materials.sulfur)
                {
                    SpawnNewObject(Material_Object);
                }
            }
        }
    }


    private void SpawnNewObject(GameObject prefab)
    {
        GameObject newObject = Instantiate(prefab, transform.position, Quaternion.identity);
        MaterialObject newMaterialObject = newObject.GetComponent<MaterialObject>();
        newMaterialObject._material = Materials.gunpowder;
        newMaterialObject._table = _table;
        Destroy(gameObject);
    }


    public enum Materials
    {
        sulfur,
        coal,
        gunpowder
    }
}