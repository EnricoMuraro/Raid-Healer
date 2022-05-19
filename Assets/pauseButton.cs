using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseButton : MonoBehaviour
{
    public GameObject overlay;
    public void OnPause()
    {
        overlay.SetActive(true);
    }
}
