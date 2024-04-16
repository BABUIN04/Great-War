using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    private GameObject bullet;

    public void shoot(float direction, Vector3 position)
    {
        bullet = Instantiate(bulletPrefab, position, Quaternion.Euler(0, 0, direction));
        Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
}
