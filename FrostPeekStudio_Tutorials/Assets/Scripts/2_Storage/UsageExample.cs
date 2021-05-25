using UnityEngine;

public class UsageExample : MonoBehaviour
{
    private void Start()
    {
        Debug.Log(Storage.GetWeaponName(WeaponType.shotgun));
        Debug.Log(Storage.GetWeaponName(WeaponType.pistol));
    }
}
