using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gauge : MonoBehaviour
{
    public GameObject needle;
    public float maxVal;
    public float startPos, endPos;
    private float desiredPos;

    public void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void SetValue(float val)
    {
        desiredPos = startPos - endPos;
        float temp = val / maxVal;
        needle.transform.eulerAngles = new Vector3(0, 0, (startPos - temp * desiredPos));
        val = Mathf.Clamp(val, 0f, maxVal);
    }

}
