using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigo : MonoBehaviour
{
    public float speed;
    public bool Ground = true;
    public Transform Groundcheck;
    public LayerMask GroundLayer;
    void Start()
    {

    }
    void Update()
    {
        // Verifique se o NPC atingiu um dos limites e inverta a direção
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        Ground = Physics2D.Linecast(Groundcheck.position, transform.position, GroundLayer);
        Debug.Log(Ground);

        if (Ground == false)
        {
            speed *= -1;
        }
    }
}