using GamesMrkt.Core;
using System.Collections.Generic;
using UnityEngine;

public class DirtyManager : Singleton<DirtyManager>
{
    private List<Dirty> dirtyList = new List<Dirty>();
    public void Add(Dirty arg)
    {
        if (dirtyList.Contains(arg))
            return;

        dirtyList.Add(arg);
    }
    public void Remove(Dirty arg)
    {
        if (!dirtyList.Contains(arg))
            return;

        dirtyList.Remove(arg);

        if (dirtyList.Count == 0){
            LevelManager.OnLevelComplete?.Invoke(LevelManager.Level);
            Debug.Log("Level Complete");
        }
    }
}
