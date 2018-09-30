using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public bool TriggerDialogueIsRunning = false;
    protected AButton AButton;
    public Button _button;
    public bool CanTriggerDialogue;

    public void Start()
    {
        AButton = FindObjectOfType<AButton>();
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, this.gameObject);
        TriggerDialogueIsRunning = true;

        
    }

    public void Update()
    {
        if (CanTriggerDialogue == true)
        {
            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Joystick1Button0) || AButton.Pressed)
            {
                AButton.Pressed = false;
                if (TriggerDialogueIsRunning == false)
                {
                    TriggerDialogue();
                }
                else //if (FindObjectOfType<DialogueManager>().StillPrinting == false)
                {
                    FindObjectOfType<DialogueManager>().DisplayNextSentence();
                    //TriggerDialogueIsRunning = true;
                }
            }
        }
}
    

    //activating the dialogue box and setting the diaglogue runing bool to to true. to avoid looping the cycle of running.
    public void OnTriggerEnter2D(Collider2D collision) {
        CanTriggerDialogue = true;   
    }


    //allowing the player to approach the NPC and talk to them by pressing the E key
    public void OnTriggerStay2D(Collider2D other) {
      
    }

    //I was created and left here by Howard, the maker of the this game.
   
    //closing the dialogue if the player walks away
    public void OnTriggerExit2D(Collider2D collider)
    {
        FindObjectOfType<DialogueManager>().EndDialogue();
        TriggerDialogueIsRunning = false;
        CanTriggerDialogue = false;
    }
}
   