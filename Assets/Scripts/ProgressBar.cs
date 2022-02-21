using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProgressBar : MonoBehaviour
{

    public Slider progressBar;
    public TextMeshProUGUI progressBarText;
    public GameObject statusEffectsBar;

    public bool displayValues = true;

    private void Awake() 
    {
        
        progressBar = GetComponent<Slider>();
        progressBarText = GetComponentInChildren<TextMeshProUGUI>();
    }

    void Start()
    {
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

    public void SetText(string text)
    {
        progressBarText.text = text;
    }

    // Update is called once per frame
    void Update()
    {
        if(displayValues)
        {
            progressBarText.text = progressBar.value + "/" + progressBar.maxValue;
        }
    }
}
