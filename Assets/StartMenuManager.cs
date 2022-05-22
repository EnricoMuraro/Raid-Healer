using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuManager : MonoBehaviour
{
    public static string[] CompletedFights;
    public int SelectedBoss;

    public void SetSelection(int boss)
    {
        SelectedBoss = boss;
    }

    public void Play()
    {
        
    }


}
