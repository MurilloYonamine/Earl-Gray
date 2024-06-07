using Gamegaard.Singleton;
using System.Collections.Generic;

public class LevelManager : MonoBehaviourSingleton<LevelManager>
{
    private readonly List<CombinationObject> currentSelectedObjects = new List<CombinationObject>();

    public void AddCombination(CombinationObject combination)
    {
        if (currentSelectedObjects.Contains(combination)) return; // NAO ADD O MESMO OBJETO DUAS VEZES
        currentSelectedObjects.Add(combination);
    }

    public void RemoveCombination(CombinationObject combination)
    {
        currentSelectedObjects.Remove(combination);
    }
}