using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// incorperating all necessary components in the player
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(BoxCollider2D))]

public class PlayerEngine : MonoBehaviour {

    //player movement variable
    public int Speed = 4;
    protected Joystick joystick;
    //protected Joybutton joybutton;

    /// <summary>
    /// This 
    /// </summary>
    [SerializeField]
    private Vector2 DeltaForce;
    private Vector2 LastDirection;
    private Rigidbody2D RGB;
    private Animator Anim;
    private BoxCollider2D BoxCollider;
    private static bool IsMoving = false;
    //DialogueManager DialogueManager = gameObject.GetComponent<DialogueManager>()
   
    /// <summary>
    /// initializing in a awake function in order to avoid crashing when changing variable when it isn't finished initializing yet
    /// </summary>
    void Awake() {
        Anim = GetComponent<Animator>();
        RGB = GetComponent<Rigidbody2D>();
        BoxCollider = GetComponent<BoxCollider2D>();
    }

    // Use this for initialization
    void Start() {
        RGB.gravityScale = 0;
        RGB.constraints = RigidbodyConstraints2D.FreezeRotation;
        joystick = FindObjectOfType<Joystick>();
    }

    // Update is called once per frame
    void Update() {
        CheckInput();
        //RGB.velocity = new Vector2(joystick.Horizontal * Speed, joystick.Vertical * Speed);
    }

    /// <summary>
    /// This is where we read in the player's input.
    /// </summary>
    void CheckInput() {

        IsMoving = false;

        //storing built in unity inputs in variables
        //var Hor = Input.GetAxisRaw("Horizontal");
        //var Vert = Input.GetAxisRaw("Vertical");

        //getting input directly from the onscreen buttons 
        var Hor = joystick.Horizontal;
        var Vert = joystick.Vertical;

        //If horizontal or vertical values aren't equal to 0, than the player is moving 
        if (Hor < 0 || Hor > 0 || Vert < 0 || Vert > 0)
        {
            IsMoving = true;

            if(!BoxCollider.IsTouchingLayers(Physics2D.AllLayers))
            LastDirection = RGB.velocity;
        }

        DeltaForce = new Vector2(Hor, Vert);
        CalculateMovement(DeltaForce * Speed);
    }

    /// <summary>
    /// This is the function where we add force to the player. 
    /// </summary>
    /// <param name="PlayerForce"></param>
    void CalculateMovement(Vector2 PlayerForce)
    {
        /*reseting the velocity so you will only be able to move if a 
        * button is being pressed */
        RGB.velocity = Vector2.zero;

        RGB.AddForce(PlayerForce, ForceMode2D.Impulse);

        SendAnimInfo();
    }


    /// <summary>
    /// this is the function where you would send information to the qanimator
    /// </summary>
    void SendAnimInfo()
    {
        //what ever is the _RGB velocity . x will be read on to the animator same with y
        Anim.SetFloat("XSpeed", RGB.velocity.x);
        Anim.SetFloat("YSpeed", RGB.velocity.y);

        Anim.SetFloat("LastX", LastDirection.x);
        Anim.SetFloat("LastY", LastDirection.y);

        Anim.SetBool("IsMoving", IsMoving);
    }
}