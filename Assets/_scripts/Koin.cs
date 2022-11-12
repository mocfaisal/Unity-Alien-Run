using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Koin : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Koin")
        {
            Debug.Log("Kena");
            //    Destroy(gameObject);
            //    ScoreManager.instance.AddPoint();
            //    //Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), PointObstacle.GetComponent<Collider2D>());
        }
    }
}
