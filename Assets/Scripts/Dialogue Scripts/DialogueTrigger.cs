using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (Input.GetKeyDown("space"))
        {
            TriggerDialogue();
        }
    }
}