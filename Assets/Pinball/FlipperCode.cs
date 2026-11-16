using UnityEngine;
using UnityEngine.InputSystem;

public class FlipperCode : MonoBehaviour
{
    [SerializeField] bool rightFlipper;
    private HingeJoint2D hinge;
    
    void Start()
    {
        hinge = GetComponent<HingeJoint2D>();
    }
    
    void Update()
    {
        if (rightFlipper)
        {
            if (Keyboard.current.dKey.isPressed)
            {
                JointMotor2D motor = hinge.motor;
                motor.motorSpeed = 1000;
                hinge.motor = motor;
            }

            else
            {
                JointMotor2D motor = hinge.motor;
                motor.motorSpeed = -1000;
                hinge.motor = motor;
            }
        }

        else
        {
            if (Keyboard.current.aKey.isPressed)
            {
                JointMotor2D motor = hinge.motor;
                motor.motorSpeed = -1000;
                hinge.motor = motor;
            }

            else
            {
                JointMotor2D motor = hinge.motor;
                motor.motorSpeed = 1000;
                hinge.motor = motor;
            }
        }
    }
}
