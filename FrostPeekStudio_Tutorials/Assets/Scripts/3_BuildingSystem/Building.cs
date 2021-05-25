using UnityEngine;

public class Building
{
    private readonly GameObject representation;

    public Building(Vector2Int gridPosition, BuildingType buildingType)
    {
        representation = GameObjectPool.instance.GetObject(0, Storage_Result.instance.meshPrefab, PlacingSystem.GetRealPosition(gridPosition), Vector3.zero);

        representation.GetComponent<MeshFilter>().mesh = Storage_Result.GetBuildingMesh(buildingType);
        representation.GetComponent<MeshRenderer>().material = Storage_Result.GetBuildingMaterial(buildingType);
    }
    public void Destroy()
    {
        GameObjectPool.instance.ReturnGameObject(0, representation);
    }
}
