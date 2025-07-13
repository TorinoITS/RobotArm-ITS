using Unity.Tutorials.Core.Editor;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class TriggerEvents : MonoBehaviour
{
    [SerializeField] private string requiredTag = "";
    [SerializeField] private UnityEvent onTriggerEnterEvent = new();
    [SerializeField] private UnityEvent onTriggerStayEvent = new();
    [SerializeField] private UnityEvent onTriggerExitEvent = new();

    private Collider m_trigger;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_trigger = GetComponent<Collider>();
        m_trigger.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(requiredTag.IsNullOrEmpty() || (requiredTag.IsNotNullOrEmpty() && other.gameObject.CompareTag(requiredTag)))
        {
            onTriggerEnterEvent.Invoke();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (requiredTag.IsNullOrEmpty() || (requiredTag.IsNotNullOrEmpty() && other.gameObject.CompareTag(requiredTag)))
        {
            onTriggerStayEvent.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (requiredTag.IsNullOrEmpty() || (requiredTag.IsNotNullOrEmpty() && other.gameObject.CompareTag(requiredTag)))
        {
            onTriggerExitEvent.Invoke();
        }
    }
}
