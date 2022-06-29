using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossFightIcon : MonoBehaviour
{
    public BossFightInfo bossFightInfo;
    public BossStarLock RequiredStarsLock;
    public BossFightIcon[] previousBosses;

    public Image BossIcon;
    public Image StarsImage;
    private bool completedFlag = false;
    private int stars;

    public Color LockedColor;
    public Color UncompletedColor;
    public Color CompletedColor;

    public Sprite OneStar;
    public Sprite TwoStars;
    public Sprite ThreeStars;
    public Sprite FourStars;
    public Sprite FiveStars;

    private Button IconButton;
    private BossFightPanel bossFightPanel;

    private void Awake()
    {
        bossFightPanel = FindObjectOfType<BossFightPanel>(includeInactive: true);
        IconButton = GetComponentInChildren<Button>();
        IconButton.onClick.AddListener(() => ShowBossFightPanel(bossFightPanel));
    }

    public void ShowBossFightPanel(BossFightPanel bossFightPanel)
    {
        bossFightPanel.gameObject.SetActive(true);
        bossFightPanel.SetFightInfo(bossFightInfo, stars); 
    }

    public bool IsLocked()
    {
        bool locked = false;
        if (RequiredStarsLock != null && !RequiredStarsLock.Unlocked)
            locked = true;

        foreach(BossFightIcon boss in previousBosses)
            if (boss.GetCompletedFlag() == false)
                locked = true;
        return locked;
    }

    public void SetCompletedFlag(bool completed, int stars = 0)
    {
        completedFlag = completed;
        SetStarsIcon(stars);



    }

    private void SetStarsIcon(int stars)
    {
        this.stars = stars;
        if (stars > 0)
        {
            StarsImage.gameObject.SetActive(true);
            switch (stars)
            {
                case 1:
                    StarsImage.sprite = OneStar;
                    break;
                case 2:
                    StarsImage.sprite = TwoStars;
                    break;
                case 3:
                    StarsImage.sprite = ThreeStars;
                    break;
                case 4:
                    StarsImage.sprite = FourStars;
                    break;
                default:
                    StarsImage.sprite = FiveStars;
                    break;
            }
        }
        else
        {
            StarsImage.gameObject.SetActive(false);
        }

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
            if (completedFlag)
                BossIcon.color = CompletedColor;
            else
                BossIcon.color = UncompletedColor;

            IconButton.enabled = true;
        }
    }
}
