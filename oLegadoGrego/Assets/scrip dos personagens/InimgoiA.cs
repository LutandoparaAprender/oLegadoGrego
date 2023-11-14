using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimgoiA : MonoBehaviour
{
    public float visionRange = 5.0f;
    public float attackRange = 1.0f; // Alcance de ataque
    public float movementSpeed = 2.0f;
    public float attackCooldown = 1.5f; // Tempo de recarga entre os ataques
    private Transform player;
    private Animator animator;
    private bool canAttack = true;
    //public Enemy enemy;
    //public int maxhealth = 100;
    //public Ataque ataque;
    //public int attackDamage = 40;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, player.position) <= visionRange)
        {
            Vector2 direction = (player.position - transform.position).normalized;

            // Verifica se o inimigo está dentro do alcance de ataque
            if (Vector2.Distance(transform.position, player.position) <= attackRange)
            {
                // Ataque o jogador se estiver no alcance de ataque e o ataque estiver disponível
                if (canAttack)
                {
                    StartCoroutine(Attack());
                }
            }
            else
            {
                // Move o inimigo em direção ao jogador
                transform.Translate(direction * movementSpeed * Time.deltaTime);
                animator.SetBool("isWalking", true);
            }
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    private IEnumerator Attack()
    {
        canAttack = false;

        // Configurar a animação de ataque no Animator
        animator.SetTrigger("Attack");

        // Lógica do ataque (pode ser dano ao jogador, por exemplo)
        // Coloque sua lógica de ataque aqui

        // Aguarde o tempo de recarga entre os ataques
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;



//public bool Defendendo(int danoDoJogador)
//{
//  int chanceDeAcerto = Random.Range(1, 12); // Gera um número aleatório de 1 a 10.

//  if (chanceDeAcerto <= 4)
//  {
//      // O inimigo se defende, não sofre dano.

//      Debug.Log("O inimigo se defendeu com sucesso!");
//      return false;

//  }
//     else
// {
// O inimigo sofre dano.
//     Debug.Log("O inimigo sofreu " + danoDoJogador + " de dano!");
//      return true;
//   }
 }
}
