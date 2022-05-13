using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilitySlotIcon : MonoBehaviour
{

    public AbilitySlot abilitySlot;
    private Image cooldownImage;
    private Image abilityImage;

    private void Awake() {
        cooldownImage = transform.Find("AbilityIconCooldown").GetComponent<Image>();
        abilityImage = transform.Find("AbilityIcon").GetComponent<Image>();
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
            if (abilitySlot.ability.Cooldown > 0 && abilitySlot.CurrentCooldown >= 0)
            {
                cooldownImage.fillAmount = (abilitySlot.CurrentCooldown/abilitySlot.ability.Cooldown);
            }
        }
    }
}
