using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBallController : MonoBehaviour
{

    [SerializeField, Range(0,25)] private float speedMove = 8;
    [SerializeField] private float rotationGrade = 180;

    [SerializeField, Range(0, 100)] private float force = 15;
    [SerializeField, Range(0, 50)] private float torqueForce = 20;

    [SerializeField] private bool useForce;

    private float horizontal;
    private float vertical;

    [SerializeField, Range(-16, 16)] private float limite = 14;

    private Rigidbody _rigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
        LimitBounds();
    }

    private void Movimiento()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (!useForce)
        {
            transform.Translate(Vector3.forward * speedMove * Time.deltaTime * vertical);
            transform.Rotate(Vector3.up * horizontal * rotationGrade * Time.deltaTime);
            
        }
        else if (useForce)
        {
            
            _rigidbody.AddForce(Vector3.forward * force * Time.deltaTime * vertical, ForceMode.Force);
            _rigidbody.AddTorque(Vector3.up * torqueForce * horizontal * Time.deltaTime, ForceMode.Force);
            
        }


    }

    private void LimitBounds()
    {
        if (transform.position.x >= limite)
        {
            transform.position = new Vector3(limite, transform.position.y, transform.position.z);
        }

        if (transform.position.x <= -limite)
        {
            transform.position = new Vector3(-limite, transform.position.y, transform.position.z);
            
        }

        if (transform.position.z >= limite)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, limite);
            
        }

        if (transform.position.z <= -limite)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -limite);
        }
        
    }
    
}
