using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public BossFightInfo bossFightInfo;
    public SceneLoaderScript SceneLoader;
    public void EndGame(bool result)
    {
        //Set end screen data
        EndSceneData.result = result;
        EndSceneData.previousSceneIndex = SceneManager.GetActiveScene().buildIndex;
        EndSceneData.bossFightInfo = bossFightInfo;
        SceneLoader.LoadScene(3);
    }
}
