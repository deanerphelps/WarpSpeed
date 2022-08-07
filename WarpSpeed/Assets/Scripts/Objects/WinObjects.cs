using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinObjects : MonoBehaviour
{
    public bool Crate = false;
    public bool Hammer = false;
    public bool Hazard = false;
    public bool Wires = false;
    public bool Wrench = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(Crate == true)
            {
                other.gameObject.GetComponent<Player>().Crate = true;
            }
            else if(Hammer == true)
            {
                other.gameObject.GetComponent<Player>().Hammer = true;
            }
            else if(Hazard == true)
            {
                other.gameObject.GetComponent<Player>().Hazard = true;
            }
            else if(Wires == true)
            {
                other.gameObject.GetComponent<Player>().Wires = true;
            }
            else if(Wrench == true)
            {
                other.gameObject.GetComponent<Player>().Wrench = true;
            }
        }
    }
}
