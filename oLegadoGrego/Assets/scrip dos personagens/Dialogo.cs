using System.Collections;
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
    public bool skipDialogue;

    public float interactRange = 2f; // Defina o valor adequado para a sua cena
    public Button skipButton;

    void Start()
    {
        dialoguePanel.SetActive(false);
        skipButton.onClick.AddListener(SkipDialogue);
        skipButton.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonDown("interage") && readyToSpeak)
        {
            if (skipDialogue)
            {
             NextDialogue();
           }
      }

        if (Input.GetButtonDown("interage") && readyToSpeak)
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
                skipDialogue = true;
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
            skipDialogue = true;
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
            FindObjectOfType<Jogador1>().velocidadedeMovimento = 10f;
            skipDialogue = false;
            skipButton.gameObject.SetActive(false);
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
            yield return new WaitForSeconds(0.064f);
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
