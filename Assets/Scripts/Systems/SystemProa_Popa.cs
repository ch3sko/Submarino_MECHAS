using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class SystemProa_Popa : MonoBehaviour
{
    public SubmarinoMovement submarino;

    public Gauge gaugeProa, gaugePopa;

    public Button subirProa_btn;
    public Button bajarProa_btn;
    public Button enterProa_btn;

    public TMP_InputField inputValProa;

    public Image indicBloqueo;


    public Button subirPopa_btn;
    public Button bajarPopa_btn;
    public Button enterPopa_btn;

    public TMP_InputField inputValPopa;


    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        IndicadorBloqueo();
       

    }

    public void ProaPopa() {

     
        gaugeProa.SetValue(submarino.anguloProa);
        gaugePopa.SetValue(submarino.anguloPopa);
        Disable_Enable_Buttons();


    }

    public void SubirProaButton()
    {
        submarino.anguloInclinacion += 5;
      
        Debug.Log(submarino.anguloInclinacion);
    }

    public void BajarProaButton()
    {
        submarino.anguloInclinacion -= 5;
       
        Debug.Log(submarino.anguloInclinacion);
    }

    public void EnterButtonProa() 
    {
        submarino.anguloInclinacion = float.Parse(inputValProa.text);
    }

    public void SubirPopa() 
    {
        submarino.anguloInclinacion += 5;
        
        Debug.Log(submarino.anguloInclinacion);
    }

    public void BajarPopa()
    {
        submarino.anguloInclinacion -= 5;
       
        Debug.Log(submarino.anguloInclinacion);
    }
    public void EnterButtonPopa()
    {
        submarino.anguloInclinacion = float.Parse(inputValPopa.text);
    }

    public void IndicadorBloqueo()
    {
        if (submarino.KPH >= 88)
        {
            indicBloqueo.color = Color.green;
        }
        else
        {
            indicBloqueo.color = Color.grey;
        }
    }

    void Disable_Enable_Buttons() 
    {
        if (submarino.anguloInclinacion > 40)
        {
            subirProa_btn.interactable = false;
        }
        else if (submarino.anguloInclinacion < -40)
        {
            bajarProa_btn.interactable = false;
        }
    }
   

}
