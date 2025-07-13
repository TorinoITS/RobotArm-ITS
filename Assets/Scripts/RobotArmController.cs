using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class RobotArmController : MonoBehaviour
{
    public float angularVelocity = 30;
    public RobotJointController[] jointControllers = new RobotJointController[0];

    private void Start()
    {
        for(int i = 0; i < jointControllers.Length; i++)
        {
            jointControllers[i].rotationSpeed = angularVelocity;
        }
    }

    public void SetVelocity(float velocity)
    {
        angularVelocity = velocity;
        for (int i = 0; i < jointControllers.Length; i++)
        {
            jointControllers[i].rotationSpeed = angularVelocity;
        }
    }
}
