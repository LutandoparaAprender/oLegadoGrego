using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque: MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform attackPoint;
    public float attackRange = 0;
    public LayerMask enemyLayers;
    public int attackDamage = 40;
    public Animator playerAnimator;
    private bool isAttacking = false;
    public float attackCooldown = 0.9f; // Tempo entre os ataques
    private float nextAttackTime = 0.0f;

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                isAttacking = true;
                playerAnimator.SetBool("ataque", true);
                nextAttackTime = Time.time + attackCooldown; // Define o próximo tempo de ataque
            }
        }
        else
        {
            isAttacking = false;
            playerAnimator.SetBool("ataque", false);
        }

        if (isAttacking)
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null || !isAttacking)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}