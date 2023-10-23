using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour
{
    // Variáveis para armazenar os valores x, y e z da posição inicial do personagem
    public float initialX = 0.0f;
    public float initialY = 0.0f;
    public float initialZ = 0.0f;
    private Vector3 checkpointPos; // Altere o nome da variável para "checkpointPos"

    private void Start()
    {
        // Define a posição inicial do personagem com os valores especificados
        checkpointPos = new Vector3(initialX, initialY, initialZ);
        transform.position = checkpointPos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("obstacle"))
        {
            Die();
        }
        else if (collision.CompareTag("checkpoint"))
        {
            // Se colidir com um objeto marcado como "Checkpoint," atualize a posição do checkpoint
            UpdateCheckpoint(collision.transform.position);
        }
    }

    void Die()
    {
        Respawn();
    }

    // Atualize a posição do checkpoint quando o jogador alcançar um checkpoint
    void UpdateCheckpoint(Vector3 pos)
    {
        checkpointPos = pos;
    }

    void Respawn()
    {
        // Define a posição de respawn como a posição do último checkpoint
        transform.position = checkpointPos;
    }
}