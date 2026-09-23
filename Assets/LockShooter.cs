using UnityEngine;
using UnityEngine.InputSystem;

public class LockShooter : MonoBehaviour
{
    [SerializeField] Rigidbody2D mySelf;
    [SerializeField] private UnityEngine.Rendering.Universal.Light2D myLight;
    Rigidbody2D ball;

    float initialLock, shootTimer;
    Color baseColor;
    bool ballIn;

    void Start()
    {
        ballIn = false;
        initialLock = 0;
        shootTimer = 0;
        baseColor = myLight.color;
    }

    void Update()
    {
        myLight.color = Color.Lerp(myLight.color, baseColor, 0.02f);
        if (ballIn) {
            initialLock += 1;
            ball.linearVelocity = Vector3.zero;
            ball.gameObject.transform.position = Vector3.Lerp(ball.gameObject.transform.position, mySelf.gameObject.transform.position, 0.03f);
            myLight.color = Color.Lerp(myLight.color, Color.green, 0.05f);
            if (initialLock >= 100) {
                myLight.color = Color.red;
                shootTimer += 1;
                if (shootTimer >= 250 && Keyboard.current.spaceKey.wasPressedThisFrame)
                {
                    ball.linearVelocity = mySelf.gameObject.transform.right * 32f;
                    ballIn = false;
                    shootTimer = 0;
                    initialLock = 0;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ball = collision.gameObject.GetComponentInParent<Rigidbody2D>();

        if (ball != null && ballIn == false)
        {
            ballIn = true;
            initialLock = 0;
            shootTimer = 0;
        }
    }
}
