using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle_jalan : MonoBehaviour
{

    Rigidbody2D rb;
    public float moveSpeed = -5f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //rb.velocity = new Vector2(moveSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position -= new Vector3(6f * Time.deltaTime, 0, 0);


        rb.velocity = new Vector2(-5, rb.velocity.y);
    }


    public void GameOver()
    {
        Rigidbody2D rb = transform.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Destroy")
        {
            Destroy(gameObject);
        }
    }
}
