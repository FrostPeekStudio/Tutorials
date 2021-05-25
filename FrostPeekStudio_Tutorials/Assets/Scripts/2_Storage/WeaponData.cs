using UnityEngine;

[CreateAssetMenu]
public class WeaponData : ScriptableObject
{
    public WeaponType type;
    public int damage;
    public float knockback;
    public string weaponName;

    [Header("UI")]
    public Sprite icon;
}
public enum WeaponType 
{
    shotgun,
    pistol
}
