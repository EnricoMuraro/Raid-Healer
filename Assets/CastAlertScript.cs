using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CastAlertScript : MonoBehaviour
{
    private Image[] alertArrows;
    private AbilitySlot[] abilitySlots;
    public AbilityBar abilityBar;

    private void Awake()
    {
        alertArrows = GetComponentsInChildren<Image>();
        foreach (Image icon in alertArrows)
            icon.canvasRenderer.SetAlpha(0);

        abilitySlots = abilityBar.transform.GetComponentsInChildren<AbilitySlot>();
    }

    private void Start()
    {
        for(int i = 0; i < abilitySlots.Length; i++)
        {
            abilitySlots[i].onStateChange.AddListener(DisplayAlert);
        }
    }

    private void DisplayAlert(AbilitySlot abilitySlot)
    {
        if(abilitySlot.State == AbilitySlot.AbilityState.casting)
        {
            (_, int col) = abilitySlot.Raid.ArrayIndexToMatrixCoords(abilitySlot.TargetIndex);

            if (abilitySlot.ability is Pierce)
                AnimateAlert(col, abilitySlot.ability.CastTime);
        }

    }

    private void AnimateAlert(int col, float time)
    {
        Image arrow = alertArrows[col];
        arrow.canvasRenderer.SetAlpha(1);
        arrow.color = Color.red;

        Debug.Log("Animating arrow");
        var seq = LeanTween.sequence();

        seq.append(LeanTween.color(arrow.gameObject, Color.yellow, time / 2));
        seq.append(LeanTween.scale(arrow.gameObject, new Vector3(1.2f, 1.2f, 1.2f), time/2).setEaseInBounce());
        seq.append(LeanTween.color(arrow.gameObject, Color.white, time / 2)
            .setOnComplete(() => arrow.canvasRenderer.SetAlpha(0)));
    }
}
