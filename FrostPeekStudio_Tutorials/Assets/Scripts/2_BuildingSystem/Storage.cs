using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    private static readonly Dictionary<BuildingType, BuildingData> buildings = new Dictionary<BuildingType, BuildingData>();
    public static Storage instance;

    public GameObject meshPrefab;
    private void Awake()
    {
        instance = this;

        BuildingData[] buildingDatas = Resources.LoadAll<BuildingData>("Buildings");

        for(int i = 0; i < buildingDatas.Length; i++)
        {
            buildings.Add(buildingDatas[i].building, buildingDatas[i]);
        }
    }
    public static Mesh GetBuildingMesh(BuildingType building) => buildings[building].mesh;
    public static Material GetBuildingMaterial(BuildingType building) => buildings[building].material;
}
