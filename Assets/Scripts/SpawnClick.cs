using UnityEngine;

public class SpawnClick : MonoBehaviour
{
    public GameObject phishPrefab;  // Reference to the Fish prefab

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))  // Left mouse button click
        {
            SpawnPhish();
        }
    }

    void SpawnPhish()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;  // Set Z position to 0 for 2D
        Instantiate(phishPrefab, mousePosition, Quaternion.identity);
    }
}