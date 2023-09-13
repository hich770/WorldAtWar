using UnityEngine;

public class Gun : MonoBehaviour
{
    public GunType gunType;
    public int offset;
    public GameObject bullet;
    public Transform shotPoint;

    public enum GunType{Default, Enemy}

    private float timeBtwShots;
    public float StartTimeBtwShots;
    public bool facingRight = Player.facingRight;
    private Animator camAnim;
    private float rotZ;
    private Vector3 difference;
    private Player player;


    private void Start()
    {
        camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        facingRight = true;
    }
    void Update()
    {
        if(gunType == GunType.Default)
        {
            difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset); 
        }
        else if (gunType == GunType.Enemy)
        {
            difference = player.transform.position - transform.position;
            rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        }


        if(gunType == GunType.Enemy && timeBtwShots <= 0)
        {
            Shoot();
            timeBtwShots = StartTimeBtwShots;
        } 
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
        if (gunType == GunType.Default && timeBtwShots <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Shoot();
            }
        }
    }
    private void FixedUpdate()
    {
        if(gunType == GunType.Default)
        {
            facingRight = Player.facingRight;
            if(facingRight == true)
            {
                offset = 0;
            }
            else if (facingRight == false)
            {
                offset = 180;
            }
        }
    }
    public void Shoot()
    {
        Instantiate(bullet, shotPoint.position, shotPoint.rotation);
        timeBtwShots = StartTimeBtwShots;
        camAnim.SetTrigger("Shake");
    }

}