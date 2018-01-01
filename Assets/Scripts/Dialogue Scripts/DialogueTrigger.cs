using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public bool TriggerDialogueIsRunning = false;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        TriggerDialogueIsRunning = true;
    }

  
    //allowing the player to approach the NPC and talk to them by pressing the E key
    public void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (TriggerDialogueIsRunning == false)
            {
                TriggerDialogue();
            }
            else
            {
                FindObjectOfType<DialogueManager>().DisplayNextSentence();
                TriggerDialogueIsRunning = false;
       
            }
        }
       
    }

    //closing the dialogue if the player walks away
    public void OnTriggerExit2D(Collider2D collider)
    {
        FindObjectOfType<DialogueManager>().EndDialogue();
        TriggerDialogueIsRunning = false;
        
    }
    
    /*public void TriggerNextSentence()
    {
        if (Input.GetKeyDown(KeyCode.E) && TriggerDialogueIsRunning == false)
        {
            FindObjectOfType<DialogueManager>().DisplayNextSentence();
            Debug.Log("MEMEME");
        }
    }
    */
}