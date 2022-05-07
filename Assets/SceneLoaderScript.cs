using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderScript : MonoBehaviour
{
    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
