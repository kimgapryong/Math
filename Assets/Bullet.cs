using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    private float t = 0f;

    private bool isEnd;
    private Transform start;
    private Transform end;
    private float length;

    private void Update()
    {
        if (start == null || end == null)
            return;

        t = Mathf.PingPong(Time.time / 10, length);
        transform.position = Vector3.Lerp(start.position, end.position, t);
    }
    public void StartPingpong(Transform start, Transform end, float length)
    {
        if (isEnd)
            return;

        this.start = start;
        this.end = end;
        this.length = length;

        isEnd = true;
    }
}
