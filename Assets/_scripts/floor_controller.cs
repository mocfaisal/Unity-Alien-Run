using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floor_controller : MonoBehaviour
{
    public karakter_controller karakterController;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        obstacleJalan();
    }

    void obstacleJalan()
    {
        transform.position -= new Vector3(6 * Time.deltaTime, 0, 0);

        if (transform.position.x <= -21.27)
        {
            transform.position = new Vector3(21.27f, transform.position.y, 0f);
        }
    }
}
