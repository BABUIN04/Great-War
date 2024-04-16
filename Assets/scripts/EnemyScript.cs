using UnityEngine;

public class EnemyScript : MonoBehaviour, IDamagable
{
    [SerializeField]private int Health;

    public void OnDamage(int damage)
    {
        Health -= damage;
    }
    private void Update()
    {
        if (Health <= 0)
            Destroy(gameObject);
    }
}
