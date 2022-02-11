using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Casted Heal")]
public class CastedHeal : Ability
{
    public int baseHeal;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Activate(GameUnit caster, GameUnit target)
    {
        caster.Mana -= manaCost;
        target.Health += baseHeal;
    }
}
