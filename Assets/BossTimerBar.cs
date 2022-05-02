using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossTimerBar : MonoBehaviour
{
    public AbilityBar abilityBar;
    public float MaxTime;
    

    private AbilitySlot[] abilitySlots;
    private GameObject[] icons;

    void Awake()
    {
        abilitySlots = abilityBar.GetAbilitySlots();
        icons = new GameObject[abilitySlots.Length];
        
    }

    // Start is called before the first frame update
    void Start()
    {
        Object AbilityIcon = Resources.Load("AbilityIcon");
        for(int i = 0; i < abilitySlots.Length; i++)
        {
            icons[i] = Instantiate(AbilityIcon) as GameObject;
            icons[i].transform.SetParent(transform, false);
            icons[i].GetComponent<Image>().sprite = abilitySlots[i].ability.icon;
        }    
    }

    // Update is called once per frame
    void Update()
    {
        float barWidth = GetComponent<Image>().rectTransform.rect.width;
        Debug.Log("bar width " + barWidth);

        for (int i = 0; i < icons.Length; i++)
        {
            AbilitySlot abilitySlot = abilitySlots[i];
            GameObject icon = icons[i];

            if (0 < abilitySlot.CurrentCooldown && abilitySlot.CurrentCooldown < MaxTime)
            {
                icon.SetActive(true);
                float newPos = Mathf.Clamp((abilitySlot.CurrentCooldown / MaxTime) * barWidth, 0, barWidth);
                Debug.Log(newPos);
                icon.transform.localPosition = new Vector3(newPos-(barWidth/2), 0, 0);
                Debug.Log(icon.transform.localPosition);
            }
            else
            {
                icon.SetActive(false);
            }
        }    
    }
}
