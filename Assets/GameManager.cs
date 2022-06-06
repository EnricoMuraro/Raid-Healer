using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private BossFightInfo bossFightInfo;
    public PlayerController playerController;
    public SceneLoaderScript SceneLoader;

    private void Start()
    {
        bossFightInfo = BossFightInitializer.BossFightInfo;    
    }


    public void EndGame(bool result)
    {
        //Set end screen data
        EndSceneData.result = result;
        EndSceneData.previousSceneIndex = SceneManager.GetActiveScene().buildIndex;
        EndSceneData.bossFightInfo = bossFightInfo;
        SceneLoader.LoadScene(3);
    }
}
