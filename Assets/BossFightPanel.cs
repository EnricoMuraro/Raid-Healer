using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BossFightPanel : MonoBehaviour
{
    public int SelectedDifficulty;
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;

    public SceneLoaderScript sceneLoader;



    public void SetFightInfo(BossFightInfo fightInfo, int starsRecord)
    {
        BossFightContainer.BossFightInfo = fightInfo;
        title.text = fightInfo.Name;
        description.text = fightInfo.Description;
        SelectedDifficulty = starsRecord + 1;
    }

    public void StartFight()
    {
        BossFightContainer.BossFightInfo.Difficulty = SelectedDifficulty;
        string sceneName = "";
        switch(BossFightContainer.BossFightInfo.raidSize)
        {
            case BossFightInfo.RaidSize.size3x3:
                sceneName = "MainScene";
                break;
        }
        sceneLoader.LoadScene(sceneName);
    }
}
