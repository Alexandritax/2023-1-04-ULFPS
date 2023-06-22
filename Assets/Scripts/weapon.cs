using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public WeaponDataSO WeaponData;
    private GameObject weaponObject;

    private void Start(){
        weaponObject = Instantiate(WeaponData.weaponPrefab, transform);
    }


}
