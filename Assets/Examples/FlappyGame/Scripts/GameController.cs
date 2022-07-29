using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public TextMeshProUGUI mainText;
    public TextMeshProUGUI scoreText;
    public PlayerController playerController;

    int _score;
    int score {
        get {
            return _score;
        }
        set {
            // Check if score increased, and if so, play level up sound
            if(value > _score)
                AudioManager.PlayLevelUpSound();
            _score = value;
        }
    }

    State state;
    float gameOverDelayTimer;

    void Awake() {
        // Set time scale to 0 to pause the game
        Time.timeScale = 0;
        state = State.Start;

        // Show text saying to push space
        mainText.text = "Press SPACE to start";
        mainText.gameObject.SetActive(true);

        // Listen for when player collides with something to end the game
        playerController.Collided += GameOver;
    }

    void Update() {
        // Set score based on player position
        score = Mathf.Max(0, Mathf.FloorToInt((playerController.transform.position.x / 5f) - 4));
        scoreText.text = $"Score: {score}";

        // Update game over delay timer, so you don't accidentally restart immediately
        if(state == State.GameOver)
            gameOverDelayTimer += Time.unscaledDeltaTime;

        // When pressing space
        if(Input.GetKeyDown(KeyCode.Space)) {
            // If game hasn't started, start it
            if(state == State.Start)
                StartGame();

            // Tell the player to jump
            playerController.Jump();

            // If game is over, reload the game
            if(state == State.GameOver && gameOverDelayTimer > .5f)
                SceneManager.LoadScene("FlappyGame"); // Change scene name if loading in your project
        }
    }

    void StartGame() {
        // Start game and hide text
        state = State.Playing;
        Time.timeScale = 1;
        mainText.gameObject.SetActive(false);
    }

    void GameOver() {
        // Show text saying game over, and play game over sound
        state = State.GameOver;
        AudioManager.PlayGameOverSound();
        Time.timeScale = 0;
        mainText.text = "GAME OVER";
        mainText.gameObject.SetActive(true);
    }

    public enum State {
        Start,
        Playing,
        GameOver,
    }
}
