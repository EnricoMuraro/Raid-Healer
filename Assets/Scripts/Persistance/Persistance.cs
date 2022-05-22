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


    public static void SaveTalents(int[] talentIDs)
    {
        Save(new IDStorage(talentIDs), "Talents");
    }

    public static int[] LoadTalents()
    {
        return Load("Talents").IDs;
    }

    public static void SaveSelectedAbilities(int[] abilityIDs)
    {
        Save(new IDStorage(abilityIDs), "SelectedAbilities");
    }

    public static int[] LoadSelectedAbilities()
    {
        return Load("SelectedAbilities").IDs;
    }

    public static void SaveBossProgress(int[] bossFightIDs)
    {
        Save(new IDStorage(bossFightIDs), "BossProgress");
    }

    public static void SaveBossWin(int bossFightID)
    {
        List<int> newProgress = new(LoadBossProgress());
        if (!newProgress.Contains(bossFightID))
        {
            newProgress.Add(bossFightID);
            SaveBossProgress(newProgress.ToArray());
        }
    }

    public static int[] LoadBossProgress()
    {
        return Load("BossProgress").IDs;
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
