using UnityEngine;
using TMPro;

[RequireComponent(typeof(MeshRenderer))]
public class Button : MonoBehaviour {
    public Camera cam;
    public Experience experience;
    public Color normalColor;
    public Color pressedColor;
    public TextMeshPro text;
    public AudioSource pressSound;

    Material material;
    bool pressed;

    void Awake() {
        // Get the material so you can change the color when clicked
        material = GetComponent<MeshRenderer>().material;
    }

    void Update() {
        // If you left clicked this frame
        if(Input.GetMouseButtonDown(0)) {
            // Check if the mouse is over the button
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit hit, float.PositiveInfinity, LayerMask.GetMask("Button"))) {
                // If so, press the button
                Press();
            }
        }

        // If you let go of the button and it's pressed
        if(pressed && Input.GetMouseButtonUp(0))
            // Unpress the button
            Unpress();

        // Alternatively use space bar
        if(Input.GetKeyDown(KeyCode.Space))
            Press();
        else if(Input.GetKeyUp(KeyCode.Space))
            Unpress();
    }

    void Press() {
        if(pressed) return;
        pressed = true;

        // Change the color
        material.color = pressedColor;

        // Shrink the text
        text.transform.localScale = Vector3.one * .023f;

        // Play the press sound
        pressSound.Play();

        // Get a random number
        float value = Random.Range(0f, 1f);
        // Usually, add a small random amount of experience
        if(value < .9f)
            experience.AddExperience(Random.Range(1, 5));
        // But if you're lucky, add a lot of experience
        else
            experience.AddExperience(Random.Range(30, 50));
    }

    void Unpress() {
        if(!pressed) return;
        pressed = false;

        // Change the color
        material.color = normalColor;

        // Unshrink the text
        text.transform.localScale = Vector3.one * .025f;
    }
}
