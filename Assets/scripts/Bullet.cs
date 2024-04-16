using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float lifeTime;
    [SerializeField] int damage;

    private void FixedUpdate()
    {
        transform.Translate(speed, 0, 0);
    }

    private void Start()
    {
        Invoke("Delete", lifeTime);
    }

    void Delete()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDamagable Idamagable = collision.gameObject.GetComponent<IDamagable>();
        if (Idamagable != null)
            Idamagable.OnDamage(damage);
        Delete();
    }
}
