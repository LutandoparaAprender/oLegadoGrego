using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogo : MonoBehaviour
{
    public string[] dialogueNpc;
    public int dialogueIndex;

    public GameObject dialoguePanel;
    public Text dialogueText;

    public Text nameNpc;
    public Image imageNpc;
    public Sprite spriteNpc;

    public bool readyToSpeak;
    public bool startDialogue;
    public bool skipDialogue; // Vari�vel para controlar o pulo de di�logo

    // Adicione uma refer�ncia ao bot�o de "Pular Di�logo" no Unity Editor
    public Button skipButton;

    // Start is called before the first frame update
    void Start()
    {
        dialoguePanel.SetActive(false);

        // Adicione um ouvinte de clique ao bot�o de "Pular Di�logo"
        skipButton.onClick.AddListener(SkipDialogue);
        // Desative o bot�o de "Pular Di�logo" no in�cio
        skipButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && readyToSpeak)
        {
            if (skipDialogue)
            {
                NextDialogue();
            }
        }
    }

    private void OnMouseDown()
    {
        if (!startDialogue)
        {
            FindObjectOfType<Jogador1>().velocidadedeMovimento = 0f;
            StartDialogue();
        }
        else if (dialogueText.text == dialogueNpc[dialogueIndex])
        {
            NextDialogue();
        }
        else
        {
            skipDialogue = true; // Ativar o modo de skip de di�logo
        }
    }

    void NextDialogue()
    {
        dialogueIndex++;

        if (dialogueIndex < dialogueNpc.Length)
        {
            StartCoroutine(ShowDialogue());
        }
        else
        {
            dialoguePanel.SetActive(false);
            startDialogue = false;
            dialogueIndex = 0;
            FindAnyObjectByType<Jogador1>().velocidadedeMovimento = 10f;
            skipDialogue = false; // Certifique-se de redefinir o skip de di�logo quando o di�logo for conclu�do
            skipButton.gameObject.SetActive(false); // Desative o bot�o de "Pular Di�logo" no final do di�logo
        }
    }

    void StartDialogue()
    {
        nameNpc.text = "Filosofo";
        imageNpc.sprite = spriteNpc;
        startDialogue = true;
        dialogueIndex = 0;
        dialoguePanel.SetActive(true);
        StartCoroutine(ShowDialogue());
    }

    IEnumerator ShowDialogue()
    {
        // Ative o bot�o de "Pular Di�logo" quando o di�logo estiver vis�vel
        skipButton.gameObject.SetActive(true);
        dialogueText.text = "";
        foreach (char letter in dialogueNpc[dialogueIndex])
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.064f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            readyToSpeak = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            readyToSpeak = false;
        }
    }

    // M�todo para pular o di�logo quando o bot�o for clicado
    void SkipDialogue()
    {
        if (startDialogue)
        {
            StopAllCoroutines(); // Pare todas as corrotinas em execu��o (o efeito de digita��o)
            dialogueText.text = dialogueNpc[dialogueIndex]; // Define o texto para o di�logo atual
            NextDialogue(); // V� para o pr�ximo di�logo
        }
    }
}