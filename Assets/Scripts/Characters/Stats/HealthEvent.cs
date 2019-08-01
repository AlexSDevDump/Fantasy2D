using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class HealthEvent
{
    [Range(0f, 1f)]
    public float healthPercent;
    public UnityEvent Event;
}
