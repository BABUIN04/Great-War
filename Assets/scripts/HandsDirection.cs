using System;
using UnityEngine;

public class HandsDirection : MonoBehaviour
{
    private Vector2 mousePosition;
    private float angle;
    static public bool Fliped;

    private void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;

        if (Fliped)
        {
            transform.localScale = new Vector3(-Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            if (angle < 90 ^ angle > -90)
                GetComponent<SpriteRenderer>().flipY = true;
            else
                GetComponent<SpriteRenderer>().flipY = false;
        }
        else
        {
            transform.localScale = new Vector3(Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);

            if (angle > 90 ^ angle < -90)
                GetComponent<SpriteRenderer>().flipY = true;
            else
                GetComponent<SpriteRenderer>().flipY = false;
        }


        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
