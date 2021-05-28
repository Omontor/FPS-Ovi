using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MachineGunPickup : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject weaponSwitchButton;
    AudioSource pickedUpWeapon;
    void Start()
    {
        pickedUpWeapon = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("You picked up the Gun");
            weaponSwitchButton.SetActive(true);
            pickedUpWeapon.Play();
            Destroy(gameObject,1);
        }
        
    }
}
