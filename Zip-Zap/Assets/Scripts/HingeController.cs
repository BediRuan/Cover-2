using UnityEngine;

[RequireComponent(typeof(HingeJoint2D))] // Ensure this script's GameObject has a HingeJoint2D component
public class HingeController : MonoBehaviour
{
    private HingeJoint2D hingeJoint2D; // Reference to the HingeJoint2D component
    private bool isSpacePressed = false; // Track the state of the space key

    void Start()
    {
        hingeJoint2D = GetComponent<HingeJoint2D>();
        
        JointAngleLimits2D limits = hingeJoint2D.limits;
        limits.min = 0; 
        limits.max = 90;
        hingeJoint2D.limits = limits;
        hingeJoint2D.useLimits = true; // Enable limits
    }

    void Update()
    {
        // Check if the player has pressed the space key down
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isSpacePressed)
            {
                SetMotorVelocity(400); // If space key is pressed, set motor.targetVelocity to 400
                isSpacePressed = true; 
            }
        }
        // Check if the player has released the space key
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            if (isSpacePressed)
            {
                SetMotorVelocity(-400); // When space key is released, set motor.targetVelocity to -400
                isSpacePressed = false; 
                isSpacePressed = false; 
            }
        }
    }

    void SetMotorVelocity(float velocity)
    {
        // Get the current motor settings
        JointMotor2D motor = hingeJoint2D.motor;
        motor.motorSpeed = velocity; // Update the motorSpeed to the specified velocity
        hingeJoint2D.motor = motor; // Assign the updated motor back to the HingeJoint2D component
        hingeJoint2D.useMotor = true; // Ensure the motor feature is enabled
    }
}
