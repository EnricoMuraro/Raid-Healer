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

            if (abilitySlot.ability is Pierce pierceAbility)
                AnimateAlert(col, pierceAbility.CastTime);
        }

    }

    private void AnimateAlert(int col, float time)
    {
        Image arrow = alertArrows[col];
        arrow.canvasRenderer.SetAlpha(1);
        arrow.gameObject.transform.localScale = Vector3.one;
        arrow.color = Color.red;

        var seq = LeanTween.sequence();

        seq.insert(LeanTween.moveLocalY(arrow.gameObject, 30, time/2).setEasePunch());
        seq.insert(LeanTween.value(arrow.gameObject, Color.red, Color.yellow, time/2)
            .setOnUpdate((value) => arrow.color = value)
            .setOnComplete(() => arrow.canvasRenderer.SetAlpha(0)));
    }
}
