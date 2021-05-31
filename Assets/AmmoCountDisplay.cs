using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCountDisplay : MonoBehaviour
{
    Text ammocountText;
    PistolRaycastShoot pistolRaycastShoot;
    void Start()
    {
        ammocountText = GetComponent<Text>();
        pistolRaycastShoot = FindObjectOfType<PistolRaycastShoot>();
    }

    // Update is called once per frame
    void Update()
    {
        ammocountText.text = pistolRaycastShoot.GetCurrentAmmo().ToString();
    }
}
