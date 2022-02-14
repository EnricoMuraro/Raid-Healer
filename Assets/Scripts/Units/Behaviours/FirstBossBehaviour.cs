
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBossBehaviour : MonoBehaviour
{

    public Raid raid;
    public AbilitySlot cleaveAbility;

    private void Awake() {
        raid = GetComponent<Raid>();
        cleaveAbility = GetComponent<AbilitySlot>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        GameUnit target = raid.GetFirstRaider();
        raid.Boss.attack(target);
        List<GameUnit> targets = raid.GetFirstRaiders(3);
        cleaveAbility.Activate(raid.Boss, 0, raid);

    }
}
