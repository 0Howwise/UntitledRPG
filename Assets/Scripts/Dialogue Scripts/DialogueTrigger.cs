using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public bool TriggerDialogueIsRunning = false;
   
    //activating the dialogue box and setting the diaglogue runing bool to to true. to avoid looping the cycle of running.
    
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        TriggerDialogueIsRunning = true;
    }


    //allowing the player to approach the NPC and talk to them by pressing the E key
    public void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            if (TriggerDialogueIsRunning == false)
            {
                TriggerDialogue();
            }
            else if (FindObjectOfType<DialogueManager>().StillPrinting == true)
            {
                FindObjectOfType<DialogueManager>().DisplayNextSentence();
                TriggerDialogueIsRunning = true;
            }
        }
    }

    //I was created and left here by Howard, the maker of the this game.
   
    //closing the dialogue if the player walks away
    public void OnTriggerExit2D(Collider2D collider)
    {
        FindObjectOfType<DialogueManager>().EndDialogue();
        TriggerDialogueIsRunning = false;
    }
}
   