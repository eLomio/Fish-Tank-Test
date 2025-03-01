using UnityEngine;

public class SpawnClick : MonoBehaviour
{
    public GameObject phishPrefab;  // Reference to the Fish prefab
    public GameObject FoodPrefab; // Food pellet prefab

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))  // Left mouse button click
        {
            SpawnPhish();
        }
        if (Input.GetMouseButtonDown(1))  // Left mouse button click
        {
            SpawnFood();
        }
    }

    void SpawnFood()
    {
        // Spawn Food at the mouse position
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // Ensure Food is in 2D space
        GameObject Food = Instantiate(FoodPrefab, mousePosition, Quaternion.identity);
    }

    void SpawnPhish()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;  // Set Z position to 0 for 2D
        GameObject newFish = Instantiate(phishPrefab, mousePosition, Quaternion.identity);

        SpriteRenderer fishRenderer = newFish.GetComponent<SpriteRenderer>();
        if (fishRenderer != null)
        {
            fishRenderer.enabled = true;  // Make the fish visible by enabling the renderer
        }
    }
}