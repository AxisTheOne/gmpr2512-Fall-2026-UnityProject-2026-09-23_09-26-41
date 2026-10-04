using UnityEngine;

public class FreezeZone : MonoBehaviour
{
    [SerializeField] float freezeDuration = 100f;
    Rigidbody2D ball;

    private Vector3 returnVelocity;

    private float delay;
    private float unfreezeTime;
    private bool frozen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        delay = 0;
        unfreezeTime = 20;
        frozen = false;
        returnVelocity = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(delay > 0)
        {
            delay -= 1;
        }
        if(frozen && delay < unfreezeTime)
        {
            frozen = false;
            ball.constraints = RigidbodyConstraints2D.None;
            ball.linearVelocity = returnVelocity;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ball = collision.gameObject.GetComponentInParent<Rigidbody2D>();
        if(ball != null && delay <= 0)
        {
            delay = freezeDuration + unfreezeTime;
            returnVelocity = ball.linearVelocity;
            ball.constraints = RigidbodyConstraints2D.FreezePosition;
            frozen = true;
        }
    }
}
