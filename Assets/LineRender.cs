using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LineRender : MonoBehaviour
{
    public Bullet bullet;
    public Transform target;
    
    public float extend = 1.5f;
    private LineRenderer lr;
    private float length = 5f;
    // Start is called before the first frame update
    void Awake()
    {
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 2;
        lr.widthMultiplier = 0.05f;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit hit, 100f))
        {
            target = hit.transform;
            bullet = target.GetComponent<Bullet>();
        }

        if (target == null) return;
        Vector3 a = transform.position;
        Vector3 b = target.position;
        Vector3 p = Vector3.LerpUnclamped(a, b, length);

        lr.SetPosition(0, a);
        lr.SetPosition(1, p);

        if (target == null || bullet == null)
            return;

        bullet.StartPingpong(transform, target.transform, length);
    }
}
