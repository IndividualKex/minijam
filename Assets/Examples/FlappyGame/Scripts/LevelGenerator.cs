using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {
    public GameObject boundaryPrefab;
    public GameObject obstaclePrefab;
    public LevelGeneratorTrigger trigger;

    Queue<GameObject> queue = new Queue<GameObject>();
    int currentSectionIndex;

    void Start() {
        // Generate several sections at the start
        for(int i = 0; i < 10; i++)
            GenerateNextSection();

        // Listen for entering trigger to generate next section
        trigger.TriggerEntered += GenerateNextSection;
    }

    void GenerateNextSection() {
        // Create section root, so it can be deleted later
        GameObject section = new GameObject("Section" + currentSectionIndex);

        // Create top and bottom boundaries at the current position
        Instantiate(boundaryPrefab, Vector3.right * currentSectionIndex * 5f, Quaternion.identity, section.transform);

        // Create obstacle at a random vertical position, if not at the start
        if(currentSectionIndex > 4)
            Instantiate(obstaclePrefab, new Vector3(currentSectionIndex * 5f, Random.Range(-3f, 3f), 0), Quaternion.identity, section.transform);

        // Update the trigger position
        trigger.transform.position = Vector3.right * (currentSectionIndex * 5f - 15f);

        // Move current index forward
        currentSectionIndex++;

        // Enqueue the current section
        queue.Enqueue(section);

        // If queue has more than three elements, dequeue and delete the old section
        if(queue.Count > 10) {
            GameObject previous = queue.Dequeue();
            Destroy(previous);
        }
    }
}
