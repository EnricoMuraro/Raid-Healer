using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalentPointsIcons : MonoBehaviour
{
    public Sprite fullIcon;
    public Sprite emptyIcon;

    public Image[] talentPointIcons;

    private GameObject icon;

    private void Awake()
    {
        icon = Resources.Load<GameObject>("TalentPointIcon");
    }

    public void SetMaximumTalents(int maxTalents)
    {
        talentPointIcons = new Image[maxTalents];
        for (int i = 0; i < maxTalents; i++)
        {
            GameObject IconObject = Instantiate(icon, transform);
            talentPointIcons[i] = IconObject.GetComponent<Image>();
        }
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
