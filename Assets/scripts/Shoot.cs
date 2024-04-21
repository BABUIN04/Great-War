using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private float HorizontalCor;
    [SerializeField] private float VerticalCor;
    public GameObject bulletPrefab;
    private GameObject bullet;

    public void shoot(float direction)
    {
        bullet = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, direction));

        if ((HandsDirection.GunFlipped && HandsDirection.Fliped) || (!HandsDirection.GunFlipped && !HandsDirection.Fliped))
            VerticalCor = -Mathf.Abs(VerticalCor);
        else
            VerticalCor = Mathf.Abs(VerticalCor);

        bullet.transform.Translate(HorizontalCor, VerticalCor, 0);
        Debug.Log("GunFlipped");
        Debug.Log(HandsDirection.GunFlipped);

        Debug.Log("Flipped");
        Debug.Log(HandsDirection.Fliped);

        Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), transform.parent.parent.GetComponent<Collider2D>());
    }
}
