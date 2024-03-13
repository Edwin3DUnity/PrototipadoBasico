using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator _animator;
    
    private const string IS_MOVING_HAND ="isMovingHand";
    private bool isMovingHand;


    private const string IS_MOVING_BODY = "isMovingBody";
    private bool isMovingBody;

    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private float horizontal;
    private float vertical;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool(IS_MOVING_HAND, isMovingHand);
        
    }

    // Update is called once per frame
    void Update()
    {
        MoverManos();
        MoverCuerpo();
    }


    private void MoverManos()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isMovingHand = !isMovingHand;
            
            _animator.SetBool(IS_MOVING_HAND,isMovingHand);
            
        }
        
        
    }

    private void MoverCuerpo()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (Mathf.Sqrt(horizontal * horizontal + vertical * vertical) >= 0.01)
        {
            _animator.SetBool(IS_MOVING_BODY, isMovingBody = true);
            _animator.SetFloat(HORIZONTAL, horizontal);
            _animator.SetFloat(VERTICAL, vertical);
            
            _animator.SetBool(IS_MOVING_HAND, isMovingHand = false);
            
            

        }
        else
        {
            _animator.SetBool(IS_MOVING_BODY, isMovingBody = false);
        }
        

    }
    
}

