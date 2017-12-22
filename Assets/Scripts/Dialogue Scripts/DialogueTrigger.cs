using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public bool TriggerDialogurIsRunning = false;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

  
    //allowing the player to approach the NPC and talk to them by pressing the E key
    public void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TriggerDialogue();
            TriggerDialogurIsRunning = true;
        }
    }

    //closing the dialogue if the player walks away
    public void OnTriggerExit2D(Collider2D collider)
    {
        FindObjectOfType<DialogueManager>().EndDialogue();
    }
    
    public void TriggerNextSentence()
    {
        if (Input.GetKeyDown(KeyCode.E) && TriggerDialogurIsRunning == false)
        {
            //FindObjectOfType<DialogueManager>().DisplayNextSentence();\
            Debug.Log("MEMEME");
        }
    }
    
}