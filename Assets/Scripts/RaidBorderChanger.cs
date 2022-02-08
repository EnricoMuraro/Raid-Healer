using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaidBorderChanger : MonoBehaviour
{

    public Sprite defaultBorder;
    public Sprite selectedBorder;

    private Image[] raidBorders;

    public void selectBorder(int borderIndex)
    {
        for (int i = 0; i<raidBorders.Length; i++) {
            if(i == borderIndex)
                raidBorders[i].sprite = selectedBorder;
            else
                raidBorders[i].sprite = defaultBorder;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        List<Image> tmp = new List<Image>();
        foreach(Transform child in transform)
            foreach(Transform c in child)
                if(c.name == "RaiderHealthBarBorder") 
                    tmp.Add(c.GetComponent<Image>());

        raidBorders = tmp.ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
