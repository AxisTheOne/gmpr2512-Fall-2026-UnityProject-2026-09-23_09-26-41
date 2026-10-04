using UnityEngine;

public class CircleBumper : MonoBehaviour
{
    [SerializeField] SpriteRenderer rend;
    [SerializeField] private UnityEngine.Rendering.Universal.Light2D myLight;
    [SerializeField] bool randomColor;

    float timeStamp, delayTime;
    Color defaultColor;
    Vector2 defaultSize;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        delayTime = 0.1f;
        defaultColor = rend.color;
        defaultSize = rend.transform.localScale;
    }

    // Update is called once per frame
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
        timeStamp = Time.time;
        rend.color = Color.white;
        rend.transform.localScale = defaultSize * 1.5f;
        myLight.color = Color.white;
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
