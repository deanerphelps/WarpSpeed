using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTarget : MonoBehaviour
{
    [SerializeField]
    public float speed;
    [SerializeField]
    public float lineOfSight;
    private Transform player;
    private Animator myAnim;

    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;    
    }

    // Update is called once per frame
    void Update()
    {
        myAnim.SetBool("isMoving", true);
        myAnim.SetFloat("moveX", (player.position.x - transform.position.x));
        myAnim.SetFloat("moveY", (player.position.y - transform.position.y));
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if(distanceFromPlayer < lineOfSight)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position,
            speed * Time.deltaTime );
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().UpdateHealth();
            //Debug.Log("Hit");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSight);
    }
}
