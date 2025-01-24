using UnityEngine;
using System.Collections.Generic;

public class FishManager : MonoBehaviour
{
    public static FishManager Instance;
    public List<FishData> fishList = new List<FishData>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Persist across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddFish(float speed, float strength, Vector2 position)
    {
        FishData newFish = new FishData(speed, strength, position);
        fishList.Add(newFish);
    }

    public void RemoveFish(FishData fish)
    {
        fishList.Remove(fish);
    }

    public List<FishData> GetAllFish()
    {
        return fishList;
    }
}