using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAnimation : MonoBehaviour
{
    public float amplitude = 0.3f;
    public float frequency = 1.2f;
    Vector3 startPos;
    float phase;
    void Start()
    {
        startPos = transform.localPosition;
        phase = Random.value * Mathf.PI * 2;
    }

   
    void Update()
    {
        float offset = Mathf.Sin(Time.time * frequency + phase) * amplitude;
        transform.localPosition = startPos + Vector3.up * offset;
    }
}
