using System;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;
    
    
    

    private void Start()
    {
        Invoke("DestroyBullet", lifetime);
    }

    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Player"))
            {
                hitInfo.collider.GetComponent<Player>().ChangeHealth(-damage);
            }
            else if(hitInfo.collider.CompareTag("Obstruction"))
            {
                hitInfo.collider.GetComponent<Obstruction>().TakeDamage(damage, hitInfo.point);
            }
            DestroyBullet();
        }
        
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
