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

    private float barWidth;
    private Object AbilityIcon;

    void Awake()
    {
        abilitySlots = abilityBar.GetAbilitySlots();
        icons = new GameObject[abilitySlots.Length];

        barWidth = GetComponent<Image>().rectTransform.rect.width;
        AbilityIcon = Resources.Load("AbilityIcon");

        for (int i = 0; i < abilitySlots.Length; i++)
        {
            abilitySlots[i].onCooldownStart.AddListener(AbilityTimerAnimation);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    void AbilityTimerAnimation(AbilitySlot abilitySlot)
    {

        GameObject icon = Instantiate(AbilityIcon) as GameObject;
        icon.transform.SetParent(transform, false);
        icon.GetComponent<Image>().sprite = abilitySlot.ability.icon;
        icon.transform.localPosition = new Vector3((abilitySlot.CurrentCooldown / MaxTime - 0.5f) * barWidth, 0, 0);

        var seq = LeanTween.sequence();
        //Fade in
        seq.insert(LeanTween.scale(icon, new Vector3(1, 1, 1), 0.4f));

        //Move icon 
        seq.append(LeanTween.moveLocalX(icon, -0.5f * barWidth, abilitySlot.CurrentCooldown));

        //Fade out and destroy the icon GameObject
        seq.append(LeanTween.scale(icon, new Vector3(0, 0, 0), 0.1f).setDestroyOnComplete(true));

    }

    // Update is called once per frame
    void Update()
    {
        /*

        for (int i = 0; i < icons.Length; i++)
        {
            AbilitySlot abilitySlot = abilitySlots[i];
            GameObject icon = icons[i];

            if (0 < abilitySlot.CurrentCooldown && abilitySlot.CurrentCooldown < MaxTime)
            {
                icon.SetActive(true);
                float newPos = Mathf.Clamp((abilitySlot.CurrentCooldown / MaxTime) * barWidth, 0, barWidth);
                Debug.Log(newPos);
                Debug.Log(icon.transform.localPosition);
            }
            else
            {
                icon.SetActive(false);
            }
        }    
        */
    }
}
