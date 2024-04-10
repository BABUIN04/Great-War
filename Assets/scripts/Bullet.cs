using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float lifeTime;
    private Collider collider;

    private void FixedUpdate()
    {
        transform.Translate(speed, 0, 0);
    }

    private void Start()
    {
        transform.Translate(1.2f, 0, 0);
        Invoke("Delete", lifeTime);
    }

    void Delete()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Delete();
    }
}
