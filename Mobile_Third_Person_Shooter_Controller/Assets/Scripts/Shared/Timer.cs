using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private class TimedEvent
    {
        public float TimeToExecute;
        public Callback Method;
    }

    private List<TimedEvent> _events;

    public delegate void Callback();

    private void Awake()
    {
        _events=new List<TimedEvent>();
    }

    public void Add(Callback method, float inSeconds)
    {
        _events.Add(new TimedEvent
        {
            Method = method,
            TimeToExecute = Time.time+inSeconds
        });
    }

    private void Update()
    {
        if(_events.Count==0) return;

        for (int i = 0; i < _events.Count; i++)
        {
            var timedEvent = _events[i];
            if (timedEvent.TimeToExecute <= Time.time)
            {
                timedEvent.Method();
                _events.Remove(timedEvent);
            }
        }
    }
}
