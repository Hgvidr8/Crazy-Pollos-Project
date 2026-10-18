using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{

    public static DialogueManager Instance;
    Dialogue InternalDialogue;
    int currentSentenceIndex = 0;

    bool IsDialogueActive => InternalDialogue != null;

    [SerializeField] GameObject dialoguePanel;
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text dialogueText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    public void StartDialogue(Dialogue dialogue)
    {
        nameText.text = dialogue.GetName();
        dialogueText.text = dialogue.GetSentences()[0];

        InternalDialogue = dialogue;
        dialoguePanel.SetActive(true);
    }

    public void NextDialogue() 
    {
        if (!IsDialogueActive) return;
        currentSentenceIndex++;
        if (currentSentenceIndex < InternalDialogue.GetSentences().Length)
        {
            dialogueText.text = InternalDialogue.GetSentences()[currentSentenceIndex];
        } else
            EndDialogue();
    }

    void EndDialogue()
    {
        InternalDialogue = null;
        currentSentenceIndex = 0;
        nameText.text = "";
        dialogueText.text = "";
        dialoguePanel.SetActive(false);
    }
}
