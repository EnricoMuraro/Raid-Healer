using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalentManager : MonoBehaviour
{
    private TalentPanelScript[] talentPanels;

    public TalentTree talentTree;
    public TalentView talentView;

    private void Awake()
    {
        talentPanels = GetComponentsInChildren<TalentPanelScript>();
    }

    public void Start()
    {
        LoadTalents();
    }

    public void LoadTalents()
    {
        int[] MaxPoints = new int[talentPanels.Length];
        talentTree.MaximumPointsPerPanel.CopyTo(MaxPoints, 0);

        for (int i = 0; i < talentPanels.Length; i++)
        {
            talentPanels[i].MaximumTalents = MaxPoints[i];
            talentPanels[i].SetActiveTalents(talentTree.ActiveTalents);
            if (MaxPoints[i] == 0)
                talentPanels[i].LockOverlay.SetActive(true);
        }
    }

    public void SaveTalents()
    {   
        List<Talent> talents = new();
        List<int> talentIDs = new();
        foreach (var talentPanel in talentPanels)
        {
            foreach (Talent talent in talentPanel.GetActiveTalents())
            {
                talents.Add(talent);
                talentIDs.Add(talent.ID);
            }
        }
        
        talentTree.ActiveTalents = talents;
        Persistance.SaveTalents(talentIDs.ToArray());
    }

    public void DisplayTalent(Talent talent)
    {
        talentView.showTalent(talent);
    }
}
