using UnityEngine;

[CreateAssetMenu]
public class BuildingData: ScriptableObject
{
    public BuildingType building;

    public Mesh mesh;
    public Material material;
    //[Header("UI")]
}
public enum BuildingType
{
    house,
    mansion
}
