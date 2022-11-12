using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour
{

    public GameObject obstacleSpawner;
    public GameObject karakterObj;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        obstacleSpawner.GetComponent<obstacle_spawner>().StartSpawning();
    }
}
