using UnityEngine;

public class moviinimigo : MonoBehaviour
{
    public Transform target;         // Refer�ncia ao jogador (arraste o GameObject do jogador aqui)
    public float moveSpeed = 3.0f;   // Velocidade de movimento do inimigo
    public float maxChaseDistance = 10.0f; // Dist�ncia m�xima para perseguir o jogador
    public float minChaseDistance = 2.0f; // Dist�ncia minima para perseguir o jogador

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {

        if (target != null)
        {
            // Calcula a dist�ncia entre o inimigo e o jogador
            float distanceToTarget = Vector3.Distance(transform.position, target.position);

            // Verifica se o jogador est� dentro da dist�ncia m�xima de persegui��o
            if (distanceToTarget <= maxChaseDistance && distanceToTarget >=minChaseDistance)
            {
                Vector3 direction = target.position - transform.position;
                direction.Normalize();

                // Mova o inimigo na dire��o do jogador
                transform.position += direction * moveSpeed * Time.deltaTime;

                animator.SetBool("walk", distanceToTarget <= maxChaseDistance);

                // Flip o sprite se necess�rio
                if (direction.x < 0) // Verifica se est� se movendo para a esquerda
                {
                    spriteRenderer.flipX = true; // Flip horizontalmente
                }
                else
                {
                    spriteRenderer.flipX = false; // N�o flip
                }
            }
        }
    }
}