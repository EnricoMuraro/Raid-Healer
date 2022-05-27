using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalentPanelScript : MonoBehaviour
{
    private TalentSlot[] talentSlots;
    private int availableTalents;
    private int maximumTalents;
    [SerializeField]
    private int startingPoints;
    public TalentPointsIcons talentPointsIcons;

    public int AvailableTalents 
    { 
        get => availableTalents; 
        private set 
        {
            availableTalents = value;
            talentPointsIcons.SetAvailableTalents(availableTalents);
            Debug.Log("available talents: " + availableTalents);
        } 
    }
    public int MaximumTalents
    {
        get => maximumTalents;
        set
        {
            maximumTalents = startingPoints + value;
            AvailableTalents = maximumTalents;
            Debug.Log("Maximum talents: " + maximumTalents);
        }
    }

    private void Awake()
    {
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

    public void SetActiveTalents(List<Talent> activeTalents)
    {
        AvailableTalents = MaximumTalents;
        foreach (TalentSlot talentSlot in talentSlots)
            talentSlot.Deactivate();

        foreach (TalentSlot talentSlot in talentSlots)
        {
            foreach (Talent talent in activeTalents)
            {
                if (talentSlot.talent.ID == talent.ID)
                {
                    talentSlot.Activate();
                    AvailableTalents -= 1;
                }
            }
        }

    }

    public void ResetSelectedTalents()
    {
        foreach (var talentSlot in talentSlots)
            talentSlot.Deactivate();
        AvailableTalents = MaximumTalents;
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
