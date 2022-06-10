using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject deathAnim;
    public float health = 8;

    private void Update()
    {
        if (health <= 0)
        {
            Instantiate(deathAnim,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.rigidbody.tag == "Player")
        {
            Instantiate(deathAnim, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if (collision.rigidbody.tag == "Block")
        {
            health -= collision.rigidbody.velocity.magnitude;
        }
    }
}
