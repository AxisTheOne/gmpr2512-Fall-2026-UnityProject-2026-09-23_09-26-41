using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] bool spins = false;
    [SerializeField] float lifeTime = 8.0f, spinSpeed = 0.5f;

    bool isActive = false;
    float lifeTimer = 0;

    void Update()
    {
        // For the Spinning Variant
        if (spins)
        {
            transform.Rotate(0, 0, spinSpeed * Time.deltaTime);
        }

        // Reset timer if activated
        if (gameObject.activeSelf && !isActive)
        {
            isActive = true;
            lifeTimer = 0;
        }

        // Deactivate after some time (if for some reason the bullet escapes the Play Area)
        lifeTimer += Time.deltaTime;
        if (lifeTimer >= lifeTime)
        {
            gameObject.SetActive(false);
            isActive = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Deactivate on touch
        gameObject.SetActive(false);
        isActive = false;
    }
}