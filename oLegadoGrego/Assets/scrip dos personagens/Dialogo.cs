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
    public bool skipDialogue; // Variável para controlar o pulo de diálogo

    // Adicione uma referência ao botão de "Pular Diálogo" no Unity Editor
    public Button skipButton;

    // Start is called before the first frame update
    void Start()
    {
        dialoguePanel.SetActive(false);

        // Adicione um ouvinte de clique ao botão de "Pular Diálogo"
        skipButton.onClick.AddListener(SkipDialogue);
        // Desative o botão de "Pular Diálogo" no início
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
            skipDialogue = true; // Ativar o modo de skip de diálogo
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
            skipDialogue = false; // Certifique-se de redefinir o skip de diálogo quando o diálogo for concluído
            skipButton.gameObject.SetActive(false); // Desative o botão de "Pular Diálogo" no final do diálogo
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
        // Ative o botão de "Pular Diálogo" quando o diálogo estiver visível
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

    // Método para pular o diálogo quando o botão for clicado
    void SkipDialogue()
    {
        if (startDialogue)
        {
            StopAllCoroutines(); // Pare todas as corrotinas em execução (o efeito de digitação)
            dialogueText.text = dialogueNpc[dialogueIndex]; // Define o texto para o diálogo atual
            NextDialogue(); // Vá para o próximo diálogo
        }
    }
}