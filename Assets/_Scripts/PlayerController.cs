using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator _animator;
    
    private const string MOVE_HANDS = "Move Hands";
    private bool isMovingHands;

    private const string MOVE_X = "Move_X";
    private const string MOVE_Y = "Move_Y";


    private float moveX = 0, moveY = 0;
   
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool(MOVE_HANDS, isMovingHands);
        _animator.SetFloat(MOVE_X, moveX);
        _animator.SetFloat(MOVE_Y, moveY);
        
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");

        if (Mathf.Sqrt(moveX * moveX + moveY * moveY) > 0.01)
        {
            
            _animator.SetBool("Is Moving", true);
            
            _animator.SetFloat(MOVE_X, moveX);
            _animator.SetFloat(MOVE_Y, moveY);
            
        }
        else
        {
            _animator.SetBool("Is Moving" , false);
                
            
        }
        
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isMovingHands = !isMovingHands;
            _animator.SetBool(MOVE_HANDS, isMovingHands);
            
        }
    }
}
