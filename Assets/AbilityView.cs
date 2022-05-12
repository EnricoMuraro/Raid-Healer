using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AbilityView : MonoBehaviour
{
    public TextMeshProUGUI abilityName;
    public TextMeshProUGUI abilityDescription;
    public Image abilityIcon;

    public void ShowAbility(Ability ability)
    {
        abilityName.text = ability.name;
        abilityDescription.text = ability.description;
        abilityIcon.sprite = ability.icon;
    }
}
