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

    private Transform player;
    [SerializeField]
    public float lineOfSight = 5f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;   
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, this.transform.position);
        if(distanceFromPlayer < lineOfSight)
        {
            if(Crate == true)
            {
                //Animate crate
            }
            else if(Hammer == true)
            {
                //Animate Hammer
            }
            else if(Hazard == true)
            {
                //Animate Hazard
            }
            else if(Wires == true)
            {
                //Animate Wires
            }
            else if(Wrench == true)
            {
                //Animate Wrench
            }
        }
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSight);
    }
}
