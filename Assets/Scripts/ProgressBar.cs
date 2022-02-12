using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{

    public Slider progressBar;


    void Start()
    {
        progressBar = GetComponent<Slider>();
        progressBar.maxValue = 100;
        progressBar.value = 0;
    }

    public void SetMaxValue(float maxValue) 
    {
        progressBar.maxValue = maxValue;
    }

    public void SetValue(float value)
    {
        progressBar.value = value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
