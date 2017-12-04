using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    // up, right, left, down, movement
    void Update()
    {
        if (Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.A)))
        {
            
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector2.right * speed);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(-Vector2.right * speed);
            }
        }

        else if (Input.GetKey(KeyCode.W) || (Input.GetKey(KeyCode.S)))
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector2.up * speed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector2.down * speed);
            }
        }
    }
}