using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TalentTree : ScriptableObject
{
    public Talent[] AllTalents;
    public Talent[] ActiveTalents;

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

        ActiveTalents = activeTalents.ToArray();
    }

    public void ActivatePassiveTalents()
    {
        foreach(var talent in ActiveTalents)
             if(talent is PassiveTalent passiveTalent)
                passiveTalent.ApplyPassiveEffects();
    }

}
