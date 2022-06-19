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

            switch(stat)
            {
                case GameUnitStat.health: statValue = gameUnit.Health; statValueMax = gameUnit.MaxHealth; break;
                case GameUnitStat.mana: statValue = gameUnit.Mana; statValueMax = gameUnit.MaxMana; break;
            }
            
            switch(valueType)
            {
                case ValueType.percentage: statValue /= 100; break;
                case ValueType.flat: statValueMax = 1; break;
            }

            if(valueType == ValueType.flat)

            switch(comparisonOperator)
            {
                case Operator.less: return statValue/statValueMax < value;
                case Operator.greater: return statValue/statValueMax > value;
                case Operator.lessOrEqual: return statValue/statValueMax <= value;
                case Operator.greaterOrEqual: return statValue/statValueMax >= value;
                case Operator.equal: return statValue/statValueMax == value;
            }

            return false;
        }
    } 
        
}

