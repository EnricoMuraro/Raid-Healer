using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talent : ScriptableObject
{
    public int ID;
    public new string name;
    [TextArea]
    public string description;
    public Sprite sprite;

}
