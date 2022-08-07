using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    private GameObject player;
    public float Cooldown = 5f;
    private float lastCooldown;

    // Start is called before the first frame update
    void Start()
    {
        lastCooldown = 0f;
        player = GameObject.FindGameObjectWithTag("Player");    
        Debug.Log(player.tag);
    }

    // Update is called once per frame
    void Update()
    {
        //if ChangeTime, calc new direction
        if(Time.time - lastCooldown > Cooldown)
        {
            lastCooldown = Time.time;
            //Attack();
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().UpdateHealth();
            other.gameObject.GetComponent<MonsterTarget>().speed = 0;
        }
    }
}
