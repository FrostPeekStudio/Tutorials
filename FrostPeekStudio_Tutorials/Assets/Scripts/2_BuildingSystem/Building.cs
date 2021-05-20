using UnityEngine;

public class Building
{
    private readonly GameObject representation;

    public Building(Vector2Int gridPosition, BuildingType buildingType)
    {
        representation = GameObjectPool_Result.instance.GetObject(0, Storage.instance.meshPrefab, PlacingSystem.GetRealPosition(gridPosition), Vector3.zero);

        representation.GetComponent<MeshFilter>().mesh = Storage.GetBuildingMesh(buildingType);
        representation.GetComponent<MeshRenderer>().material = Storage.GetBuildingMaterial(buildingType);
    }
    public void Destroy()
    {
        GameObjectPool_Result.instance.ReturnGameObject(0, representation);
    }
}
