using UnityEngine;

public class moviinimigo : MonoBehaviour
{
    public Transform target;
    public float moveSpeed = 3.0f;
    public float maxChaseDistance = 10.0f;
    public float minChaseDistance = 2.0f;

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent < SpriteRenderer>();
    }

    private void Update()
    {
        if (target != null)
        {
            float distanceToTarget = Vector3.Distance(transform.position, target.position);

            if (distanceToTarget <= maxChaseDistance && distanceToTarget >= minChaseDistance)
            {
                Vector3 direction = target.position - transform.position;
                direction.Normalize();
                transform.position += direction * moveSpeed * Time.deltaTime;

                animator.SetBool("walk ini", true);

                if (direction.x < 0)
                {
                    spriteRenderer.flipX = true;
                }
                else
                {
                    spriteRenderer.flipX = false;
                }
                animator.SetBool("walk ini", distanceToTarget > 2.2f);
            }
        }
    }
}
