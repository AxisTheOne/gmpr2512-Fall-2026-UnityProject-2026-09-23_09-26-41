using UnityEngine;

public class PortalGate : MonoBehaviour
{
    [SerializeField] GameObject exitPortal;
    Rigidbody2D ball;

    public float debounce;

    void Start()
    {
        debounce = 0;
    }

    void Update()
    {
        debounce--;
        if(debounce <= 0)
        {
            exitPortal.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ball = collision.gameObject.GetComponentInParent<Rigidbody2D>();
        if(ball != null)
        {
            debounce = 50;
            exitPortal.SetActive(false);
            ball.gameObject.transform.position = exitPortal.transform.position;

            float rotationDif = exitPortal.transform.eulerAngles.z - transform.eulerAngles.z;
            Vector2 newVelocity = RotateVector(ball.linearVelocity, rotationDif);
            ball.linearVelocity = newVelocity;
        }
    }

    private Vector2 RotateVector(Vector2 v, float degrees)
    {
        //Copied from my Math and Physics Unity assignment :}
        //Most of the time the Vector is rotated accordingly.
        float radians = degrees * Mathf.Deg2Rad;
        float sin = Mathf.Sin(radians);
        float cos = Mathf.Cos(radians);
        return new Vector2(v.x * cos - v.y * sin, v.x * sin + v.y * cos);
    }
}
