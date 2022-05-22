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
        fightID = fightInfo.ID;
        title.text = fightInfo.Name;
        description.text = fightInfo.Description;
    }

    public void StartFight()
    {
        string sceneName;
        bool found = BossFightProgress.fightSceneNames.TryGetValue(fightID, out sceneName);
        if (found)
            sceneLoader.LoadScene(sceneName);
        else
            Debug.LogWarning("Boss fight ID '" + fightID + "' is not assigned to any boss fight scene");
    }
}
