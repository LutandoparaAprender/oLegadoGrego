using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{
    public MeshRenderer fd;
    public float speed;
    public float cavernaY = -7.08f; // A posição Y da caverna
    public Material cavernaMaterial; // Material da caverna

    private bool entrouNaCaverna = false;

    // Start is called before the first frame update
    void Start()
    {
        fd.material.mainTextureOffset = new Vector2(speed * Time.deltaTime, 0);
    }

    // Update is called once per frame
    void Update()
    {
        fd.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);

        // Se a posição Y do personagem for menor que a posição da caverna e ainda não entrou na caverna
        if (transform.position.y < cavernaY && !entrouNaCaverna)
        {
            fd.material = cavernaMaterial; // Atribui o material da caverna ao MeshRenderer
            entrouNaCaverna = true; // Marca que o personagem entrou na caverna
        }
    }
}
