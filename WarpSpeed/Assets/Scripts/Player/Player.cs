using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D body;
    public float speed = 1f;
    public float maxSpeed = 2.3f;
    public float sprint = 0.001f;
    public Vector3 direction;
    private Animator myAnim;
    public int health = 2;
    public bool alive = true;

    public float cooldown = 0.5f;
    public float lastDown;

    public bool Crate = false;
    public bool Hammer = false;
    public bool Hazard = false;
    public bool Wires = false;
    public bool Wrench = false;
       
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();        
        speed = 0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        CheckHealth();
        CollectedItems();
    }

    void Movement()
    {
        direction = new Vector3(Input.GetAxisRaw("Horizontal"),
        Input.GetAxisRaw("Vertical"), 0);

        transform.position = Vector2.MoveTowards(transform.position, transform.position
        + direction, speed * Time.deltaTime);

        myAnim.SetFloat("moveX", direction.x);
        myAnim.SetFloat("moveY", direction.y);

        if(Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            myAnim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            myAnim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
            GetComponent<AudioSource>().UnPause();
        }
        else
        {
            GetComponent<AudioSource>().Pause();
        }

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
            speed = 0.3f;
        }
        if (Input.GetKey("left shift"))
        {
            sprint = 0.01f;
        }
        else
        {
            sprint = 0.001f;
        }
    }

    void CheckHealth()
    {
        
        if(health <= 0)
        {
            alive = false;
            Debug.Log("Player Died");
            SceneManager.LoadScene("BadEnd");
        }
    }

    public void UpdateHealth()
    {
        if(Time.time-lastDown < cooldown){
            return;
        }
        lastDown = Time.time;
        health--;
    }

    void CollectedItems()
    {
        if(Crate && Hammer && Hazard && Wires && Wrench == true)
        {
            Debug.Log("You win!");
            SceneManager.LoadScene("GoodEnd");
        }
    }
}
