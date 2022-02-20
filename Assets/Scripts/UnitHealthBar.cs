using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ProgressBar))]
public class UnitHealthBar : MonoBehaviour
{

    public GameUnit unit;
    private ProgressBar progressBar;

    private void Awake()
    {
        progressBar = GetComponent<ProgressBar>();
    }

    // Start is called before the first frame update
    void Start()
    {
        unit.OnHealthChange.AddListener(UpdateHealthBar);
        progressBar.SetMaxValue(unit.MaxHealth);
        progressBar.SetValue(unit.Health);
    }

    private void Update()
    {

        progressBar.SetMaxValue(unit.MaxHealth);
        progressBar.SetValue(unit.Health);
    }

    private void UpdateHealthBar(int difference)
    {
    }
}
