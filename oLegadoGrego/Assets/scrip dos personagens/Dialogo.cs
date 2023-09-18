using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogo : MonoBehaviour
{
    public string [] dialogueNpc; 
    public int dialogueIndex;

    public GameObject dialoguePanel;
    public Text dialogueText;

    public Text nameNpc;
    public Image imageNpc;
    public Sprite spriteNpc;

    public bool readyToSpeak;
    public bool startDialogue;

    // Start is called before the first frame update
    void Start()
    {
      dialoguePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && readyToSpeak)
        {
            if (!startDialogue)
            {
                FindObjectOfType<Jogador1>().velocidadedeMovimento= 0f;
                StartDialogue();
            }
            else if (dialogueText.text == dialogueNpc[dialogueIndex])
            {
                NextDialogue();
            }
        }
    }
    void NextDialogue()
    {
        dialogueIndex++;

        if(dialogueIndex < dialogueNpc.Length)
        {
            StartCoroutine(ShowDialogue()); 
        }
        else
        {
            dialoguePanel.SetActive(false);
            startDialogue = false;
            dialogueIndex = 0;
            FindAnyObjectByType<Jogador1>().velocidadedeMovimento = 10f;
        }
    }
     void StartDialogue()
     {
        nameNpc.text = "jonas";
        imageNpc.sprite = spriteNpc;
        startDialogue = true;
        dialogueIndex = 0; 
        dialoguePanel.SetActive (true);
        StartCoroutine(ShowDialogue());
     }
      IEnumerator ShowDialogue()
    {
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
}
