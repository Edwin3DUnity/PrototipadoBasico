using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator _animator;

    private const string MOVE_HANDS = "Move Hands";
    private bool movingHands;


    private const string MOVE_X = "Move_X";
    private const string MOVE_Y = "Move_Y";

    private bool isMoving;
    private const string IS_MOVING = "isMoving";



    private float Move_X;
    private float Move_Y;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool(MOVE_HANDS, movingHands);
        
        _animator.SetBool(IS_MOVING, isMoving);
        
        _animator.SetFloat(MOVE_X, Move_X);
        _animator.SetFloat(MOVE_Y, Move_Y);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Move_X = Input.GetAxis("Horizontal");
        Move_Y = Input.GetAxis("Vertical");
        
        
        if (Mathf.Sqrt(Move_X * Move_X + Move_Y * Move_Y) > 0.01)
        {
          
            _animator.SetBool(IS_MOVING, isMoving = true);
            _animator.SetFloat(MOVE_X, Move_X);
            _animator.SetFloat(MOVE_Y, Move_Y);
            
        }
        else
        {
            _animator.SetBool(IS_MOVING, isMoving = false);
        }
        
        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            movingHands = !movingHands;
            
            _animator.SetBool(MOVE_HANDS, movingHands);


        }
        
    }
}
