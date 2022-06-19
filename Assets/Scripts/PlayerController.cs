using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public GameUnit playerUnit;
    public int targetIndex;
    public Raid raid;
    public AbilityBar abilityBar;
    public TalentTree talentTree;

    private void Start()
    {
        SetTargetPlayer(0);
    }

    public void SetTargetPlayer(int index) {
        targetIndex = index;
    }

    public void OnActionButton1()
    {   
        string err = abilityBar.Activate(0, playerUnit, targetIndex, raid);
        if (err != "")
        {
            Debug.Log(err);
        }
    }

    public void OnActionButton2()
    {
        string err = abilityBar.Activate(1, playerUnit, targetIndex, raid);
        if (err != "")
        {
            Debug.Log(err);
        }
    }

    public void OnActionButton3()
    {
        string err = abilityBar.Activate(2, playerUnit, targetIndex, raid);
        if (err != "")
        {
            Debug.Log(err);
        }
    }

    public void OnActionButton4()
    {
        string err = abilityBar.Activate(3, playerUnit, targetIndex, raid);
        if (err != "")
        {
            Debug.Log(err);
        }
    }

    public void OnActionButton5()
    {
        string err = abilityBar.Activate(4, playerUnit, targetIndex, raid);
        if (err != "")
        {
            Debug.Log(err);
        }
    }

}
