using UnityEngine;

public class AudioManager : MonoBehaviour {
    public static AudioManager instance { get; private set; }

    public AudioSource jumpSound;
    public AudioSource gameOverSound;
    public AudioSource levelUpSound;

    void Awake() {
        // Create singleton so it can be called from anywhere
        instance = this;
    }

    public static void PlayJumpSound() {
        instance.jumpSound.Play();
    }

    public static void PlayGameOverSound() {
        instance.gameOverSound.Play();
    }

    public static void PlayLevelUpSound() {
        instance.levelUpSound.Play();
    }
}
