using UnityEngine;
using UnityEngine.Events;

public class LevelGeneratorTrigger : MonoBehaviour {
    public event UnityAction TriggerEntered;

    void OnTriggerEnter(Collider col) {
        TriggerEntered?.Invoke();
    }
}
