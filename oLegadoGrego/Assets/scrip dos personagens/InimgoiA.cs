using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimgoiA : MonoBehaviour
{
    public Transform target;
    public float moveSpeed = 5f;
    public float attackRange = 1.3f;
    public float attackRate = 2f;

    private float nextAttackTime = 0f;

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (target == null)
        {
            // N�o h� alvo, a IA n�o faz nada
            return;
        }

        // Movimenta��o em dire��o ao alvo
        MoveTowardsTarget();

        // Verifica a dist�ncia e ataca se estiver pr�ximo o suficiente
        if (Vector3.Distance(transform.position, target.position) < attackRange && Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }

    void MoveTowardsTarget()
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        // Adicionei a condi��o para verificar a dist�ncia antes de decidir se a IA deve se mover ou atacar
        if (distanceToTarget > attackRange)
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
        }
        else
        {
            animator.SetBool("walk ini", false);
        }
    }

    void Attack()
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        if (distanceToTarget < attackRange)
        {
            // Inicia a anima��o de ataque
            animator.SetBool("attack",true);
            Debug.Log("Atacando!");

            // Adicione aqui a l�gica espec�fica do ataque
            // Por exemplo, voc� pode aplicar dano ao jogador aqui
        }
        else
        {
            // Inicia a anima��o de parado, j� que n�o est� perto o suficiente para atacar
            animator.SetBool("walk ini", false);
            animator.SetBool("attack", false);
            Debug.Log("Parado, n�o est� perto o suficiente para atacar.");
        }
    }
}
