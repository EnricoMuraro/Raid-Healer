using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalentPanelScript : MonoBehaviour
{
    [SerializeField]
    private TalentSlot[] talentSlots;
    private int availableTalents;
    private int maximumTalents;
    public TalentPointsIcons talentPointsIcons;


    private void Awake()
    {
        availableTalents = 10;
        maximumTalents = 10;
    }

    public void Start()
    {
        talentSlots = GetComponentsInChildren<TalentSlot>();
    }

    public void ResetSelectedTalents()
    {
        foreach (var talentSlot in talentSlots)
            talentSlot.Deactivate();
        availableTalents = maximumTalents;
        talentPointsIcons.SetAvailableTalents(availableTalents);
    }

    public void ActivateTalentSlot(TalentSlot talentSlot)
    {

        if (availableTalents > 0 )
        {
            if (talentSlot.previousTalentSlot == null || talentSlot.previousTalentSlot.IsActive())
            {
                talentSlot.Activate();
                availableTalents -= 1;
            }
        }

        talentPointsIcons.SetAvailableTalents(availableTalents);
    }

    public void DeactivateTalentSlot(TalentSlot talentSlot)
    {
        if (talentSlot.nextTalentSlot == null || !talentSlot.nextTalentSlot.IsActive())
        {
            talentSlot.Deactivate();
            availableTalents += 1;
        }

        talentPointsIcons.SetAvailableTalents(availableTalents);
    }

    public void ToggleActivation(TalentSlot talentSlot)
    {
        if (talentSlot.IsActive())
            DeactivateTalentSlot(talentSlot);
        else
            ActivateTalentSlot(talentSlot);
    }
}
