using UnityEngine;

public class DropTarget : MonoBehaviour
{
    private UnityEngine.Rendering.Universal.Light2D myLight;
    private SpriteRenderer spriteRend;
    private Collider2D boxCollide;
    bool hasDropped = false;
    Color defaultColor;

    void Start()
    {
        boxCollide = GetComponentInParent<Collider2D>();
        spriteRend = GetComponentInParent<SpriteRenderer>();
        myLight = GetComponentInParent<UnityEngine.Rendering.Universal.Light2D>();
        defaultColor = myLight.color;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Disable and drop
        hasDropped = true;
        boxCollide.enabled = false;
        spriteRend.enabled = false;
        myLight.color = Color.red;
    }

    public void resetTarget()
    {
        // Reset State
        hasDropped = false;
        boxCollide.enabled = true;
        spriteRend.enabled = true;
        myLight.color = defaultColor;
    }

    public bool isActive()
    {
        // Return if were active
        return !hasDropped;
    }
}
