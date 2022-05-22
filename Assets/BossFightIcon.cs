using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossFightIcon : MonoBehaviour
{
    public BossFightInfo bossFightInfo;
    public BossFightIcon[] previousBosses;

    public Image BossIcon;
    private bool completedFlag = false;

    public Color LockedColor;
    public Color UncompletedColor;
    public Color CompletedColor;

    private Button IconButton;

    private void Awake()
    {
        IconButton = GetComponent<Button>();
    }

    public void ShowBossFightPanel(BossFightPanel bossFightPanel)
    {
        bossFightPanel.gameObject.SetActive(true);
        bossFightPanel.SetFightInfo(bossFightInfo); 
        
    }

    public bool IsLocked()
    {
        bool locked = false;
        foreach(BossFightIcon boss in previousBosses)
            if (boss.GetCompletedFlag() == false)
                locked = true;
        return locked;
    }

    public void SetCompletedFlag(bool completed)
    {
        completedFlag = completed;
        if(completedFlag)
            BossIcon.color = CompletedColor;
        else
            BossIcon.color = UncompletedColor;
    }

    public bool GetCompletedFlag()
    {
        return completedFlag;
    }

    private void Update()
    {
        if (IsLocked())
        {
            BossIcon.color = LockedColor;
            IconButton.enabled = false;
        }
        else
        {
            IconButton.enabled = true;
        }
    }
}
