using UnityEngine;

public class CompressionController : MonoBehaviour
{
    public Vector3 movementDirection = Vector3.down; // Direction of compression
    public float compressionSpeed = 1.0f; // Speed of compression
    public float pushForce = 10.0f; // Force applied to the player when colliding with the wall

    void Update()
    {
        // Move the wall in the compression direction
        transform.Translate(movementDirection * compressionSpeed * Time.deltaTime);
    }

    void OnCollisionStay(Collision collision)
    {
        // Check if the colliding object is the player
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRigidbody = collision.rigidbody;

            // Calculate the push direction away from the wall
            Vector3 pushDirection = -movementDirection.normalized;

            // Apply force to the player to push them away from the wall
            playerRigidbody.AddForce(pushDirection * pushForce, ForceMode.Impulse);
        }
    }
}
