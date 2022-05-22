using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int bossFightID;
    public SceneLoaderScript SceneLoader;
    public void EndGame(bool result)
    {
        //Set end screen data
        EndSceneData.result = result;
        EndSceneData.previousSceneIndex = SceneManager.GetActiveScene().buildIndex;
        EndSceneData.bossFightID = bossFightID;
        SceneLoader.LoadScene(3);
    }
}
