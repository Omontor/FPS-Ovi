using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public int selectedWeapon = 0;
    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SelectWeapon()
    {
        int i = 0;
        foreach(Transform weapon in transform)
        {
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
    public void ChangeWeapon()
    {
        int previousSelectedWeapon = selectedWeapon;
        if (selectedWeapon >= transform.childCount - 1)
            selectedWeapon = 0;
        else
            selectedWeapon++;

        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }
    }
}
