using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public int health;
    public float speed;
    public Vector2 direction = Vector2.right;
    public GameObject effect;
    public float effectOffset = 0.5f;
    public float damage;
    private Player player;

    private ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        if (health <= 0)  
        {
            Die();
        } 

        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void Die()
    {
        if (scoreManager != null)
        {
            scoreManager.AddScore(1);
        }
        Destroy(gameObject);
    }

    public void TakeDamage(int damage, Vector3 hitPosition)
    {
        health -= damage;
        Instantiate(effect, hitPosition + new Vector3(effectOffset, 0, 0), Quaternion.identity);
    }
}
