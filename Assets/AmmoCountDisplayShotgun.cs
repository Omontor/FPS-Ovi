using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCountDisplayShotgun : MonoBehaviour
{
    Text ammocountShotgunText;
    ShotgunRaycastShoot shotgunRaycastShoot;
    void Start()
    {
        ammocountShotgunText = GetComponent<Text>();
        shotgunRaycastShoot = FindObjectOfType<ShotgunRaycastShoot>();
    }

    // Update is called once per frame
    void Update()
    {
        ammocountShotgunText.text = shotgunRaycastShoot.GetCurrentAmmo().ToString();
    }
}
