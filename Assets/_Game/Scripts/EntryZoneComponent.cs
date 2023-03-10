using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

[RequireComponent(typeof(Collider))]
public class EntryZoneComponent : MonoBehaviour
{
    [SerializeField] private Collider _triggerZone;
    [SerializeField] private UnityGameObjectEvent _onEnteredZone;
    [SerializeField] private Color _color = Color.green;

    private bool IsZoneTrigger => _triggerZone.isTrigger;

    public void SetZoneEnteredEvent(UnityGameObjectEvent myEvent)
    {
        _onEnteredZone = myEvent;
    }

    private void Awake()
    {
        if (_triggerZone == null)
            _triggerZone = GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!IsZoneTrigger)
        {
            _onEnteredZone.Invoke(gameObject);
            Debug.Log("Collision");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (IsZoneTrigger)
        {
            _onEnteredZone.Invoke(other.gameObject);
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

[Serializable]
public class UnityGameObjectEvent : UnityEvent<GameObject>
{
}
