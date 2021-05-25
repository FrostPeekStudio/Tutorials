using System.Collections.Generic;
using UnityEngine;


public class Storage : MonoBehaviour
{
    public static readonly Dictionary<WeaponType, WeaponData> weapons = new Dictionary<WeaponType, WeaponData>();

    private void Awake()
    {
        WeaponData[] weaponDatas = Resources.LoadAll<WeaponData>("Weapons");

        for (int i = 0; i < weaponDatas.Length; i++) 
        {
            weapons.Add(weaponDatas[i].type, weaponDatas[i]);
        }
    }
    public static int GetWeaponDamage(WeaponType weapon) => weapons[weapon].damage;
    public static float GetWeaponKnockBack(WeaponType weapon) => weapons[weapon].knockback;
    public static string GetWeaponName(WeaponType weapon) => weapons[weapon].name;
    public static Sprite GetWeaponIcon(WeaponType weapon) => weapons[weapon].icon;
}
