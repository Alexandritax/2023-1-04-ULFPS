using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Assets/Weapon-Data")]
public class WeaponDataSO : ScriptableObject
{
    public float Damage;
    public float shootDistance;
    public GameObject GunSmoke;
    public GameObject weaponPrefab;
}
