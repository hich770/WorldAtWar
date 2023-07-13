using UnityEngine;

public class Gun : MonoBehaviour
{
    public int offset;
    public GameObject bullet;
    public Transform shotPoint;

    private float timeBtwShots;
    public float StartTimeBtwShots;
    public bool facingRight = Player.facingRight;
    private Animator camAnim;
    

    private void Start()
    {
        camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
    }
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset); 

        if(timeBtwShots <= 0)
        {
            if(Input.GetMouseButton(0))
            {
                Instantiate(bullet, shotPoint.position, transform.rotation);
                timeBtwShots = StartTimeBtwShots;
                camAnim.SetTrigger("Shake");
                
            }     
        } 
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
    private void FixedUpdate()
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
