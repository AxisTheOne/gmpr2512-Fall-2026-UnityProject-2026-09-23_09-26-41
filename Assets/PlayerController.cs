using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D ball;
    [SerializeField] HingeJoint2D leftFlipper, rightFlipper;
    [SerializeField] GameObject launcher, upperLimit, lowerLimit;
    [SerializeField] float launcherSpeedDown, launcherSpeedUp, launcherForce;

    float launchDistance;
    public bool canLaunch, isLaunched, canFlipper;

    void Start()
    {
        isLaunched = true;
        canFlipper = false;
    }

    void Update()
    {
        if (Keyboard.current.spaceKey.isPressed && canLaunch)
        {
            if (isLaunched && canLaunch)
                isLaunched = false;

            // Tween downward
            launcher.transform.Translate(Vector2.down * Time.deltaTime * launcherSpeedDown);

            // Limit the Launcher to the lower limit
            if (launcher.transform.position.y < lowerLimit.transform.position.y)
                launcher.transform.position = new Vector2(launcher.transform.position.x, lowerLimit.transform.position.y);

            launchDistance = Vector2.Distance(launcher.transform.position, upperLimit.transform.position);
        }
        else
        {
            if (launcher.transform.position.y < upperLimit.transform.position.y)
                launcher.transform.Translate(Vector2.up * Time.deltaTime * launcherSpeedUp);
            else
            {
                // Launch the Ball
                if (!isLaunched && canLaunch)
                {
                    ball.AddForce(Vector2.up * launcherForce * launchDistance, ForceMode2D.Impulse);
                    isLaunched = true;
                    canLaunch = false;
                    canFlipper = true;
                }
            }

            // Limit the Launcher to the UpperLimit
            if (launcher.transform.position.y > upperLimit.transform.position.y)
                launcher.transform.position = new Vector2(launcher.transform.position.x, upperLimit.transform.position.y);
        }

        // Left Flipper
        if (Keyboard.current.aKey.isPressed && canFlipper)
            leftFlipper.useMotor = true;
        else
            leftFlipper.useMotor = false;

        // Right Flipper
        if (Keyboard.current.dKey.isPressed && canFlipper)
            rightFlipper.useMotor = true;
        else
            rightFlipper.useMotor = false;

        // Exit Application
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
            Application.Quit();
    }
}
