using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Persistance
{
    private static void Save(IDStorage idstorage, string path)
    {
        string dataJson = JsonUtility.ToJson(idstorage);
        Debug.Log("Saved data: " + dataJson);
        PlayerPrefs.SetString(path, dataJson);
    }

    private static IDStorage Load(string path)
    {
        string dataJson = PlayerPrefs.GetString(path);
        Debug.Log("Loaded data: " + dataJson);
        IDStorage idstorage = JsonUtility.FromJson<IDStorage>(dataJson);

        if (idstorage != null)
            return idstorage;
        else
            return new IDStorage(new int[0]);
    }


    public static void SaveTalents(IDStorage talentStorage)
    {
        Save(talentStorage, "Talents");
    }

    public static IDStorage LoadTalents()
    {
        return Load("Talents");
    }

    public static void SaveSelectedAbilities(IDStorage abilitiesStorage)
    {
        Save(abilitiesStorage, "SelectedAbilities");
    }

    public static IDStorage LoadSelectedAbilities()
    {
        return Load("SelectedAbilities");
    }
}

[System.Serializable]
public class IDStorage
{
    public int[] IDs;

    public IDStorage(int[] IDs)
    {
        this.IDs = IDs;
    }
}
