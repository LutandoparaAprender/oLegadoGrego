using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador1 : MonoBehaviour
{
    public Rigidbody2D rb;
    public float velocidadedeMovimento;
    public SpriteRenderer spriteRenderer;
    public float forcapulo;
    bool isGround;
    public Transform foot;
    public LayerMask ground;

    public Transform attackCheck;
    public LayerMask LayerEnemy;

    public Animator playerAnimator; // Adicionei essa referência ao Animator

    public bool IsGround
    {
        get { return isGround; }
    }

    void Start()
    {
        // Inicialização do jogador, se necessário
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 velocidade = this.rb.velocity;
        velocidade.x = horizontal * this.velocidadedeMovimento;
        this.rb.velocity = velocidade;

        isGround = Physics2D.OverlapCircle(foot.position, 0.2f, ground);

        if (velocidade.x > 0)
        {
            this.spriteRenderer.flipX = false;
        }
        else if (velocidade.x < 0)
        {
            this.spriteRenderer.flipX = true;
        }
        {
            float velocidadeX = Mathf.Abs(this.rb.velocity.x);
            if (velocidadeX > 0)
            {
             this.playerAnimator.SetBool("walk", true);
            }
            else
            {
                  playerAnimator.SetBool("walk", false);
            }

            if (Input.GetKeyDown(KeyCode.Space) && isGround)
            {
                Vector2 forca = new Vector2(0, this.forcapulo);
                this.rb.AddForce(forca, ForceMode2D.Impulse);
            }

            // Atualiza o parâmetro de pulo no Animator com base no jogador
             playerAnimator.SetBool("jump", !isGround);

            if (Input.GetButtonDown("Fire1") && rb.velocity == Vector2.zero)
            {
                playerAnimator.SetTrigger("ataque");
            }
        }
    }
}