using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public SceneLoaderScript SceneLoader;
    public void EndGame(bool result)
    {
        EndSceneData.result = result;
        EndSceneData.previousSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneLoader.LoadScene(3);
    }
}
