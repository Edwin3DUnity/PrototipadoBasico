using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class ControladorPersonaje : MonoBehaviour
{

    private Animator _animator;

    private const string IS_MOVING_HAND = "isMovingHand";


    public bool isMovingHand;
    
    private const string IS_MOVING_BODY ="isMovingBody";
    private const string HORIZONTAL ="Horizontal";
    private const string VERTICAL = "Vertical";

    private bool isMovingBody;

    private float horizontal;
    private float vertical;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        
        _animator.SetBool(IS_MOVING_HAND, isMovingHand);
        _animator.SetBool(IS_MOVING_BODY, isMovingBody);
        
        _animator.SetFloat(HORIZONTAL, horizontal);
        _animator.SetFloat(VERTICAL, vertical);
        
    }

    // Update is called once per frame
    void Update()
    {
     MoverMano();   
     MoverCuerpo();
    }

    private void MoverMano()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isMovingHand = !isMovingHand;
            
            _animator.SetBool(IS_MOVING_HAND, isMovingHand);

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
            _animator.SetBool(IS_MOVING_HAND,isMovingHand = false);
        }
        else
        {
            _animator.SetBool(IS_MOVING_BODY, isMovingBody = false);
        }
        
        
    }
}
