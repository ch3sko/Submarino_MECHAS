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
    public float minRotation;
    public float maxRotation;
    public float riseSpeed;

    public float stabilizationSmoothing;

    public float KPH;
    public float angulo;
    public float anguloProa;
    public float anguloPopa;
    public float anguloTimon;
    public float anguloInclinacion;

    public Rigidbody subRb;

    Vector3 myRotation;
   public Vector3 _rotation;
    

    private void Start()
    {
        subRb = GetComponent<Rigidbody>();
      
    }

    void FixedUpdate()
    {
        Move();
        rotationTimon();

   
            rotationProa();
        
        
    

        Debug.Log(anguloInclinacion);
     
        ///NOTA: ayuda con el movimiento de las agujas que sean suaves
        KPH = ((subRb.velocity.magnitude) / 2) * 10; // NOTA: estoy hacienod trampa para que el medidor me de el valor que se ingresa enla casilla
        angulo = (subRb.rotation.eulerAngles.y) * 2; // NOTA: hacinodo trampa nuevamente
        anguloProa = (subRb.rotation.eulerAngles.x)*2;  //   NOTA: hacinodo trampa nuevamente
        anguloPopa = (subRb.rotation.eulerAngles.x) * -2;  //   NOTA: hacinodo trampa nuevamente 

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

        else*/
        if (Mathf.Abs(curSpeed) <= minSpeed)
        {
            curSpeed = 0;
        }
       // curSpeed = Mathf.Clamp(curSpeed, -maxBackwardSpeed, maxForwardSpeed);
        subRb.AddForce(transform.forward * curSpeed);
     
    }

   /* private void LimitRot()
    {
        myRotation = transform.rotation.eulerAngles;
        myRotation.y = (myRotation.y > 180) ? myRotation.y - 360 : myRotation.y;
        myRotation.y = Mathf.Clamp(myRotation.y, minRotation, maxRotation);
        transform.rotation = Quaternion.Euler(myRotation);

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
   */
    void rotationTimon() 
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, anguloTimon*2, 0), Time.deltaTime *turnSpeed);
    }

    void rotationProa()
    {
        if (anguloInclinacion > 40)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(-40, 0, 0), Time.deltaTime * turnSpeed);
        }
        else if (anguloInclinacion < -40)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(40, 0, 0), Time.deltaTime * turnSpeed);
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler((anguloInclinacion) * -1, 0, 0), Time.deltaTime * turnSpeed);
        }

        Debug.Log(anguloInclinacion);
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
