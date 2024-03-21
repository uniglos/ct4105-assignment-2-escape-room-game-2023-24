using UnityEngine;
using System.Collections;

public class PlayerCharacterController : MonoBehaviour
{
    private CharacterController _controller;

    static Animator _animator;

    
    public float speed = 4f;
    public float rotationSpeed = 100.0f;

    private float gravity = 0.5f;

    private float jumpForce = 0.1f;

    private Vector3 movement;

    private Vector3 verticalMovement;
    

    // Use this for initialization
    void Start()
    {

        _controller = GetComponent<CharacterController>();

        _animator = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {

        print( _controller.isGrounded );

        if( _controller.isGrounded )
        {
            
            verticalMovement.y =  -_controller.stepOffset / Time.deltaTime;;
            
            if ( Input.GetButtonDown( "Jump" ) )
            {
                
                _animator.SetTrigger( "isJumping" );

                verticalMovement.y = jumpForce;

            }

        } else {

            verticalMovement.y -= gravity * ( Time.deltaTime / 1.5f );

        }

        movement = _controller.transform.forward * Input.GetAxis( "Vertical" );

        _controller.Move( movement * speed * Time.deltaTime );

        _controller.Move( verticalMovement );

        _controller.transform.Rotate( Vector3.up * Input.GetAxis( "Horizontal" ) * ( rotationSpeed * Time.deltaTime ) );
        
        if ( Input.GetAxis( "Vertical" ) == 0 )
        {
            
            _animator.SetBool( "isRunning", false );

            _animator.SetBool( "isIdle", true );

        } else {

            _animator.SetBool( "isRunning", true );

            _animator.SetBool( "isIdle", false );

        }
        
    }

}