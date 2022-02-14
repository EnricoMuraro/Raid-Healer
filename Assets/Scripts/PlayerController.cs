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
    public PlayerInput playerInput;
    

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        
    }

    public void SetTargetPlayer(int index) {
        Debug.Log(index);
        targetIndex = index;
    }


    public void OnActionButton1()
    {   
        abilityBar.Activate(0, playerUnit, targetIndex, raid);
    }

    public void OnActionButton2()
    {
        abilityBar.Activate(1, playerUnit, targetIndex, raid);
    }

    public void OnActionButton3()
    {
        abilityBar.Activate(2, playerUnit, targetIndex, raid);
    }

    // Start is called before the first frame update
    void Start()
    {
        SetTargetPlayer(0);
    }


    // Update is called once per frame
    void Update()
    {
    }
}
