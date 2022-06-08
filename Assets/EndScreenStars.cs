using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreenStars : MonoBehaviour
{
    public Color defaultColor;
    public Color lostColor;
    public Color earnedColor;
    public float animationTime;

    private Image[] starImages;

    private void Awake()
    {
        starImages = GetComponentsInChildren<Image>();
    }

    public void SetEarnedStars(int stars)
    {
        var seq = LeanTween.sequence();

        for (int i = 0; i < starImages.Length; i++)
        {
            Image currentStar = starImages[i];
            Color endColor = i < stars ? earnedColor : lostColor;
            seq.append(LeanTween.value(currentStar.gameObject, defaultColor, endColor, animationTime).setEaseInExpo()
                .setOnUpdate((value) => currentStar.color = value));
        }
            
    }

}
