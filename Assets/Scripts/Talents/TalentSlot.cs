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

        Debug.Log("Talent slot activated");
    }

    public void Deactivate()
    {
        isActive = false;
        border.color = Color.gray;
        nextTalentArrow.color = Color.gray;

        Debug.Log("Talent slot deactivated");
    }


}
