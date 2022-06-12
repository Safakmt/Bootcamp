using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableBlock : MonoBehaviour
{
    private List<Vector2> physicShape1 = new List<Vector2>();
    private List<Vector2> physicShape2 = new List<Vector2>();
    private PolygonCollider2D currentCollider;
    public Sprite[] sprites = new Sprite[2];
    public int blockHealth;
    private float currentHealth;

    private void Start()
    {
        currentCollider = GetComponent<PolygonCollider2D>();
        currentHealth = blockHealth;
        sprites[0].GetPhysicsShape(0, physicShape1);
        sprites[1].GetPhysicsShape(0, physicShape2);
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
        else if (currentHealth < blockHealth / 2.2f)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
            currentCollider.SetPath(0, physicShape2);

        }
        else if (currentHealth < blockHealth / 1.4f)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
            currentCollider.SetPath(0, physicShape1);
        }
    }
    private void LateUpdate()
    {
     
         if (currentHealth < blockHealth / 2.2f)
        {
            currentCollider.SetPath(0, physicShape2);

        }
        else if (currentHealth < blockHealth / 1.4f)
        {
            currentCollider.SetPath(0, physicShape1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        float crashMagnitude = collision.rigidbody.velocity.magnitude;
        if (collision.collider.tag == "Player")
        {
                currentHealth -= crashMagnitude;
        }
        if (collision.collider.tag == "Block" && collision.rigidbody.velocity.magnitude > 1.5f)
        {
                currentHealth -= crashMagnitude;
        }
    }
}
