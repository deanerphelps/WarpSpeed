using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinObjects : MonoBehaviour
{
    public Animator animator;
    
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
                animator.SetBool("Near", true);
            }
            else if(Hammer == true)
            {
                //Animate Hammer
                animator.SetBool("Near", true);
            }
            else if(Hazard == true)
            {
                //Animate Hazard
                animator.SetBool("Near", true);
            }
            else if(Wires == true)
            {
                //Animate Wires
                animator.SetBool("Near", true);
            }
            else if(Wrench == true)
            {
                //Animate Wrench
                animator.SetBool("Near", true);
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
                Destroy(this.gameObject);
            }
            else if(Hammer == true)
            {
                other.gameObject.GetComponent<Player>().Hammer = true;
                Destroy(this.gameObject);
            }
            else if(Hazard == true)
            {
                other.gameObject.GetComponent<Player>().Hazard = true;
                Destroy(this.gameObject);
            }
            else if(Wires == true)
            {
                other.gameObject.GetComponent<Player>().Wires = true;
                Destroy(this.gameObject);
            }
            else if(Wrench == true)
            {
                other.gameObject.GetComponent<Player>().Wrench = true;
                Destroy(this.gameObject);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSight);
    }
}
