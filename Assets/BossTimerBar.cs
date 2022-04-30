using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTimerBar : MonoBehaviour
{
    public AbilityBar abilityBar;

    private AbilitySlot[] abilitySlots;

    private void Awake()
    {
        abilitySlots = abilityBar.GetAbilitySlots();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
