using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    private Animator _animator;

    private bool isMovingHang;
    private const string MOVE_HAND = "Moving Hand";


    private const string IS_MOVING = "IsMoving";
    private bool isMoving;


    private float moveX;
    private float moveZ;

    private const string MOVE_X = "Move_X";
    private const string MOVE_Z = "Move_Z";
    
    
    // Start is called before the first frame update
    void Start()
    {

        _animator = GetComponent<Animator>();
        _animator.SetBool(MOVE_HAND, isMovingHang);
        _animator.SetBool(IS_MOVING, isMoving);
        
        _animator.SetFloat(MOVE_X, moveX);
        _animator.SetFloat(MOVE_Z, moveZ);
        
    }

    // Update is called once per frame
    void Update()
    {

        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");



        if (Mathf.Sqrt(moveX * moveX + moveZ * moveZ) > 0.01)
        {
            _animator.SetBool(IS_MOVING,isMoving = true);
            _animator.SetFloat(MOVE_X, moveX);
            _animator.SetFloat(MOVE_Z, moveZ);
            
            
        }
        else
        {
            _animator.SetBool(IS_MOVING, isMoving = false);
        }
        
        
        
        
        
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isMovingHang = !isMovingHang;
            _animator.SetBool(MOVE_HAND, isMovingHang);


        }
        
    }
}
