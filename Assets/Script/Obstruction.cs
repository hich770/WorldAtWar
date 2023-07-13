using UnityEngine;

public class Obstruction : MonoBehaviour
{
    public int health;
    public float speed;
    public GameObject effect;
    public float effectOffset = 0.5f;

    private void Update()
    {
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
    public void TakeDamage(int damage, Vector3 hitPosition)
    {
        health -= damage;
        Instantiate(effect, hitPosition + new Vector3(effectOffset, 0, 0), Quaternion.identity);
    }
}