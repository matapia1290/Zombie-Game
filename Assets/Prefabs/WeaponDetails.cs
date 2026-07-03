using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WeaponDetails :ScriptableObject
{
    public GameObject weaponPrefab;
    public GameObject weaponAmmo;
    public string weaponName;
    public string weaponType;
    public bool isFirearm;
    public bool isMelee;

}
