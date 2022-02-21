using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProgressBar : MonoBehaviour
{

    private Slider progressBar;
    private TextMeshProUGUI progressBarText;
    private Transform statusEffectsBar;
    private Object StatusEffectFrameIcon;

    public bool displayValues = true;

    private void Awake() 
    {
        
        progressBar = GetComponent<Slider>();
        progressBarText = GetComponentInChildren<TextMeshProUGUI>();
        statusEffectsBar = transform.Find("StatusEffectBar");
        StatusEffectFrameIcon = Resources.Load("StatusEffectFrameIcon");
    }

    void Start()
    {
        progressBar.maxValue = 100;
        progressBar.value = 0;
    }
    
    public void AddStatusEffectFrameIcon(StatusEffectSlot statusEffectSlot)
    {
        GameObject icon = Instantiate(StatusEffectFrameIcon, statusEffectsBar) as GameObject;
        icon.GetComponent<StatusEffectIcon>().statusEffectSlot = statusEffectSlot;
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
