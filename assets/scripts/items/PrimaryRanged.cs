using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryRanged : MonoBehaviour
{
    public enum WeaponEnum
    {
        Bow,
    }

    public WeaponEnum weaponName;
    //GameObject projectileObject;
    int damage;

    private string GetFileName()
    {
        switch (weaponName)
        {
            case WeaponEnum.Bow:
                return "bow";
            default:
                return null;
        }
    }

    void Awake()
    {
        //Initializing weapon variables
        switch (weaponName)
        {
            case WeaponEnum.Bow:
                //projectileObject = Resources.Load<GameObject>("ItemPrefabs/arrow");
                damage = 3;
                break;
        }
    }

    public void Shoot(Vector3 shootFrom, float forceMultiplier = 1)
    {
        //Projectile projectileScript = projectileObject.GetComponent<Projectile>();
        //projectileScript.originPosition = shootFrom;

        switch (weaponName)
        {
            case WeaponEnum.Bow:
                //projectileScript.speed = 15;
                //Instantiate(projectileObject, shootFrom, Quaternion.identity);
                break;
        }
    }
}
