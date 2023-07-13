using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;
    public AudioSource audioSource;
    public float delay = 0.5f;
    private float timer = 0f;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            animator.SetBool("Shoot", true);

        }
        else
        {
            animator.SetBool("Shoot", false);
        }
        if (Input.GetMouseButton(0) && timer <= 0f)
        {
            audioSource.Play();
            timer = delay;
        }

        if (timer > 0f)
        {
            timer -= Time.deltaTime;
        }

    }
}