using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;
    private Vector2 direction;

    [SerializeField] bool enemyBullet;
    private void Start()
    {
        direction = Player.facingRight ? Vector2.right : Vector2.left;
        transform.localScale = Player.facingRight ? Vector3.one : new Vector3(-1, 1, 1);
        Destroy(gameObject, lifetime);
    }

private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, direction, distance, whatIsSolid);

        if(hitInfo.collider != null)
        {
            if(hitInfo.collider.CompareTag("Enemy"))
                {
                    hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage, hitInfo.point);
                }
                else if(hitInfo.collider.CompareTag("Obstruction"))
                {
                hitInfo.collider.GetComponent<Obstruction>().TakeDamage(damage, hitInfo.point);
                }
                if(hitInfo.collider.CompareTag("Player"))
                {
                    hitInfo.collider.GetComponent<Player>().ChangeHealth(-damage);
                }
                Destroy(gameObject);
        }

        transform.Translate(direction * speed * Time.deltaTime);
    }
}