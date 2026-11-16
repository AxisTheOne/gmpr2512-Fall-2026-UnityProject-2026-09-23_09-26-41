using UnityEngine;

public class CircleBumper : MonoBehaviour
{
    [SerializeField] SpriteRenderer rend;
    [SerializeField] private UnityEngine.Rendering.Universal.Light2D myLight;
    [SerializeField] private CircleBumper toggleBumper; 
    [SerializeField] float bumperForce = 30f;
    [SerializeField] bool randomColor;
    [SerializeField] bool isActive = true;
    Rigidbody2D ball;
    CircleCollider2D myCollider;

    float timeStamp, delayTime;
    Color defaultColor;
    Vector2 defaultSize;

    void Start()
    {
        delayTime = 0.1f;
        defaultColor = rend.color;
        defaultSize = rend.transform.localScale;
        myCollider = GetComponentInParent<CircleCollider2D>();

        if (!isActive)
            ToggleActive(false);
    }

    void Update()
    {
        // Tween Color and Size back to default after a short delay
        if (Time.time > timeStamp + delayTime)
        {
            rend.color = Color.Lerp(rend.color, defaultColor, 0.02f);
            rend.transform.localScale = Vector3.Lerp(rend.transform.localScale, defaultSize, 0.02f);
            myLight.color = Color.Lerp(myLight.color, defaultColor, 0.02f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ball = collision.gameObject.GetComponentInParent<Rigidbody2D>();
        if(ball != null && isActive)
        {
            timeStamp = Time.time;
            rend.color = Color.white;
            rend.transform.localScale = defaultSize * 1.5f;
            myLight.color = Color.white;

            // Check if this is a toggle Bumper
            if (toggleBumper != null)
            {
                toggleBumper.ToggleActive(!toggleBumper.isActive);
                ToggleActive(!isActive);
            }

            // Get direction and apply force
            Vector3 bounceDirection = (ball.gameObject.transform.position - transform.position).normalized;
            ball.AddForce(bounceDirection * bumperForce, ForceMode2D.Impulse);

            // Change Color
            Color setRandomColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
            if (randomColor)
            {
                rend.color = setRandomColor;
                myLight.color = Color.Lerp(myLight.color, setRandomColor, 0.02f);
            }
        }
    }

    public void ToggleActive(bool activeSet)
    {
        // Toggle Active
        isActive = activeSet;
        rend.enabled = activeSet;
        myCollider.enabled = activeSet;
    }
}
