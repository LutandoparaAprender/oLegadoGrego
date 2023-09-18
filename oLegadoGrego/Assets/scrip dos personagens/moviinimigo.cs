using UnityEngine;

public class moviinimigo : MonoBehaviour
{
    public Transform target;         // Referência ao jogador (arraste o GameObject do jogador aqui)
    public float moveSpeed = 3.0f;   // Velocidade de movimento do inimigo
    public float maxChaseDistance = 10.0f; // Distância máxima para perseguir o jogador
    public float minChaseDistance = 2.0f; // Distância minima para perseguir o jogador

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
            // Calcula a distância entre o inimigo e o jogador
            float distanceToTarget = Vector3.Distance(transform.position, target.position);

            // Verifica se o jogador está dentro da distância máxima de perseguição
            if (distanceToTarget <= maxChaseDistance && distanceToTarget >=minChaseDistance)
            {
                Vector3 direction = target.position - transform.position;
                direction.Normalize();

                // Mova o inimigo na direção do jogador
                transform.position += direction * moveSpeed * Time.deltaTime;

                animator.SetBool("walk", distanceToTarget <= maxChaseDistance);

                // Flip o sprite se necessário
                if (direction.x < 0) // Verifica se está se movendo para a esquerda
                {
                    spriteRenderer.flipX = true; // Flip horizontalmente
                }
                else
                {
                    spriteRenderer.flipX = false; // Não flip
                }
            }
        }
    }
}