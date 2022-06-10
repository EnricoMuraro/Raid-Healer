using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProgressBar : MonoBehaviour
{

    private Slider[] progressBars;
    private TextMeshProUGUI progressBarText;
    private Transform statusEffectsBar;
    private Object StatusEffectFrameIcon;

    public bool displayValues = true;

    private void Awake() 
    {
        progressBars = GetComponentsInChildren<Slider>();
        progressBarText = GetComponentInChildren<TextMeshProUGUI>();
        statusEffectsBar = transform.Find("StatusEffectBar");
        StatusEffectFrameIcon = Resources.Load("StatusEffectFrameIcon");
    }

    void Start()
    {
    }
    
    public void AddStatusEffectFrameIcon(StatusEffectSlot statusEffectSlot, float scale = 1)
    {
        GameObject icon = Instantiate(StatusEffectFrameIcon, statusEffectsBar) as GameObject;
        icon.transform.localScale = Vector3.one * scale;
        icon.GetComponent<StatusEffectIcon>().statusEffectSlot = statusEffectSlot;
    }

    public void SetMaxValue(float maxValue, int progressBarIndex = 0) 
    {
        progressBars[progressBarIndex].maxValue = maxValue;
    }

    public void SetValue(float value, int progressBarIndex = 0)
    {
        progressBars[progressBarIndex].value = value;
    }

    public void SetText(string text, int progressBarIndex = 0)
    {
        progressBarText.text = text;
    }

    // Update is called once per frame
    void Update()
    {
        if(displayValues)
        {
            progressBarText.text = progressBars[0].value + "/" + progressBars[0].maxValue;
        }
    }
}
