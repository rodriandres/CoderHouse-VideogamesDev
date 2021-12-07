using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class GoalZoneController : MonoBehaviour
{
    float stayTime;

    // EVENTS
    [SerializeField] private UnityEvent onWin;
    [SerializeField] private UnityEvent onScenaChange;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            onWin?.Invoke();
            onScenaChange?.Invoke();
        }
    }
}
