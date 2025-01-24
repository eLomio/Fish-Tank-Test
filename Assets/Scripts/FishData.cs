using UnityEngine;

[System.Serializable]
public class FishData
{
    public Color fishColor;
    public float speed;
    public float strength;
    public Vector2 position;
    public float favNum;

    public FishData(float avspeed, float avstrength, Vector2 position)
    {
        this.speed = Random.Range(avspeed * 0.5f, avspeed * 2f);
        this.strength = Random.Range(avstrength * 0.5f, avstrength * 2f);
        this.position = position;

        this.fishColor = new Color(Random.Range(0.7f,1f), Random.Range(0.7f,1f), Random.Range(0.7f,1f), 1f);
        this.favNum = Random.Range(0,1);
    }
}