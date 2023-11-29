using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dialogo1 : MonoBehaviour
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
    public bool skipDialogue;

    public float interactRange = 0; // Defina o valor adequado para a sua cena
    public Button skipButton;

    public puzzle transicaoCena; // Adicionado para referenciar o script de transição de cena

    void Start()
    {
        dialoguePanel.SetActive(false);
        skipButton.onClick.AddListener(SkipDialogue);
        skipButton.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown("e") && readyToSpeak)
        {
            if (skipDialogue)
            {
                NextDialogue();
            }
            else if (!startDialogue)
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
                skipDialogue = true;
            }
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
            // Verifica se o NPC atual é o último (Filosofo3 neste caso)
            if (nameNpc.text == "filosofo4")
            {
                // Carrega a cena do quebra-cabeça
                if (transicaoCena != null)
                {
                    transicaoCena.cena();
                }
                else
                {
                    Debug.LogError("TransicaoCena não atribuído no Inspector!");
                }
            }
            else
            {
                // Se não for o último NPC, encerra o diálogo como de costume
                dialoguePanel.SetActive(false);
                startDialogue = false;
                dialogueIndex = 0;
                FindObjectOfType<Jogador1>().velocidadedeMovimento = 10f;
                skipDialogue = false;
                skipButton.gameObject.SetActive(false);
            }
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
        skipButton.gameObject.SetActive(true);
        dialogueText.text = "";
        foreach (char letter in dialogueNpc[dialogueIndex])
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.01f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            readyToSpeak = true;

            if (Vector2.Distance(transform.position, collision.transform.position) <= interactRange)
            {
                UpdateInteraction(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            readyToSpeak = false;
            UpdateInteraction(false);
        }
    }

    void UpdateInteraction(bool canInteract)
    {
        skipButton.gameObject.SetActive(canInteract);
    }

    void SkipDialogue()
    {
        if (startDialogue)
        {
            StopAllCoroutines();
            dialogueText.text = dialogueNpc[dialogueIndex];
            NextDialogue();
        }
    }
}
