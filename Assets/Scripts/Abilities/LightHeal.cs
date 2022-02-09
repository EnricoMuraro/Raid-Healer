using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Light Heal")]
public class LightHeal : Ability
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

    public override void Activate(Unit target)
    {
        target.Health += baseHeal;
    }
}
