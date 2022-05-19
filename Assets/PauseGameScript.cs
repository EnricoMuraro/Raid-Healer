using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGameScript : MonoBehaviour
{

    private void OnEnable()
    {
        Time.timeScale = 0f;
    }


    private void OnDisable()
    {
        Time.timeScale = 1f;
    }
}
