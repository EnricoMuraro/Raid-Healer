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

    private void Start()
    {
        Debug.Log("end scene data " + EndSceneData.result + " " + EndSceneData.previousSceneIndex);

        if(EndSceneData.result)
            resultSplashImage.sprite = winSprite;
        else
            resultSplashImage.sprite = lossSprite;
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
