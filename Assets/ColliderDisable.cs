using UnityEngine;

public class ColliderDisable : MonoBehaviour
{
    [SerializeField] SpriteRenderer rend;
    [SerializeField] Collider2D collider;
    [SerializeField] Collider2D collider2;
    [SerializeField] Collider2D collider3;
    [SerializeField] Collider2D collider4;
    [SerializeField] private UnityEngine.Rendering.Universal.Light2D myLight;

    float timeLapse;
    float pause;
    Color defaultColor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        defaultColor = myLight.color;
        timeLapse = 0;
        pause = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if ((collider.enabled == false && collider2.enabled == false && collider3.enabled == false && collider4.enabled == false) || (timeLapse >= 50)) {
            timeLapse += 1;
            myLight.color = Color.yellow;
            if (timeLapse >= 100) {
                pause += 1;
                myLight.color = Color.yellow;
                if (pause >= 20)
                {
                    collider.enabled = true;
                    myLight.color = defaultColor;
                    timeLapse = 0;
                    pause = 0;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collider.enabled = false;
        myLight.color = Color.red;
    }
}
