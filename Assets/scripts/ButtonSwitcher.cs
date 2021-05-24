using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSwitcher : MonoBehaviour
{
    public int selectedButton = 0;
    void Start()
    {
        
    }
    public void SelectButton()
    {
        int i = 0;
        foreach (Transform button in transform)
        {
            if (i == selectedButton)
                button.gameObject.SetActive(true);
            else
                button.gameObject.SetActive(false);
            i++;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeButton()
    {
        int previousSelectedButton = selectedButton;
        if (selectedButton >= transform.childCount - 1)
            selectedButton = 0;
        else
            selectedButton++;

        if (previousSelectedButton != selectedButton)
        {
            SelectButton();
        }
    }
}
