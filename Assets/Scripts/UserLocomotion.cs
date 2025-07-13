using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class UserLocomotion : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 1.5f;

    [Header("Input Action Asset")]
    public InputActionProperty inputMove;

    [Header("XR Camera")]
    public Transform headTransform;

    private void Update()
    {
        Vector2 input = inputMove.action.ReadValue<Vector2>();

        // movimento relativo alla direzione della testa
        Vector3 forward = new Vector3(headTransform.forward.x, 0, headTransform.forward.z).normalized;
        Vector3 right = new Vector3(headTransform.right.x, 0, headTransform.right.z).normalized;

        Vector3 direction = forward * input.y + right * input.x;
        transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
    }
}
