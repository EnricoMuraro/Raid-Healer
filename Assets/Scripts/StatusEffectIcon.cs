using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatusEffectIcon : MonoBehaviour
{

    public StatusEffectSlot statusEffectSlot;
    private Image durationImage;
    private Image abilityImage;
    private TextMeshProUGUI centerText;

    private void Awake()
    {
        durationImage = transform.Find("StatusEffectImageDuration").GetComponent<Image>();
        abilityImage = transform.Find("StatusEffectImage").GetComponent<Image>();
        centerText = GetComponentInChildren<TextMeshProUGUI>();
    }



    // Start is called before the first frame update
    void Start()
    {
        StatusEffect statusEffect = statusEffectSlot.GetStatusEffect();
        Sprite abilitySprite = statusEffect.Icon;
        durationImage.sprite = abilitySprite;
        abilityImage.sprite = abilitySprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (statusEffectSlot != null)
        {
            StatusEffect statusEffect = statusEffectSlot.GetStatusEffect();
            if (statusEffectSlot.currentDuration > 0)
            {
                durationImage.fillAmount = (statusEffectSlot.currentDuration / statusEffect.Duration);
            }

            if (statusEffect.Stacks > 0)
                centerText.text = statusEffect.Stacks.ToString();
            else
                centerText.text = "";
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
