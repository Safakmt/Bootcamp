using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBird : MonoBehaviour
{
    public float fieldOfImpact;
    public float force;
    public LayerMask LayerToHit;
    public GameObject Bombanim;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && GetComponent<SpringJoint2D>().enabled == false)
        {
            explode();
            Instantiate(Bombanim, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    public void explode()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, fieldOfImpact, LayerToHit);

        foreach (Collider2D item in objects)
        {
            Vector2 direction = item.transform.position - transform.position;

            item.GetComponent<Rigidbody2D>().AddForce(direction * force);
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fieldOfImpact);
    }

}
