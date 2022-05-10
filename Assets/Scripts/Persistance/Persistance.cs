using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Persistance
{
    public static void Save(ScriptableObject scriptableObject, string filename)
    {
        
    }

    public static ScriptableObject Load(string filename)
    {
        return null;
    }

    public static void SaveTalents(TalentStorage talentStorage)
    {
        string talentJson = JsonUtility.ToJson(talentStorage);
        Debug.Log("Saved talents: " + talentJson);
        PlayerPrefs.SetString("Talents", talentJson);
    }

    public static TalentStorage LoadTalents()
    {
        string talentJson = PlayerPrefs.GetString("Talents");
        Debug.Log("Loaded talents: " + talentJson);
        TalentStorage talents = JsonUtility.FromJson<TalentStorage>(talentJson);
        return talents;
    }
}

[System.Serializable]
public class TalentStorage
{
    public int[] activeTalentsIDs;

    public TalentStorage(int[] IDs)
    {
        activeTalentsIDs = IDs;
    }
}