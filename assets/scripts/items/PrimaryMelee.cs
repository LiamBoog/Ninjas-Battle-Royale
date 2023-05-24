using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryMelee : MonoBehaviour
{
    public enum WeaponEnum
    {
        Katana,
        Bo,
    }

    public WeaponEnum weaponName;
    int damage;

    private string GetFileName()
    {
        switch (weaponName)
        {
            case WeaponEnum.Katana:
                return "katana";
            case WeaponEnum.Bo:
                return "bo";
            default:
                return null;
        }
    }


    void Awake()
    {
        //Initializing weapon variables
        switch (weaponName)
        {
            case WeaponEnum.Katana:
                damage = 3;
                break;

            case WeaponEnum.Bo:
                damage = 2;
                break;
        }
    }
}


