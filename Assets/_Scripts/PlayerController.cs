using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator _animator;
    
    private const string IS_MOVING_HAND = "isMovingHand";
    private const string IS_MOVING = "isMoving";
    private const string HORIZONTAL ="horizontal";
    private const string VERTICAL = "vertical";

    [SerializeField] private bool isMovingHand;
    [SerializeField] private bool isMoving;

    private float horizontal;
    private float vertical;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        
        _animator.SetBool(IS_MOVING_HAND, isMovingHand);
        _animator.SetBool(IS_MOVING, isMoving);
        
        _animator.SetFloat(HORIZONTAL, horizontal);
        _animator.SetFloat(VERTICAL, vertical);

    }

    // Update is called once per frame
    void Update()
    {
        MoviendoManos();
        MoviendoCuerpo();
        
    }

    private void MoviendoManos()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isMovingHand = !isMovingHand;
            _animator.SetBool(IS_MOVING_HAND, isMovingHand);


        }
    }


    private void MoviendoCuerpo()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (Mathf.Sqrt(horizontal * horizontal + vertical * vertical) >= 0.01)
        {
            _animator.SetBool(IS_MOVING, isMoving = true);
            _animator.SetFloat(HORIZONTAL, horizontal);
            _animator.SetFloat(VERTICAL, vertical);
            _animator.SetBool(IS_MOVING_HAND, isMovingHand = false);
        }
        else
        {
            _animator.SetBool(IS_MOVING, isMoving = false);
        }
        


    }
}
