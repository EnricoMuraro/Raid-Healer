using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusEffectIcon : MonoBehaviour
{

    public StatusEffectSlot statusEffectSlot;
    private Image durationImage;
    private Image abilityImage;

    private void Awake()
    {
        durationImage = transform.Find("StatusEffectIconDuration").GetComponent<Image>();
        abilityImage = transform.Find("StatusEffectIcon").GetComponent<Image>();
    }



    // Start is called before the first frame update
    void Start()
    {
        if (statusEffectSlot != null)
        {
            StatusEffect statusEffect = statusEffectSlot.GetStatusEffect();
            if (statusEffect != null)
            {
                Sprite abilitySprite = statusEffect.Icon;
                durationImage.sprite = abilitySprite;
                abilityImage.sprite = abilitySprite;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (statusEffectSlot != null)
        {
            StatusEffect statusEffect = statusEffectSlot.GetStatusEffect();
            if (statusEffect != null)
            {
                if (statusEffectSlot.currentDuration > 0)
                {
                    durationImage.fillAmount = (statusEffectSlot.currentDuration / statusEffect.Duration);
                }
            }
        }
    }
}
