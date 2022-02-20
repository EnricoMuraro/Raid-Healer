using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ProgressBar))]
public class UnitManaBar : MonoBehaviour
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
        unit.OnManaChange.AddListener(UpdateManaBar);
        progressBar.SetMaxValue(unit.MaxMana);
        progressBar.SetValue(unit.Mana);
    }

    private void Update()
    {

        progressBar.SetMaxValue(unit.MaxMana);
        progressBar.SetValue(unit.Mana);
    }

    private void UpdateManaBar(int difference)
    {
    }
}
