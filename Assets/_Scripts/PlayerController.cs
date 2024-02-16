using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Animator _animator;

    private const string MOVE_HAND = "Move Hand";
    private bool MovingHang;

    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private bool isMoving;
    private const string IS_MOVING = "Is Moving";


    private float horizontal;
    private float vertical;
    
    // Start is called before the first frame update
    void Start()
    {


        _animator = GetComponent<Animator>();
        _animator.SetBool(MOVE_HAND, MovingHang);
        

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");


        if (Mathf.Sqrt(horizontal * horizontal + vertical * vertical) > 0.01)
        {
            _animator.SetBool(IS_MOVING, isMoving = true);
            
            _animator.SetFloat(HORIZONTAL, horizontal);
            _animator.SetFloat(VERTICAL, vertical);
            
            
        }
        else
        {
            _animator.SetBool(IS_MOVING, isMoving = false);
        }
        
        
        
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MovingHang = !MovingHang;
            _animator.SetBool(MOVE_HAND, MovingHang);

        }
        
        
        
        
    }
}
