using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AbilitySlotIcon : MonoBehaviour
{

    public AbilitySlot abilitySlot;
    private Image cooldownImage;
    private Image abilityImage;
    private TextMeshProUGUI manaText;

    private void Awake() {
        cooldownImage = transform.Find("AbilityIconCooldown").GetComponent<Image>();
        abilityImage = transform.Find("AbilityIcon").GetComponent<Image>();
        manaText = transform.Find("ManaText").GetComponent<TextMeshProUGUI>();
    }



    // Start is called before the first frame update
    void Start()
    {   

    }

    // Update is called once per frame
    void Update()
    {

        if(abilitySlot != null && abilitySlot.ability != null) 
        {
            cooldownImage.sprite = abilitySlot.ability.icon;
            abilityImage.sprite = abilitySlot.ability.icon;
            if (abilitySlot.ability is ActiveAbility activeAbility)
            {
                manaText.text = activeAbility.ManaCost.ToString();
                if (activeAbility.Cooldown > 0 && abilitySlot.CurrentCooldown >= 0)
                {
                    cooldownImage.fillAmount = (abilitySlot.CurrentCooldown / activeAbility.Cooldown);
                }
            }

        }
    }
}
