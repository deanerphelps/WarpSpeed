using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D body;
    public float speed = 1f;
    public float maxSpeed = 5;
    public float sprint = 0.01f;
    public Vector3 direction;

       
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();        
        speed = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        direction = new Vector3(Input.GetAxisRaw("Horizontal"),
        Input.GetAxisRaw("Vertical"), 0);

        transform.position = Vector2.MoveTowards(transform.position, transform.position
        + direction, speed * Time.deltaTime);

        if(direction.x != 0 || direction.y != 0)
        {
            speed = speed + sprint;
            if(speed >= maxSpeed)
            {
                speed = maxSpeed;
            }
        }
        else
        {
            speed = 0.5f;
        }
        if (Input.GetKey("left shift"))
        {
            sprint = 0.02f;
            maxSpeed = 7;
        }
        else
        {
            sprint = 0.01f;
            maxSpeed = 5;
        }
    }
}
