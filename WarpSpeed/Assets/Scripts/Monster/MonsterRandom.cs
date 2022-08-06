using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRandom : MonoBehaviour
{
    private float lastDirectionChangeTime;
    private float directionChangeTime = 3f;
    public float monsterVelocity = 0.35f;
    private Vector2 moveDirection; 
    private Vector2 movePerSecond;

    // Start is called before the first frame update
    void Start()
    {
        lastDirectionChangeTime = 0f;
        calcNewMove();
    }

    // Update is called once per frame
    void Update()
    {
        //if ChangeTime, calc new direction
        if(Time.time - lastDirectionChangeTime > directionChangeTime)
        {
            lastDirectionChangeTime = Time.time;
            calcNewMove();
        }

        //move enemy
        transform.position = new Vector2(
            transform.position.x + (movePerSecond.x * Time.deltaTime),
            transform.position.y + (movePerSecond.y * Time.deltaTime)
        );
    }

    void calcNewMove()
    {
            //Random direction with mag of 1, then multiply by velocity
            moveDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
            movePerSecond = moveDirection * monsterVelocity;
    }
}
