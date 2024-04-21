using System;
using UnityEngine;

public class HandsDirection : MonoBehaviour
{
    private Vector2 mousePosition;
    public static float angle;
    static public bool Fliped;
    static public bool GunFlipped;

    private void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;

        if (Fliped)
        {
            transform.localScale = new Vector3(-Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);

            if (angle < 90 ^ angle > -90)
            {
                transform.localScale = new Vector3(transform.localScale.x, -Math.Abs(transform.localScale.y), 0);
                GunFlipped = true;
            }
            else
            {
                transform.localScale = new Vector3(transform.localScale.x, Math.Abs(transform.localScale.y), 0);
                GunFlipped = false;
            }
        }
        else
        {
            transform.localScale = new Vector3(Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);

            if (angle > 90 ^ angle < -90)
            {
                transform.localScale = new Vector3(transform.localScale.x, -Math.Abs(transform.localScale.y), 0);
                GunFlipped = false;
            }
            else
            {
                transform.localScale = new Vector3(transform.localScale.x, Math.Abs(transform.localScale.y), 0);
                GunFlipped = true;
            }
        }


        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
