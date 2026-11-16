using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] bool spins = false;
    [SerializeField] float lifeTime = 8.0f, spinSpeed = 0.5f;

    bool isActive = false;
    float lifeTimer = 0;
    void Start()
    {

    }

    void Update()
    {
        if (spins)
        {
            transform.Rotate(0, 0, spinSpeed);
        }

        if (gameObject.activeSelf && !isActive)
        {
            isActive = true;
            lifeTimer = 0;
        }

        lifeTimer += Time.deltaTime;
        if (lifeTimer >= lifeTime)
        {
            gameObject.SetActive(false);
            isActive = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);
        isActive = false;
    }
}