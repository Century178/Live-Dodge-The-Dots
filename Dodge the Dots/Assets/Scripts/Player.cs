using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; } //We want other scripts to access this script, but only this script to set itself.

    [SerializeField] private float _moveSpeed = 5f; //[SerializeField] makes variables visible in the inspector.
    private float _movement;
    
    [SerializeField] private float _jumpForce = 5f;
    private bool _isJumping;

    [HideInInspector] public bool _isDead = false; //[HideInInspector] makes variables hidden from the inspector.

    private Rigidbody2D _rb2D; //We can turn a component into a variable so we have a shorthand for it.

    private void Awake()
    {
        if (Instance == null) Instance = this; //This If Statement makes sure there is only one player.
        else Destroy(gameObject); //"gameObject" is what we use when destroying this specific instance.

        _rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _movement = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump")) _isJumping = true; //You can't just set the bool to be equal to Input.GetButtonDown().
    }

    private void FixedUpdate()
    {
        _rb2D.velocity = new Vector2(_movement * _moveSpeed, _rb2D.velocity.y); //Use only Rigidbody.velocity.x/y/z if that vector needs to be left alone.

        if (_isJumping) //Short hand for if a bool is true. "!bool" is the shorthand for if a bool is false.
        {
            _rb2D.velocity = new Vector2(_rb2D.velocity.x, _jumpForce);
            _isJumping = false; //If this isn't here, there will be a window in which we can't jump.
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Danger")) //The best method of checking for a certain tag.
        {
            _isDead = true;
            Destroy(gameObject);
        }
    }
}
