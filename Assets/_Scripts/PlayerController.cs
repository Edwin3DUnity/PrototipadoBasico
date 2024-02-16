using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator _animator;

    private const string MOVE_HANDS = "Move Hands";
    private bool isMovingHangs;
    
    
    // Start is called before the first frame update
    void Start()
    {

        _animator = GetComponent<Animator>();
        _animator.SetBool(MOVE_HANDS, isMovingHangs);
        

    }

    // Update is called once per frame
    void Update()
    {
        
        
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            isMovingHangs = !isMovingHangs;
            _animator.SetBool(MOVE_HANDS, isMovingHangs);
        }
    }
}
