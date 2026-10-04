using UnityEngine;
using UnityEngine.InputSystem;

public class FlipperCode : MonoBehaviour
{
    [SerializeField] bool rightFlipper;
    [SerializeField] Rigidbody2D mySelf;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.dKey.wasPressedThisFrame && rightFlipper)
        {
            mySelf.AddTorque(50f, ForceMode2D.Force);
        }

        if (Keyboard.current.aKey.wasPressedThisFrame && rightFlipper == false)
        {
            
        }
    }
}
