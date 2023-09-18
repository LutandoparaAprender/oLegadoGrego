using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ataque : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //deativar gameobject da arma
    }

    // Update is called once per frame
    void Update()
    {
        //aperta tecla de atack
        //ativar gameobject da arma
        //aguarda atk acabar
        
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("tagDoInimigo")) {
            //dar dano no inimigo
        }
    }
}
