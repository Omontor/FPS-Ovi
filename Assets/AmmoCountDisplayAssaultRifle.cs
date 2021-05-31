using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCountDisplayAssaultRifle : MonoBehaviour
{
    Text ammocountassaultrifleText;
    AssaultRifleRaycastShoot assaultRifleRaycastShoot;
    void Start()
    {
        ammocountassaultrifleText = GetComponent<Text>();
        assaultRifleRaycastShoot = FindObjectOfType<AssaultRifleRaycastShoot>();
    }

    // Update is called once per frame
    void Update()
    {
        ammocountassaultrifleText.text = assaultRifleRaycastShoot.GetCurrentAmmo().ToString();
    }
}
