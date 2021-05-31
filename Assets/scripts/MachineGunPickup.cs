using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MachineGunPickup : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject weaponSwitchButton;
    AudioSource pickedUpWeapon;
    FirstObjectiveTextBox firstObjectiveTextBox;
    void Start()
    {
        pickedUpWeapon = GetComponent<AudioSource>();
        firstObjectiveTextBox =FindObjectOfType<FirstObjectiveTextBox>();
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
            firstObjectiveTextBox.ByeText();
            
            Destroy(gameObject,.5f);
            
        }
        
    }

}
