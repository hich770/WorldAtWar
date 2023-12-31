using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int health; 
    public float speed;
    public GameObject EndPanel;
    public GameObject GameOverText;
    public GameObject effect;
    public Button RestartButton;
    private float moveInput;
    private bool isDead = false;
    private bool isGameOver = false;
    public float effectOffset;
    
    

    private Rigidbody2D rb;
    public static bool facingRight = true;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        RestartButton.onClick.AddListener(Restart);
    }

    private void Update()
    {
        if (health <= 0 && !isDead)
        {
            Die();
        }
        if (isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
        if (moveInput == 0)
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            health--;
        }
    }

    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    private void Die()
    {
        isDead = true;
        Destroy(gameObject);
        EndPanel.SetActive(true);
        GameOverText.SetActive(true);
        Time.timeScale = 0;
        isGameOver = true;
        ShowAd();

    }
    
    public void ChangeHealth(int healthValue)
    {
        health += healthValue;
        
    }
    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
    public void ShowAd()
    {
        Application.ExternalCall("ShowAd");
    }
}