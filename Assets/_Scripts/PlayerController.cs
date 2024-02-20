using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Animator _animator;
    [SerializeField] private bool isMoving;
    private const string MOVING_HAND = "isMovingHand";


    private const string IS_MOVEMENT = "isMovement";
    private bool isMovement;

    private const string HORIZONTAL = "Horizontal";
    private float horizontal;

    private const string VERTICAL = "Vertical";
    private float vertical;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool(MOVING_HAND, isMoving);
        
        _animator.SetBool(IS_MOVEMENT, isMovement);
        
        _animator.SetFloat(HORIZONTAL, horizontal);
        _animator.SetFloat(VERTICAL, vertical);
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        MovingHand();
        Movement();
    }

    private void Movement()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        
        
        
    }
    
    
    private void MovingHand()
    {

      
        
        
        
        
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isMoving = !isMoving;
            _animator.SetBool(MOVING_HAND, isMoving);
            
        }
        
    }
}
