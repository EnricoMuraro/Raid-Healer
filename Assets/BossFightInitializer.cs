using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightInitializer : MonoBehaviour
{

    public static BossFightInfo BossFightInfo;
    public GameUnit Boss;
    public AbilityBar abilityBar;
    public ProgressBar BossCastBar;

    private void Awake()
    {
        BossFightInfo = BossFightContainer.BossFightInfo;
        Boss.InitUnit(BossFightInfo.BossUnit);
        Boss.GetComponent<BossBehaviourScript>().bossBehaviour = BossFightInfo.BossBehaviour;

        foreach (Ability ability in BossFightInfo.Abilities)
        {
            GameObject abilitySlotParent = new GameObject("Ability Slot");
            abilitySlotParent.transform.parent = abilityBar.transform;
            AbilitySlot abilitySlot = abilitySlotParent.AddComponent<AbilitySlot>();
            abilitySlot.ability = ability;
            abilitySlot.castBar = BossCastBar;


        }
    }
}

public static class BossFightContainer
{
    public static BossFightInfo BossFightInfo;
}