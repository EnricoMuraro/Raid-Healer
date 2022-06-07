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
    private List<Ability> allBossAbilities = new List<Ability>();
    private List<StatusEffect> allBossStatusEffects = new List<StatusEffect>();
    private List<AbilityModifier> abilityModifiers = new();
    private List<StatusEffectModifier> statusEffectModifiers = new();
    private List<UnitModifier> unitModifiers = new();

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
        ExploreAllBossAbilities(BossFightInfo.Abilities);
        //must be called after ExploreAllBossAbilities
        AddDifficultyModifiers(BossFightInfo.Difficulty, Boss);
        ActivateDifficultyModifiers();
    }

    private void OnDisable()
    {
        DeactivateAuras();
        DeactivateDifficultyModifiers();
    }

    private void ExploreAllBossAbilities(List<Ability> startAbilities)
    {
        foreach (Ability ability in startAbilities)
            RecursiveExplore(ability);
    }
    private void RecursiveExplore(Ability ability)
    {
        if (ability == null || allBossAbilities.Contains(ability))
            return;
        else
        {
            allBossAbilities.Add(ability);
            if (ability is ApplyStatusEffect statusEffectAbility)
                allBossStatusEffects.Add(statusEffectAbility.effect);
            RecursiveExplore(ability.nextAbility);
        }
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

    private void AddDifficultyModifiers(int difficulty, GameUnit boss)
    {
        //percentage boss damage/health increase for every level
        int difficultyStep = 10;
        int startingDifficulty = -50;
        int difficultyIncrease = startingDifficulty + difficultyStep * difficulty;

        Modifier difficultyModifier = new(Modifier.Type.Percentage, Modifier.Source.Aura, difficultyIncrease);

        foreach(Ability ability in allBossAbilities)
            abilityModifiers.Add(new AbilityModifier(ability, Ability.Stats.damage, difficultyModifier));

        foreach (StatusEffect statusEffect in allBossStatusEffects)
            statusEffectModifiers.Add(new StatusEffectModifier(statusEffect, StatusEffect.Stats.damage, difficultyModifier));

        unitModifiers.Add(new UnitModifier(boss.GetUnit(), Unit.Stats.maxHealth, difficultyModifier));
        unitModifiers.Add(new UnitModifier(boss.GetUnit(), Unit.Stats.damage, difficultyModifier));
    }

    private void ActivateDifficultyModifiers()
    {
        foreach (AbilityModifier abilityModifier in abilityModifiers)
            abilityModifier.ApplyModifier();

        foreach (StatusEffectModifier statusEffect in statusEffectModifiers)
            statusEffect.ApplyModifier();

        foreach (UnitModifier unitModifier in unitModifiers)
            unitModifier.ApplyModifier();
    }

    private void DeactivateDifficultyModifiers()
    {
        foreach (AbilityModifier abilityModifier in abilityModifiers)
            abilityModifier.RemoveModifier();

        foreach (StatusEffectModifier statusEffect in statusEffectModifiers)
            statusEffect.RemoveModifier();

        foreach (UnitModifier unitModifier in unitModifiers)
            unitModifier.RemoveModifier();
    }
}

public static class BossFightContainer
{
    public static BossFightInfo BossFightInfo;
}