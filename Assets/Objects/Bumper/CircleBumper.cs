using UnityEngine;

public class CircleBumper : MonoBehaviour
{
    [SerializeField] SpriteRenderer rend;
    [SerializeField] private UnityEngine.Rendering.Universal.Light2D myLight;
    [SerializeField] float bumperForce = 30f;
    [SerializeField] bool randomColor;
    Rigidbody2D ball;

    float timeStamp, delayTime;
    Color defaultColor;
    Vector2 defaultSize;

    void Start()
    {
        delayTime = 0.1f;
        defaultColor = rend.color;
        defaultSize = rend.transform.localScale;
    }

    void Update()
    {
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
        if(ball != null)
        {
            timeStamp = Time.time;
            rend.color = Color.white;
            rend.transform.localScale = defaultSize * 1.5f;
            myLight.color = Color.white;

            Vector3 bounceDirection = (ball.gameObject.transform.position - transform.position).normalized;
            ball.AddForce(bounceDirection * bumperForce, ForceMode2D.Impulse);

            Color setRandomColor = new Color(
                Random.Range(0f, 1f),
                Random.Range(0f, 1f),
                Random.Range(0f, 1f),
                1f
            );
            if (randomColor)
            {
                rend.color = setRandomColor;
                myLight.color = Color.Lerp(myLight.color, setRandomColor, 0.02f);
            }
        }
    }
}
