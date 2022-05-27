using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability/Line Attack")]
public class LineAttack : Ability
{
    public bool randomRow;
    [SerializeField]
    public int[] rows;

    public bool randomColumn;
    [SerializeField]
    public int[] columns;

    public Stat damage;

    public int Damage { get => (int)damage.Value; }

    public StatusEffect appliedStatusEffect;


    public override void Activate(GameUnit caster, int targetIndex, Raid raid)
    {
        List<GameUnit> targets = raid.GetRandomRow();
        foreach (GameUnit target in targets)
        {
            target.ReceiveDamage(Damage);
            if (appliedStatusEffect != null)
                target.AddStatusEffect(appliedStatusEffect);
        }
    }
}
