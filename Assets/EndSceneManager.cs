using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndSceneManager : MonoBehaviour
{
    public Image resultSplashImage;
    public Sprite winSprite;
    public Sprite lossSprite;
    public SceneLoaderScript sceneLoader;

    private EndScreenStars endScreenStars;

    private void Awake()
    {
        endScreenStars = FindObjectOfType<EndScreenStars>();
    }

    private void Start()
    {
        Debug.Log("end scene data " + EndSceneData.result + " " + EndSceneData.previousSceneIndex);

        RewardPanelScript.DisplayNoRewards();
        

        if (EndSceneData.result)
        {


            //1 star of each level of difficulty up to 4
            int earnedStars = Mathf.Clamp(EndSceneData.bossFightInfo.Difficulty, 1, 4);
            
            //1 bonus star if all raiders all still alive
            if(EndSceneData.allAlive)
                earnedStars++;

            endScreenStars.SetEarnedStars(earnedStars);

            //Show rewards only if it's the first win
            if (Persistance.SaveBossWin(EndSceneData.bossFightInfo.ID, earnedStars))
                RewardPanelScript.DispalyRewards(EndSceneData.bossFightInfo.Reward);

            resultSplashImage.sprite = winSprite;
        }
        else
        {
            endScreenStars.SetEarnedStars(0);
            resultSplashImage.sprite = lossSprite;
        }
    }

    public void Retry()
    {
        Debug.Log("Retry");
        sceneLoader.LoadScene(EndSceneData.previousSceneIndex);
    }

    public void Quit()
    {
        Debug.Log("Quit");
        sceneLoader.LoadScene(0);
    }
}
