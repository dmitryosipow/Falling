using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float yPosition;
    float scale;
    GameManager gameManager;


    void Start()
    {
        yPosition = transform.position.y;
        scale = transform.localScale.x;
    }

    void Update()
    {
        Vector3 mousePixelPoint = Input.mousePosition;

        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePixelPoint);

        mouseWorldPosition.x = Mathf.Clamp(mouseWorldPosition.x, -7.4f, 7.4f);

        var pos = transform.position;
        /*if (pos.x < mouseWorldPosition.x)
        {
            transform.localScale = new Vector2(scale, transform.localScale.y);
        }
        else
        {
            transform.localScale = new Vector2(-scale, transform.localScale.y);
        }*/
        pos.x = mouseWorldPosition.x;

        transform.position = pos;

        
    }
}
