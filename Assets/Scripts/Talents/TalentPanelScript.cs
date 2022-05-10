using System;
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

    public int AvailableTalents 
    { 
        get => availableTalents; 
        private set 
        {
            availableTalents = value;
            talentPointsIcons.SetAvailableTalents(availableTalents);
        } 
    }
    public int MaximumTalents { get => maximumTalents;}

    private void Awake()
    {
        AvailableTalents = 10;
        maximumTalents = 10;

        talentSlots = GetComponentsInChildren<TalentSlot>();
    }

    public Talent[] GetActiveTalents()
    {
        List<Talent> talents = new();
        foreach (var talentSlot in talentSlots)
            if (talentSlot.IsActive())
                talents.Add(talentSlot.talent);
        return talents.ToArray();
    }

    public void Load(int[] activeTalentsIDs)
    {
        AvailableTalents = maximumTalents;

        foreach (TalentSlot talentSlot in talentSlots)
        {
            for (int i = 0; i < activeTalentsIDs.Length; i++)
            {
                if (talentSlot.talent.ID == activeTalentsIDs[i])
                {
                    talentSlot.Activate();
                    AvailableTalents -= 1;
                    break;
                }
                else
                    talentSlot.Deactivate();
            }
        }

    }

    public void ResetSelectedTalents()
    {
        foreach (var talentSlot in talentSlots)
            talentSlot.Deactivate();
        AvailableTalents = maximumTalents;
    }

    public void ActivateTalentSlot(TalentSlot talentSlot)
    {

        if (AvailableTalents > 0 )
        {
            if (talentSlot.previousTalentSlot == null || talentSlot.previousTalentSlot.IsActive())
            {
                talentSlot.Activate();
                AvailableTalents -= 1;
            }
        }
    }

    public void DeactivateTalentSlot(TalentSlot talentSlot)
    {
        if (talentSlot.nextTalentSlot == null || !talentSlot.nextTalentSlot.IsActive())
        {
            talentSlot.Deactivate();
            AvailableTalents += 1;
        }
    }

    public void ToggleActivation(TalentSlot talentSlot)
    {
        if (talentSlot.IsActive())
            DeactivateTalentSlot(talentSlot);
        else
            ActivateTalentSlot(talentSlot);
    }
}
