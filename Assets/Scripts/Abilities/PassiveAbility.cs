using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Passive Ability")]
public class PassiveAbility : Ability
{
    
    public List<PassiveEffect> effects = new List<PassiveEffect>();
    
    public override void Activate(GameUnit caster, int targetIndex, Raid raid)
    {
        base.Activate(caster, targetIndex, raid);
        foreach(PassiveEffect effect in effects)
        {
            effect.activatedModifier.gameUnit = caster;
            if(effect.activationCondition.Compare(caster))
            {
                effect.activatedModifier.ApplyModifier();
            }
            else
            {
                effect.activatedModifier.RemoveModifier();
            }
        }

            
    }

    private void OnDisable()
    {
        Debug.Log("Passive disabled");
        foreach(PassiveEffect effect in effects)
            effect.activatedModifier.RemoveModifier();
    }

    [System.Serializable]
    public class PassiveEffect
    {
        public Condition activationCondition;
        public GameunitModifier activatedModifier;
    }

    [System.Serializable]
    public class Condition
    {
        public GameUnitStat stat;
        public Operator comparisonOperator;
        public float value;
        public ValueType valueType;

        public enum GameUnitStat
        {
            health,
            mana,
        }

        public enum Operator
        {
            less,
            greater,
            lessOrEqual,
            greaterOrEqual,
            equal,
        }

        public enum ValueType
        {
            percentage,
            flat,
        }

        public bool Compare(GameUnit gameUnit)
        {
            float statValue = 0;
            float statValueMax = 1;
            float compareValue = 0;
            float percent = 1;

            switch(stat)
            {
                case GameUnitStat.health: statValue = gameUnit.Health; statValueMax = gameUnit.MaxHealth; break;
                case GameUnitStat.mana: statValue = gameUnit.Mana; statValueMax = gameUnit.MaxMana; break;
            }
            
            switch(valueType)
            {
                case ValueType.percentage: compareValue = statValue/statValueMax; percent = 100; break;
                case ValueType.flat: compareValue = statValue; break;
            }

            switch(comparisonOperator)
            {
                case Operator.less: return compareValue < value / percent;
                case Operator.greater: return compareValue > value / percent;
                case Operator.lessOrEqual: return compareValue <= value / percent;
                case Operator.greaterOrEqual: return compareValue >= value / percent;
                case Operator.equal: return compareValue == value / percent;
            }

            return false;
        }
    } 
        
}

