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
        talentPointIcons = GetComponentsInChildren<Image>();
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
                icon.color = Color.black;
            }
        }
    }
}
