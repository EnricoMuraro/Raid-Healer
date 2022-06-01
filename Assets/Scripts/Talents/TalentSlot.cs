using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalentSlot : MonoBehaviour
{
    public Talent talent;
    public List<TalentSlot> previousTalentSlots;
    public List<TalentSlot> nextTalentSlots;
    public Image border;
    public Image nextTalentArrow;

    private bool isActive;

    private void Awake()
    {
        if (talent != null)
        {
            GetComponent<Image>().sprite = talent.sprite;
        }
    }

    public bool IsActive()
    {
        return isActive;
    }    

    public void Activate()
    {
        isActive = true;
        border.color = Color.green;
        nextTalentArrow.color = Color.cyan;
    }

    public void Deactivate()
    {
        isActive = false;
        Color color = Color.gray;
        border.color = color;
        nextTalentArrow.color = color;
    }


}
