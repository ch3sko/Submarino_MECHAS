using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class SystemPropulsion : MonoBehaviour
{

    public Gauge gaugePropulsion;

    public SubmarinoMovement submarino;

   // private float rpm;

    public Button avante_btn;
    public Button atras_btn;
    public Button acelerar_btn;
    public Button enter_btn;
    public Button ralentizar_btn;
    public TMP_InputField inputVal;
    public Image indicAvante;
    public Image indicAtras;
    public TextMeshProUGUI etapaMarchaTxt;

    private bool _isAcelerar = false; // is forward 
    private bool _isRalentizar = false; // is retro

    void Start()
    {
        indicAvante.color = Color.grey;
        indicAtras.color = Color.grey;

        inputVal.interactable = false;
        enter_btn.interactable = false;
        avante_btn.interactable = false;
        atras_btn.interactable = false;

    }


    void Update()
    {       

        if (_isAcelerar && (submarino.curSpeed) == 0)
        {
            atras_btn.interactable = false;
        }
        else if (_isAcelerar && (submarino.curSpeed)> 0)
        {
            atras_btn.interactable = true;
        }

        if (_isRalentizar && (submarino.curSpeed) == 0)
        {
            atras_btn.interactable = false;
        }
        else if (_isRalentizar && (submarino.curSpeed) !=0)
        {
            atras_btn.interactable = true;
        }
    }

    public void Propulsion()
    {
        gaugePropulsion.SetValue((submarino.KPH));   

           
        EtapaMarcha();
    }

    private bool _AcelerarButton = false;
    
    public bool AcelerarBurron
    {
        get { return _AcelerarButton; }
        set 
        {
            indicAvante.color = Color.green;
            indicAtras.color = Color.grey;
            _AcelerarButton = value;
            _isAcelerar = true;
            _isRalentizar = false;
            inputVal.text = "0";
            EnableButtons();
        }
    }

    private bool _RalentizarButton = false;

    public bool RalentizarButton
    {
        get { return _RalentizarButton; }
        set 
        {
            indicAtras.color = Color.green;
            indicAvante.color = Color.grey;
            _AcelerarButton = value;
            _isAcelerar = false;
            _isRalentizar = true;
            inputVal.text = "0";
            EnableButtons();
        }
    }

    public void EnableButtons()
    {
        inputVal.interactable = true;
        enter_btn.interactable = true;

    }

    public void EtapaMarcha()
    {
        if (_isAcelerar)
        {
            if (submarino.KPH < 40)
            {
                etapaMarchaTxt.text = "II";
            }
            else if (submarino.KPH >= 40 && submarino.KPH < 90)
            {
                etapaMarchaTxt.text = "III";
            }
            else if (submarino.KPH >= 90 && submarino.KPH < 175)
            {
                etapaMarchaTxt.text = "IV";
            }

            else if (submarino.KPH >= 175 && submarino.KPH < 200)
            {
                etapaMarchaTxt.text = "V";
            }

        }
        else if (_isRalentizar)
        {
            if (submarino.KPH < 40)
            {
                etapaMarchaTxt.text = "II";
            }
            else if (submarino.KPH >= 40 && submarino.KPH < 90)
            {
                etapaMarchaTxt.text = "III";
            }
        }
       
      
    }

    public void EnterButton()
    {

        if (_isAcelerar)
        {
            if (float.Parse(inputVal.text) >= 0)
                submarino.curSpeed = float.Parse(inputVal.text);
            else
                inputVal.text = "ERROR";
        }
        else if (_isRalentizar)
        {
            if (float.Parse(inputVal.text) >= 0)
                submarino.curSpeed = -( float.Parse(inputVal.text));
            else
                inputVal.text = "ERROR";
        }
     

        avante_btn.interactable = true;
        atras_btn.interactable = true;
    }

    public void AvanteButton()
    {
        if (_isAcelerar)
        {
            submarino.curSpeed += submarino.speedChangeAmount;
            Debug.Log(submarino.curSpeed);
        }
        else if (_isRalentizar)
        {
            submarino.curSpeed -= submarino.speedChangeAmount;
            Debug.Log(submarino.curSpeed);
        }
        
    }

    public void AtrasButton()
    {
        if (_isAcelerar)
        {
            submarino.curSpeed -= submarino.speedChangeAmount;
            Debug.Log(submarino.curSpeed);
        }
        else if (_isRalentizar)
        {
            submarino.curSpeed += submarino.speedChangeAmount;
            Debug.Log(submarino.curSpeed);
        }
    }

}
