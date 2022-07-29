using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {
    public event UnityAction Collided;

    public float speed = 5f;
    public float jumpSpeed = 10f;

    Rigidbody rigidBody;

    void Awake() {
        rigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        // Constantly move the player to the right
        rigidBody.velocity = new Vector3(speed, rigidBody.velocity.y, 0);
    }

    public void Jump() {
        // Jump by setting the velocity Y component to jumpSpeed
        rigidBody.velocity = new Vector3(speed, jumpSpeed, 0);

        // Play the jump sound
        AudioManager.PlayJumpSound();
    }

    void OnCollisionEnter(Collision col) {
        // When collider with something, trigger collision event
        Collided?.Invoke();
    }
}
