using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    public GameObject dialogueBox;
    public TMP_Text textLabel;    

    private TypeWritterEffect typeWritterEffect;


    public bool IsOpen { get; private set; }

    private void Start()
    {
        typeWritterEffect = GetComponent<TypeWritterEffect>();

        CloseDialogueBox();
        
    }

    public void ShowDialogue(DialogueObject dialogueObj)
    {
        IsOpen = true;
        dialogueBox.SetActive(true);
        StartCoroutine(routine: StepThroughDialogue(dialogueObj));
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObj)
    {       

        foreach (string dialogue in dialogueObj.Dialogue)
        {
            yield return typeWritterEffect.Run(dialogue, textLabel);
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));

        }

        CloseDialogueBox();
    }

    private void CloseDialogueBox()
    {
        IsOpen = false;
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;

    }


}
