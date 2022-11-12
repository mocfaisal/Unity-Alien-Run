using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bg_scroll : MonoBehaviour
{
    public float speedMoveToLeft = 0.05f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //transform.position -= new Vector3(6f * Time.deltaTime, 0, 0);
        obstacleJalan();
    }

    void obstacleJalan()
    {
        transform.position -= new Vector3(speedMoveToLeft * Time.deltaTime, 0, 0);

        if (transform.position.x <= -21f)
        {
            transform.position = new Vector3(21.05f, transform.position.y, 0f);
        }
    }
}
