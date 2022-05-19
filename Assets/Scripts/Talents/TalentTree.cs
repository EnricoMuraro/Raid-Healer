using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TalentTree : ScriptableObject
{
    public List<Talent> AllTalents;
    public List<Talent> ActiveTalents;

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
                activeTalents.Add(GetTalentByID(ID));

        ActiveTalents = activeTalents;
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
        foreach(var talent in ActiveTalents)
             if(talent is PassiveTalent passiveTalent)
                passiveTalent.ApplyPassiveEffects();
    }

    public void DeactivatePassiveTalents()
    {
        foreach(var talent in ActiveTalents)
            if (talent is PassiveTalent passiveTalent)
                foreach (var passiveEffect in passiveTalent.passiveEffects)
                    foreach (var ability in passiveEffect.affectedAbilities)
                        ability.RemoveModifiersBySource(AbilityModifier.Source.Talent);

    }

}
