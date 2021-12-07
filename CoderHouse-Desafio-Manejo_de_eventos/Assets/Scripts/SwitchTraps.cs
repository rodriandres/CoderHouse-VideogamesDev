using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwitchTraps : MonoBehaviour
{
    [SerializeField] private UnityEvent onSwitchTraps;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            onSwitchTraps?.Invoke();
        }
    }
}
