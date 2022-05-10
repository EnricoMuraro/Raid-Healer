using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TalentView : MonoBehaviour
{
    public Image talentIcon;
    public TextMeshProUGUI talentName;
    public TextMeshProUGUI talentDescription;

    public void Awake()
    {
        gameObject.SetActive(false);
    }

    public void showTalent(Talent talent)
    {
        gameObject.SetActive(true);
        talentIcon.sprite = talent.sprite;
        talentName.text = talent.name;
        talentDescription.text = talent.description;
    }
}
