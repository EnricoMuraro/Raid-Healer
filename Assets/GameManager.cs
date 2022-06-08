using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class GameManager : MonoBehaviour
{
    private BossFightInfo bossFightInfo;
    public PlayerController playerController;
    public Raid raid;
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
        EndSceneData.allAlive = raid.raiders.All(x => !x.IsDead());
        SceneLoader.LoadScene(3);
    }
}
