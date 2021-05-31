using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstObjectiveTextBox : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject textBox;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ByeText()
    {
        Debug.Log("weapons have been picked up.... destroying UI text");
        Destroy(textBox);
    }
}
