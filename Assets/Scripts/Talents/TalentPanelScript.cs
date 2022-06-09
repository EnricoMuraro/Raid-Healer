using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TalentPanelScript : MonoBehaviour
{
    private TalentSlot[] talentSlots;
    private int availableTalents;
    private int maximumTalents;
    [SerializeField]
    private int startingPoints;
    public TalentPointsIcons talentPointsIcons;
    public GameObject LockOverlay;
    public int AvailableTalents 
    { 
        get => availableTalents; 
        private set 
        {
            availableTalents = value;
            talentPointsIcons.SetAvailableTalents(availableTalents);
        } 
    }
    public int MaximumTalents
    {
        get => maximumTalents;
        set
        {
            maximumTalents = startingPoints + value;
            talentPointsIcons.SetMaximumTalents(maximumTalents);
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
            if (talentSlot.previousTalentSlots.Count == 0 || talentSlot.previousTalentSlots.All(x => x.IsActive()))
            {
                AvailableTalents -= 1;
                talentSlot.Activate();
            }
        }
    }

    public void DeactivateTalentSlot(TalentSlot talentSlot)
    {
        if (talentSlot.nextTalentSlots.Count == 0 || talentSlot.nextTalentSlots.All(x => !x.IsActive()))
        {
            AvailableTalents += 1;
            talentSlot.Deactivate();
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
