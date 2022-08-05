using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D body;
    public float speed = 1f;
       
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();        
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"),
        Input.GetAxisRaw("Vertical"), 0);

        transform.position = Vector2.MoveTowards(transform.position, transform.position
        + direction, speed * Time.deltaTime);

        if (Input.GetKey("left shift"))
        {
            speed = 7;
        }
        else
        {
            speed = 5;
        }
    }

}
