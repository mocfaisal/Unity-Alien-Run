using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bg_controller : MonoBehaviour
{
    [SerializeField] private RawImage _img;
    //[SerializeField] private float _x, _y;
    [SerializeField] private float speedMoveToLeft = 0.05f;
    private float speedMoveToDown;

    // Start is called before the first frame update
    void Start()
    {
        speedMoveToDown = _img.uvRect.y;
    }

    // Update is called once per frame
    void Update()
    {
        _img.uvRect = new Rect(_img.uvRect.position + new Vector2(speedMoveToLeft, speedMoveToDown) * Time.deltaTime, _img.uvRect.size);
    }
}
