using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BossStarLock : MonoBehaviour
{
    public int RequiredStars;
    
    Button button;
    TextMeshProUGUI starText;
    bool starLockUnlocked;
    public bool Unlocked => starLockUnlocked;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(LockClick);

        starText = GetComponentInChildren<TextMeshProUGUI>();

        starLockUnlocked = PlayerPrefs.HasKey("StarLock1");
        if (starLockUnlocked)
            gameObject.SetActive(false);
    }

    private void Start()
    {
        starText.text = BossFightProgress.TotalStars + "/" + RequiredStars;
    }

    private void LockClick()
    {
        if(BossFightProgress.TotalStars >= RequiredStars)
        {
            LeanTween.scale(gameObject, Vector3.zero, 1f).setEaseOutExpo()
                .setOnComplete(() => { gameObject.SetActive(false); });
            
            PlayerPrefs.SetInt("StarLock1", 1);
            starLockUnlocked = true;
        }
        else
            LeanTween.moveLocalX(gameObject, -7, 0.3f).setEaseShake();
    }
}
