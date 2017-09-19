using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// incorperating all necessary components in the player
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(BoxCollider2D))]

public class PlayerEngine : MonoBehaviour {

    //player movement variable
    public float _Speed = 2;

    /// <summary>
    /// This 
    /// </summary>
    [SerializeField]
    private Vector2 _DeltaForce;
    private Rigidbody2D _RGB;
    private Animator _Anim;
    private BoxCollider2D _BoxCollider;

    /// <summary>
    /// initializing in a awake function in order to avoid crashing when changing variable when it isn't finished initializing yet
    /// </summary>
    void Awake() {
        _Anim = GetComponent<Animator>();
        _RGB = GetComponent<Rigidbody2D>();
        _BoxCollider = GetComponent<BoxCollider2D>();
    }

    // Use this for initialization
    void Start() {
        _RGB.gravityScale = 0;
        _RGB.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    void Update() {
        CheckInput();
    }

    /// <summary>
    /// This is where we read in the player's input.
    /// </summary>
    void CheckInput() {
        //storing built in unity inputs in variables
        var _H = Input.GetAxisRaw("Horizontal");
        var _V = Input.GetAxisRaw("Vertical");

        _DeltaForce = new Vector2(_H, _V);
        CalculateMovement(_DeltaForce * _Speed);
    }

    /// <summary>
    /// This is the function where we add force to the player. 
    /// </summary>
    /// <param name="_PlayerForce"></param>
    void CalculateMovement(Vector2 _PlayerForce)
    {
        /*reseting the velocity so you will only be able to move if a 
        * button is being pressed */
        _RGB.velocity = Vector2.zero;
        _RGB.AddForce(_PlayerForce, ForceMode2D.Impulse);
    }
}
