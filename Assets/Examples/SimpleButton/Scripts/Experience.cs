using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Experience : MonoBehaviour {
    public Image experienceBarFill;
    public TextMeshProUGUI text;
    public AudioSource levelUpSound;

    static readonly int experienceToLevel = 50;

    int experience;
    int level;

    void Awake() {
        experience = 0;
        level = 1;
    }

    public void AddExperience(int amount) {
        // Add experience
        experience += amount;

        // If it's more than than the level requirement, level up
        if(experience >= experienceToLevel) {
            experience -= experienceToLevel;
            level++;

            // Update level text
            text.text = $"LV {level}";

            // Play the level up sound
            levelUpSound.Play();

            // Shake the screen
            ScreenShake.Shake();
        }

        // Update the experience bar
        experienceBarFill.fillAmount = experience / (float)experienceToLevel;
    }
}
