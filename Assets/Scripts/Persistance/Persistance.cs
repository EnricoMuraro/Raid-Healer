using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Persistance
{
    private static void Save(object storage, string path)
    {
        string dataJson = JsonUtility.ToJson(storage);
        Debug.Log("Saved data: " + dataJson);
        PlayerPrefs.SetString(path, dataJson);
    }

    private static T Load<T>(string path) where T : new()
    {
        string dataJson = PlayerPrefs.GetString(path);
        Debug.Log("Loaded data: " + dataJson);
        T storage = JsonUtility.FromJson<T>(dataJson);

        if (storage != null)
            return storage;
        else
            return new T();
    }


    public static void SaveTalents(int[] talentIDs)
    {
        Save(new IDStorage(talentIDs), "Talents");
    }

    public static int[] LoadTalents()
    {
        return Load<IDStorage>("Talents").IDs;
    }

    public static void SaveSelectedAbilities(int[] abilityIDs)
    {
        Save(new IDStorage(abilityIDs), "SelectedAbilities");
    }

    public static int[] LoadSelectedAbilities()
    {
        return Load<IDStorage>("SelectedAbilities").IDs;
    }

    public static void SaveBossProgress(int[] bossFightIDs)
    {
        Save(new IDStorage(bossFightIDs), "BossProgress");
    }

    public static  bool SaveBossWin(int bossFightID)
    {
        List<int> newProgress = new(LoadBossProgress());
        if (!newProgress.Contains(bossFightID))
        {
            newProgress.Add(bossFightID);
            SaveBossProgress(newProgress.ToArray());
            return true;
        }
        return false;
    }

    public static int[] LoadBossProgress()
    {
        return Load<IDStorage>("BossProgress").IDs;
    }
}

[System.Serializable]
public class IDStorage
{
    public int[] IDs;

    public IDStorage()
    {
        IDs = new int[0];
    }


    public IDStorage(int[] IDs)
    {
        this.IDs = IDs;
    }
}

public class TalentStorage
{
    public int[] IDs;
    public int[] pointsPerPanel;

    public TalentStorage()
    {
        IDs = new int[0];
        pointsPerPanel = new int[0];
    }

    public TalentStorage(int[] IDs, int[] pointsPerPanel)
    {
        this.IDs = IDs;
        this.pointsPerPanel = pointsPerPanel;
    }
}
