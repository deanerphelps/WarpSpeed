using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D body;
    public float speed = 1f;
    public float maxSpeed = 5;
    public float sprintSpeed = 5;
    public float maxSprint = 7;
    public float value;
    public float timeToMax = 1;

       
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();        
        speed = 2;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement3()
    {
        
    }


    void Movement2()
    {
        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"),
        Input.GetAxisRaw("Vertical"), 0);

        transform.position = Vector2.MoveTowards(transform.position, transform.position
        + direction, speed * Time.deltaTime);

        float moveTowards = 0;
        float changeRatePerSecond = 1 / timeToMax * Time.deltaTime;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            moveTowards = 1.0f;
        }
        else
        {
            moveTowards = 0f;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            changeRatePerSecond *=2;
        }
        value = Mathf.MoveTowards (value, moveTowards, changeRatePerSecond);
        speed = speed + value;
        speed = 2;
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
