using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemSubmarino : MonoBehaviour
{
   // public SubmarinoMovement submarinoMovement;
    public SystemPropulsion systemPropulsion;
    public SystemProa_Popa systemProa_Popa;
    public SystemTimon systemTimon;
 

  
    void Start()
    {
        
    }

    void Update()
    {
        systemPropulsion.Propulsion();
        systemTimon.Timon();

    }
}
