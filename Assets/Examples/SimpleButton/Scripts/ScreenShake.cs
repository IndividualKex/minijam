using UnityEngine;

public class ScreenShake : MonoBehaviour {
    public static ScreenShake instance { get; private set; }

    static float timer;

    void Awake() {
        instance = this;
    }

    void Update() {
        timer = Mathf.Max(0, timer - Time.unscaledDeltaTime);
        transform.localPosition = Random.insideUnitSphere * timer * timer;
    }

    public static void Shake(float magnitude = .5f) {
        timer = Mathf.Max(timer, magnitude);
    }
}
