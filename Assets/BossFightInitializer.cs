using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightInitializer : MonoBehaviour
{

    public static BossFightInfo BossFightInfo;
    public GameUnit Boss;
    public AbilityBar abilityBar;

    private void Awake()
    {
        BossFightInfo = BossFightContainer.BossFightInfo;
        Boss.InitUnit(BossFightInfo.BossUnit);
        Boss.GetComponent<BossBehaviourScript>().bossBehaviour = BossFightInfo.BossBehaviour;

        foreach (Ability ability in BossFightInfo.Abilities)
        {
            GameObject abilitySlot = new GameObject("Ability Slot");
            abilitySlot.transform.parent = abilityBar.transform;
            abilitySlot.AddComponent<AbilitySlot>().ability = ability;
        }
    }
}

public static class BossFightContainer
{
    public static BossFightInfo BossFightInfo;
}