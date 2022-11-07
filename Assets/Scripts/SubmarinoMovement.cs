using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmarinoMovement : MonoBehaviour
{

    [HideInInspector]
    public float curSpeed;

    public float speedChangeAmount;
    public float maxForwardSpeed;
    public float maxBackwardSpeed;
    public float minSpeed;
    public float turnSpeed;
    public float riseSpeed;

    public float stabilizationSmoothing;

    public float KPH;

    public Rigidbody subRb;

    private void Start()
    {       
        subRb = GetComponent<Rigidbody>();       
    }

    void FixedUpdate()
    {
        Move();
        Turn();
        Rise();
        Stabilize();

        KPH = ((subRb.velocity.magnitude)/2) *10; // NOTA: estoy hacienod trampa para que el medidor me de el valor que se ingresa enla casilla                    
    }

    void Move()
    {
        /*if (Input.GetKey(KeyCode.W))
        {
            curSpeed += speedChangeAmount;
        }

        else if (Input.GetKey(KeyCode.S))
        {
            curSpeed -= speedChangeAmount;
        }

        else*/ if (Mathf.Abs(curSpeed) <= minSpeed)
        {
            curSpeed = 0;
        }
        curSpeed = Mathf.Clamp(curSpeed, -maxBackwardSpeed, maxForwardSpeed);
        subRb.AddForce(transform.forward * curSpeed);
    }

    void Turn()
    {
        if (Input.GetKey(KeyCode.D))
        {
            subRb.AddTorque(transform.up * turnSpeed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            subRb.AddTorque(transform.up * -turnSpeed);
        }

    }

    void Rise()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            subRb.AddForce(transform.up * riseSpeed);
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            subRb.AddForce(transform.up * -riseSpeed);
        }
    }

    void Stabilize()
    {
        subRb.MoveRotation(Quaternion.Slerp(subRb.rotation, Quaternion.Euler(new Vector3(0, subRb.rotation.eulerAngles.y, 0)), stabilizationSmoothing));
    }
  
}
