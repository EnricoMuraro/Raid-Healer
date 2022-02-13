using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Casted Heal")]
public class CastedHeal : Ability
{
    public int baseHeal;
    public Sprite sprite;

    public override void Activate(GameUnit caster, int targetIndex, GameUnit[] raiders)
    {
        caster.Mana -= manaCost;
        raiders[i].ReceiveHeal(baseHeal);
    }
}
