using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{
    public MeshRenderer fd;
    public float speed;
    public float cavernaY = -7.08f; // A posi��o Y da caverna
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

        // Se a posi��o Y do personagem for menor que a posi��o da caverna e ainda n�o entrou na caverna
        if (transform.position.y < cavernaY && !entrouNaCaverna)
        {
            fd.material = cavernaMaterial; // Atribui o material da caverna ao MeshRenderer
            entrouNaCaverna = true; // Marca que o personagem entrou na caverna
        }
    }
}
