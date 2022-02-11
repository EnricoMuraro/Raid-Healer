using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public GameUnit playerUnit;
    public GameUnit targetUnit;
    public Raid raid;
    public AbilityBar abilityBar;
    public PlayerInput playerInput;
    

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        
    }

    public void SetTargetPlayer(int index) {
        Debug.Log(index);
        targetUnit = raid.raiders[index];
    }


    public void OnActionButton1()
    {
        abilityBar.Activate(0, playerUnit, targetUnit);
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
