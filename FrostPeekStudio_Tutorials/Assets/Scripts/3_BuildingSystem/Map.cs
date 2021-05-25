using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public static Map instance;

    private readonly Dictionary<Vector2Int, Building> buildings = new Dictionary<Vector2Int, Building>();

    private void Awake() => instance = this;

    public void PlaceBuilding(Vector2Int coord, BuildingType building)
    {
        if (buildings.ContainsKey(coord) == false)
        {    
            buildings.Add(coord, new Building(coord, building));
        }
    }
    public void DestroyBuilding(Vector2Int coord)
    {
        if (buildings.TryGetValue(coord, out Building building))
        {
            building.Destroy();
            buildings.Remove(coord);
        }
    }
}
