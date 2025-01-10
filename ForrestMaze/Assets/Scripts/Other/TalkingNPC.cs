using System.Collections;
using TMPro;
using UnityEngine;

public class TalkingNPC : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public string[] dialogueLines;
    private int dialogueIndex;

    public GameObject continueButton;
    private bool playerIsClose;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            if (dialoguePanel.activeInHierarchy)
            {
                EndDialogue();
            }
            else
            {
                StartDialogue();
            }
        }

        if (dialogueText.text == dialogueLines[dialogueIndex])
        {
            continueButton.SetActive(true);
        }
    }

    void StartDialogue()
    {
        dialoguePanel.SetActive(true);
        dialogueIndex = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char letter in dialogueLines[dialogueIndex].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.05f); // Adjust typing speed
        }
    }

    public void NextDialogue()
    {
        continueButton.SetActive(false);

        if (dialogueIndex < dialogueLines.Length - 1)
        {
            dialogueIndex++;
            dialogueText.text = "";
            StartCoroutine(TypeLine());
        }
        else
        {
            EndDialogue();
        }
    }

    void EndDialogue()
    {
        dialogueText.text = "";
        dialoguePanel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
        }
    }
}
