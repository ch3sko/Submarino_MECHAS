using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class SystemTimon : MonoBehaviour
{
    public Gauge gaugeTimon;
    public SubmarinoMovement submarino;
    public Button babor_btn;
    public Button estribor_btn;
    public TMP_InputField inputVal;
     

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (submarino.anguloTarget >= 40)
        {
            estribor_btn.interactable = false;
        }
        else
        {
            estribor_btn.interactable = true;
        }

        if (submarino.anguloTarget <= -40)
        {
            babor_btn.interactable = false;
        }
        else 
        {
            babor_btn.interactable = true;
        }
     
    }

    public void Timon()
    {
        gaugeTimon.SetValue(submarino.angulo);
    }

    public void EnterButton()
    {
       
        submarino.anguloTarget = float.Parse(inputVal.text);
        
    }

    public void BaborButton()
    {
        submarino.anguloTarget -=  5;
        Debug.Log(submarino.anguloTarget);
    }

    public void EstriborButton()
    {
        submarino.anguloTarget +=  5;
        Debug.Log(submarino.anguloTarget);
    }


    
}
