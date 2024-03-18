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
            angle += 180;

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
