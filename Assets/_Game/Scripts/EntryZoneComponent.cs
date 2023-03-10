using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

[RequireComponent(typeof(Collider))]
public class EntryZoneComponent : MonoBehaviour
{
    [SerializeField] private Collider _triggerZone;
    [SerializeField] private UnityEvent _onEnteredZone;
    [SerializeField] private Color _color = Color.green;

    private bool IsZoneTrigger => _triggerZone.isTrigger;

    private void Awake()
    {
        if (_triggerZone == null)
            _triggerZone = GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!IsZoneTrigger)
        {
            _onEnteredZone.Invoke();
            Debug.Log("Collision");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (IsZoneTrigger)
        {
            _onEnteredZone.Invoke();
            Debug.Log("Trigger");
        }
    }

    private void OnDrawGizmos()
    {
        if (_triggerZone != null)
        {
            Gizmos.color = _color;
            var winZoneBounds = _triggerZone.bounds;
            Gizmos.DrawCube(winZoneBounds.center, winZoneBounds.size * 1.01f);
        }
    }
}
