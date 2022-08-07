using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
    private int health = 5;
    public string healthText;

    void Update()
    {
        healthText = "Health: "+ health;

        if(Input.GetKeyDown(KeyCode.Space)){
            health--;
        }
    }
}
