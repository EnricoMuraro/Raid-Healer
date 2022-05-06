using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalentSlot : MonoBehaviour
{
    public Talent talent;
    public TalentSlot previousTalentSlot;
    public TalentSlot nextTalentSlot;
    public Image border;
    public Image nextTalentArrow;

    private bool isActive;

    private void Start()
    {

        border.color = Color.gray;
        nextTalentArrow.color = Color.gray;
        isActive = false;
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
        if(previousTalentSlot == null || previousTalentSlot.IsActive())
        {
            isActive = true;
            border.color = Color.green;
            nextTalentArrow.color = Color.green;
        }
    }

    public void Deactivate()
    {
        if(nextTalentSlot == null || !nextTalentSlot.IsActive())
        {
            isActive = false;
            border.color = Color.gray;
            nextTalentArrow.color = Color.gray;
        }
    }

    public void toggleActivation()
    {
        if (isActive)
            Deactivate();
        else
            Activate();
    }
}
