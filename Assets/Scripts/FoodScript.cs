using UnityEngine;

public class FoodScript : MonoBehaviour
{
    public float lifetime = 30f; // Time in seconds before the pellet is destroyed
    public float sinkSpeed = 0.2f;
    public float targetHeight = -10f; // The height near the bottom of the screen (adjust as needed)


    void Start()
    {
        // Destroy this pellet after the specified lifetime
        Destroy(gameObject, lifetime);
    }
    private void Update()
    {
        // Move the pellet downward slowly until it reaches the target height
        if (transform.position.y > targetHeight)
        {
            transform.position = new Vector3(
                transform.position.x,
                Mathf.MoveTowards(
                    transform.position.y, 
                    targetHeight, 
                    sinkSpeed * Time.deltaTime),
                    transform.position.z);
        }
    }
}
