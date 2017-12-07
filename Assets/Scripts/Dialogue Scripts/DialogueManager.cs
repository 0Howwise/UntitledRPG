using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour {

    private Queue<string> sentences;

    //creating a queue for sentences 
    void Start() {
        sentences = new Queue<string>();
    }

 
    public void StartDialogue (Dialogue dialogue)
    {
        Debug.Log("Starting conversation with" + dialogue.name);
    }

}
