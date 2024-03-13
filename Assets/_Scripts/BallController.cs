using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

  [SerializeField, Range(0,40)]  private float speed =6;
  [SerializeField, Range(0, 200)] private float force = 10;

  [SerializeField, Range(0, 60)] private float rotation = 180;

  [SerializeField, Range(-20, 20)] private float limite = 18;
    private Rigidbody _rigidbody;

    private float horizontal;
    private float vertical;

    public bool usePhysicsEngine;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
        MantenerPosicionLimite();
    }

    private void Movimiento()
    {
        
        
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (usePhysicsEngine)
        {
            _rigidbody.AddForce(Vector3.forward * force * vertical * Time.deltaTime, ForceMode.Force);
            _rigidbody.AddTorque(Vector3.up * force  * horizontal * Time.deltaTime, ForceMode.Force);
        }
        else
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed * vertical);
            transform.Rotate(Vector3.up * horizontal * Time.deltaTime * rotation );
        }

    }

    private void MantenerPosicionLimite()
    {
        if (transform.position.x > limite)
        {
            transform.position = new Vector3(limite, transform.position.y, transform.position.z);
        }

        if (transform.position.x < -limite)
        {
            transform.position = new Vector3(-limite, transform.position.y, transform.position.z);
        }

        if (transform.position.z > limite)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, limite);
        }

        if (transform.position.z < -limite)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -limite);
        }
        if (Mathf.Abs(transform.position.x) >= limite || Mathf.Abs(transform.position.y) >= limite)
        {
            _rigidbody.velocity = Vector3.zero;
            
            
        }

    }
}
