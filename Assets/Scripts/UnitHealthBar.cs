using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ProgressBar))]
public class UnitHealthBar : MonoBehaviour
{

    public GameUnit unit;
    public bool showStatusEffects = false;
    private ProgressBar progressBar;

    private void Awake()
    {
        progressBar = GetComponent<ProgressBar>();
    }

    // Start is called before the first frame update
    void Start()
    {
        unit.OnHealthChange.AddListener(UpdateHealthBar);
        unit.OnStatusEffectAdded.AddListener(AddStatusEffectIcon);
        progressBar.SetMaxValue(unit.MaxHealth);
        progressBar.SetValue(unit.Health);

    }

    private void Update()
    {

        progressBar.SetMaxValue(unit.MaxHealth);
        progressBar.SetValue(unit.Health);

        progressBar.SetMaxValue(unit.MaxHealth, 1);
        progressBar.SetValue(Mathf.Clamp(unit.Shield, 0, unit.MaxHealth), 1);

        if (unit.IsDead())
        {
            progressBar.displayValues = false;
            progressBar.SetText("DEAD");
        }

    }

    

    private void UpdateHealthBar(int difference)
    {
    }

    private void AddStatusEffectIcon(StatusEffectSlot statusEffectSlot)
    {
        if(showStatusEffects)
            progressBar.AddStatusEffectFrameIcon(statusEffectSlot);
    }
}
