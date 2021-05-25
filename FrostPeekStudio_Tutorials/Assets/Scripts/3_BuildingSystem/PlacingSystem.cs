using System.Collections.Generic;
using UnityEngine;

public class PlacingSystem : MonoBehaviour
{
    [SerializeField] List<BuildingType> supportedBuildings;

    public const float groundHeight = 0f;
    public const float gridSize = 15f;

    private Plane floorPlane = new Plane(Vector3.up, new Vector3(0f, groundHeight, 0f));

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            PlaceBuilding();
        }
        else if (Input.GetMouseButtonUp(1))
        {
            DestroyBuilding();
        }
    }
    private void PlaceBuilding()
    {
        Map.instance.PlaceBuilding(GetMouseGridProjection(), GetRandomBuilding());
    }
    private void DestroyBuilding()
    {
        Map.instance.DestroyBuilding(GetMouseGridProjection());
    }
    private Vector2Int GetMouseGridProjection()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        floorPlane.Raycast(ray, out float projectionDistance);
        Vector3 hitPoint = ray.GetPoint(projectionDistance);

        return GetGridPosition(hitPoint);
    }
    private BuildingType GetRandomBuilding() => supportedBuildings[Random.Range(0, supportedBuildings.Count)];
    public static Vector2Int GetGridPosition(Vector3 position) => new Vector2Int(Mathf.FloorToInt(position.x / gridSize), Mathf.FloorToInt(position.z / gridSize));
    public static Vector3 GetRealPosition(Vector2Int coord) => new Vector3(coord.x * gridSize + gridSize / 2, groundHeight, coord.y * gridSize + gridSize / 2);
}
