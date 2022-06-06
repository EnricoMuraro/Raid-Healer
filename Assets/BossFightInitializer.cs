using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightInitializer : MonoBehaviour
{

    public static BossFightInfo BossFightInfo;
    public PlayerController playerController;
    public GameUnit Boss;
    public AbilityBar abilityBar;
    public ProgressBar BossCastBar;

    private List<UnitModifier> auraModifiers = new();

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

        ActivateAuras(BossFightInfo.Auras);
    }

    private void OnDisable()
    {
        DeactivateAuras();
    }

    private void ActivateAuras(List<Aura> auras)
    {
        Raid raid = playerController.raid;
        GameUnit player = playerController.playerUnit;

        foreach (Aura aura in auras)
            switch (aura.AffectedRole)
            {
                case Unit.Role.Boss:
                    auraModifiers.Add(new UnitModifier(raid.Boss.GetUnit(), aura.UnitStat, aura.UnitModifier));
                    break;
                case Unit.Role.Player:
                    auraModifiers.Add(new UnitModifier(player.GetUnit(), aura.UnitStat, aura.UnitModifier));
                    break;
                default:
                    foreach (GameUnit raider in raid.raiders)
                        if (raider.Role == aura.AffectedRole)
                            auraModifiers.Add(new UnitModifier(raider.GetUnit(), aura.UnitStat, aura.UnitModifier));
                    break;
            }

        foreach (UnitModifier unitModifier in auraModifiers)
            unitModifier.ApplyModifier();
    }

    private void DeactivateAuras()
    {
        foreach (UnitModifier unitModifier in auraModifiers)
            unitModifier.RemoveModifier();
    }

}

public static class BossFightContainer
{
    public static BossFightInfo BossFightInfo;
}