using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalentPointsIcons : MonoBehaviour
{
    public Sprite fullIcon;
    public Sprite emptyIcon;

    public Image[] talentPointIcons;

    private void Start()
    {
        int maxtalents = GetComponentInParent<TalentPanelScript>().MaximumTalents;
        var icon = Resources.Load<GameObject>("TalentPointIcon");
        talentPointIcons = new Image[maxtalents];
        for (int i = 0; i < maxtalents; i++)
        {
            GameObject IconObject = Instantiate(icon, transform);
            talentPointIcons[i] = IconObject.GetComponent<Image>();
        }

        SetAvailableTalents(GetComponentInParent<TalentPanelScript>().AvailableTalents);
    }

    public void SetAvailableTalents(int n)
    {
        for (int i = 0; i < talentPointIcons.Length; i++)
        {
            Image icon = talentPointIcons[i];
            if (i < n)
            {
                icon.sprite = fullIcon;
                icon.color = Color.white;
            }
            else
            {
                icon.sprite = emptyIcon;
                icon.color = Color.gray;
            }
        }
    }
}
