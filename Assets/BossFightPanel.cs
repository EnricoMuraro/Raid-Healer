using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BossFightPanel : MonoBehaviour
{
    private int fightID;
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;

    public SceneLoaderScript sceneLoader;



    public void SetFightInfo(BossFightInfo fightInfo)
    {
        BossFightContainer.BossFightInfo = fightInfo;
        fightID = fightInfo.ID;
        title.text = fightInfo.Name;
        description.text = fightInfo.Description;
    }

    public void StartFight()
    {
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
