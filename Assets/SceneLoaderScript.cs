using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoaderScript : MonoBehaviour
{
    public CanvasGroup transitionImage;
    public float transitionDuration;
    public bool inverted = false;

    private void Start()
    {
        transitionImage.alpha = 1;
        Application.targetFrameRate = 60;
        int position = inverted ? -Screen.height : Screen.height;
        LeanTween.moveLocalY(transitionImage.gameObject, position, transitionDuration).setEaseOutCubic();
    }


    public void LoadScene(int scene)
    {
        LeanTween.moveLocalY(transitionImage.gameObject, 0, transitionDuration).setEaseOutCubic()
            .setOnComplete(() => SceneManager.LoadScene(scene));
    }

    public void LoadScene(string scene)
    {
        LeanTween.moveLocalY(transitionImage.gameObject, 0, transitionDuration).setEaseOutCubic()
            .setOnComplete(() => SceneManager.LoadScene(scene));
    }

    public void ReloadScene()
    {
        LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /*
    IEnumerator LoadSceneAnimation(int index)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(index);
    }
    */
}
