using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public Rigidbody2D rb;
    public Vector2 anchor;
    private bool isPressed = false;
    public float releaseTime;
    public float maxDistance;
    public float speedMultiplier;
    public static int BirdCount = 3;

    private void Start()
    {
        anchor = GetComponent<SpringJoint2D>().anchor;
    }
    private void Update()
    {
        if (isPressed)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector3.Distance(mousePosition, anchor)>maxDistance)
            {
                rb.position = anchor + (mousePosition - anchor).normalized * maxDistance;
            }
            else
            rb.position = mousePosition;
        }
    }
     void OnMouseDown() { 
    
        isPressed = true;
        rb.isKinematic = true;
    }
     void OnMouseUp()
    {
        isPressed = false;
        rb.isKinematic = false;
        rb.AddForce((anchor - rb.position).normalized * speedMultiplier,ForceMode2D.Impulse);
        StartCoroutine(Release());
        GetComponent<Animator>().Play(gameObject.name);
    }

    IEnumerator Release()
    {
        yield return new WaitForSeconds(releaseTime);
        GetComponent<SpringJoint2D>().enabled = false;
        this.enabled = false;
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(2f);
        BirdCount--;
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
 
        GetComponent<Animator>().enabled = false;
        StartCoroutine(Die());
    }
}
