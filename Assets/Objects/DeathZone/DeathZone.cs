using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] GameObject ballSpawn;
    Rigidbody2D ball;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ball = collision.gameObject.GetComponentInParent<Rigidbody2D>();

        if (ball != null)
        {
            // Reset Ball State and Respawn
            ball.linearVelocity = Vector3.zero;
            ball.angularVelocity = 0;
            ball.transform.rotation = Quaternion.identity;
            ball.gameObject.transform.position = ballSpawn.transform.position;

            // Disable Flippers and Ball
            ball.gameObject.SetActive(false);
            playerController.canFlipper = false;

            // Reactivate the ball after 1.5f
            Invoke("ActivateBall", 1.5f);
        }
    }

    void ActivateBall() {
        // Enable Controls and Ball
        ball.gameObject.SetActive(true);
        playerController.canLaunch = true;
        playerController.canFlipper = true;
    }
}
