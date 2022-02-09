using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public HealthBar castBar;
    public int targetRaiderIndex;
    public Raid raid;

    public AbilitySlot[] abilitySlots;

    public void SetTargetPlayerIndex(int index) {
        Debug.Log(index);
        targetRaiderIndex = index;
        foreach(AbilitySlot ability in abilitySlots) 
        {
            ability.target = raid.raiders[index];
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        targetRaiderIndex=0;
        abilitySlots = GetComponents<AbilitySlot>();
    }

    void Cast()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
