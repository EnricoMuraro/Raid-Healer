using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TalentTree : ScriptableObject
{
    public List<Talent> AllTalents;
    public List<Talent> ActiveTalents;
    [SerializeField]
    private int[] maximumPointsPerPanel;

    public int[] MaximumPointsPerPanel { get => maximumPointsPerPanel; set => maximumPointsPerPanel = value; }

    private void OnEnable() => hideFlags = HideFlags.DontUnloadUnusedAsset;
    public Talent GetTalentByID(int ID)
    {
        foreach(Talent t in AllTalents)
            if(t.ID == ID)
                return t;

        return null;
    }

    public void SetActiveTalents(int[] activeTalentsIDs)
    {
        List<Talent> activeTalents = new();

        if (activeTalentsIDs != null)
            foreach (int ID in activeTalentsIDs)
            {
                Talent t = GetTalentByID(ID);
                if (t != null)
                    activeTalents.Add(t);
            }

        ActiveTalents = activeTalents;
    }

    public void AddMaximumPoints(int panel, int points)
    {
        if (panel >= maximumPointsPerPanel.Length)
            SetMaximumPoints(panel, points);
        else
            SetMaximumPoints(panel, maximumPointsPerPanel[panel] + points);
    }

    public void SetMaximumPoints(int panel, int points)
    {
        if(panel >= maximumPointsPerPanel.Length)
        {
            int[] newArray = new int[panel+1];
            maximumPointsPerPanel.CopyTo(newArray, 0);
            maximumPointsPerPanel = newArray;
        }
        maximumPointsPerPanel[panel] = points;
    }

    public List<AbilityTalent> GetActiveAbilityTalents()
    {
        List<AbilityTalent> abilityTalents = new();
        foreach (Talent t in ActiveTalents)
            if(t is AbilityTalent abilityTalent)
                abilityTalents.Add(abilityTalent);
        return abilityTalents;
    }

    public void ActivatePassiveTalents()
    {
        foreach (var talent in ActiveTalents)
            if (talent is PassiveTalent passiveTalent)
            {
                foreach (var abilityModifier in passiveTalent.abilityModifiers)
                    abilityModifier.ApplyModifier();

                foreach (var unitStatModifier in passiveTalent.unitStatModifiers)
                    unitStatModifier.ApplyModifier();

                foreach (var statusEffectModifier in passiveTalent.statusEffectModifiers)
                    statusEffectModifier.ApplyModifier();
            }
                
    }

    public void DeactivatePassiveTalents()
    {
        foreach(var talent in ActiveTalents)
            if (talent is PassiveTalent passiveTalent)
            {
                foreach (var abilityModifier in passiveTalent.abilityModifiers)
                    abilityModifier.RemoveModifier();

                foreach (var unitStatModifier in passiveTalent.unitStatModifiers)
                    unitStatModifier.RemoveModifier();

                foreach (var statusEffectModifier in passiveTalent.statusEffectModifiers)
                    statusEffectModifier.RemoveModifier();
            }

    }

    public void DeactivateAllPassiveTalents()
    {
        foreach (var talent in AllTalents)
            if (talent is PassiveTalent passiveTalent)
            {
                foreach (var abilityModifier in passiveTalent.abilityModifiers)
                    abilityModifier.RemoveModifier();

                foreach (var unitStatModifier in passiveTalent.unitStatModifiers)
                    unitStatModifier.RemoveModifier();

                foreach (var statusEffectModifier in passiveTalent.statusEffectModifiers)
                    statusEffectModifier.RemoveModifier();
            }
    }

}
