using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalentDataContainer : ScriptableObject
{
    public int maximumTalentPoints;
    public int availableTalentPoints;
    private Talent[] activeTalents;

    public Talent[] ActiveTalents { get => activeTalents; set => activeTalents = value; }
}
