using TMPro;
using UnityEngine;

public class RobotJointController : MonoBehaviour
{
    public enum RotationAxis { X, Y, Z }
    public RotationAxis rotationAxis;
    public float rotationAngle = 0;
    public float rotationSpeed = 30;
    public float minAngle = -180;
    public float maxAngle = 180;
    public int isRotating = 0;
    public TextMeshProUGUI textBox;

    private float startAngle;
    private float prevAngle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        switch (rotationAxis)
        {
            case RotationAxis.X: startAngle = transform.localRotation.x; break;
            case RotationAxis.Y: startAngle = transform.localRotation.y; break;
            case RotationAxis.Z: startAngle = transform.localRotation.z; break;
        }

        prevAngle = rotationAngle;
        textBox.text = rotationAngle.ToString("F2") + "°";
    }

    private void FixedUpdate()
    {
        float delta;

        if(isRotating != 0)
        {
            delta = isRotating * rotationSpeed * Time.fixedDeltaTime;
            if(prevAngle + delta < minAngle) rotationAngle = minAngle;
            else if(prevAngle + delta > maxAngle) rotationAngle = maxAngle;
            else rotationAngle = prevAngle + delta;

            switch(rotationAxis)
            {
                case RotationAxis.X: transform.Rotate(rotationAngle - prevAngle, 0, 0); break;
                case RotationAxis.Y: transform.Rotate(0, rotationAngle - prevAngle, 0); break;
                case RotationAxis.Z: transform.Rotate(0, 0, rotationAngle - prevAngle); break;
            }

            prevAngle = rotationAngle;
            textBox.text = rotationAngle.ToString("F2") + "°";
        }
    }

    public void RotateJoint(int direction)
    {
        isRotating = direction;
    }
}
