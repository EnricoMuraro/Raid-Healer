using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DifficultyDisplay : MonoBehaviour
{
    public BossFightPanel bossFightPanel;
    public TextMeshProUGUI DifficultyText;
    public int MaxDifficulty;
    public int MinDifficulty;

    private void Start()
    {
        bossFightPanel.SelectedDifficulty = Mathf.Clamp(bossFightPanel.SelectedDifficulty, MinDifficulty, MaxDifficulty);
        DifficultyText.text = bossFightPanel.SelectedDifficulty.ToString();
    }

    public void IncreaseDifficulty(int amount)
    {
        int newDiff = bossFightPanel.SelectedDifficulty + amount;
        bossFightPanel.SelectedDifficulty = Mathf.Clamp(newDiff, MinDifficulty, MaxDifficulty);
        DifficultyText.text = bossFightPanel.SelectedDifficulty.ToString();
    }

    public void DecreaseDifficulty(int amount)
    {
        int newDiff = bossFightPanel.SelectedDifficulty - amount;
        bossFightPanel.SelectedDifficulty = Mathf.Clamp(newDiff, MinDifficulty, MaxDifficulty);
        DifficultyText.text = bossFightPanel.SelectedDifficulty.ToString();
    }
}
