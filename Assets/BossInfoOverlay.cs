using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BossInfoOverlay : MonoBehaviour
{
    public Transform Container;
    public TextMeshProUGUI bossNameText;
    private BossFightInfo bossFightInfo;
    private AbilityView AbilityViewPrefab;

    private void Start()
    {
        bossFightInfo = BossFightContainer.BossFightInfo;
        AbilityViewPrefab = Resources.Load<AbilityView>("AbilityView");

        bossNameText.text = bossFightInfo.Name;

        foreach (Ability ability in bossFightInfo.Abilities)
        {
            AbilityView abilityView = Instantiate(AbilityViewPrefab, Container);
            abilityView.ShowAbility(ability);
            abilityView.GetComponent<Button>().enabled = false;
        }
    }

    private void OnEnable()
    {
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }
}   
