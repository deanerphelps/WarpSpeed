using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public float lineOfSight;
    private Transform player;
    public Animator myAnim;

    // Start is called before the first frame update
    void Start()
    {
        lineOfSight = 3.15f;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        myAnim.SetBool("PlayerNear", false);
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if(distanceFromPlayer < lineOfSight)
        {
            // once in range of player, play new animation
            myAnim.SetBool("PlayerNear", true);
        }
    }
}
