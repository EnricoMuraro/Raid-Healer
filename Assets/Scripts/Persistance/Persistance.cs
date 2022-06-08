using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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

    public static void SaveBossProgress(BossFightEntry[] bossFights)
    {
        Save(new BossFightStorage(bossFights), "BossProgress");
    }

    public static BossFightEntry[] LoadBossProgress()
    {
        return Load<BossFightStorage>("BossProgress").bossFightEntries;
    }

    //returns true if it's the first save for that bossFightID, false otherwise
    public static bool SaveBossWin(int bossFightID, int starsEarned, bool keepHighestStars = true)
    {
        bool newEntry = false;
        BossFightEntry[] currentProgress = LoadBossProgress();
        BossFightEntry bossEntry = currentProgress.FirstOrDefault(x => x.ID == bossFightID);
        if(bossEntry == null)
        {
            newEntry = true;
            bossEntry = new BossFightEntry(bossFightID, starsEarned);
        }
        else
        {
            if (keepHighestStars)
                bossEntry.stars = Mathf.Max(bossEntry.stars, starsEarned);
            else
                bossEntry.stars = starsEarned;
        }

        currentProgress = currentProgress.Append(bossEntry).ToArray();
        SaveBossProgress(currentProgress);
        return newEntry;
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

[System.Serializable]
public class BossFightStorage
{
    public BossFightEntry[] bossFightEntries;

    public BossFightStorage()
    {
        bossFightEntries = new BossFightEntry[0];
    }

    public BossFightStorage(BossFightEntry[] bossFightEntries)
    {
        this.bossFightEntries = bossFightEntries;
    }
}

[System.Serializable]
public class BossFightEntry
{
    public int ID;
    public int stars;


    public BossFightEntry(int ID, int stars)
    {
        this.ID = ID;
        this.stars = stars;
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
