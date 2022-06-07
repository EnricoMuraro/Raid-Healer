using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class TalentSlot : MonoBehaviour
{
    public Talent talent;
    public List<TalentSlot> previousTalentSlots;
    public List<TalentSlot> nextTalentSlots;
    public Image border;
    private List<Image> nextTalentArrows = new();

    private bool isActive;

    private void Awake()
    {
        if (talent != null)
        {
            GetComponent<Image>().sprite = talent.sprite;
        }
        nextTalentArrows = GetComponentsInChildren<Image>().Where(x => x.gameObject.transform.parent != transform.parent).ToList();
        nextTalentArrows.Remove(border);
    }

    public bool IsActive()
    {
        return isActive;
    }    

    public void Activate()
    {
        isActive = true;
        border.color = Color.green;
        foreach(Image nextTalentArrow in nextTalentArrows)
            nextTalentArrow.color = Color.cyan;
    }

    public void Deactivate()
    {
        isActive = false;
        Color color = Color.gray;
        border.color = color;
        foreach (Image nextTalentArrow in nextTalentArrows)
            nextTalentArrow.color = color;
    }


}
