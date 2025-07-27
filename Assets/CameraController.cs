using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float fallowSpeed;
    public Vector3 offset = new Vector3(0, 2, -4);

    private void LateUpdate()
    {
        transform.position = target.position + offset;

        Vector3 rotate = transform.position + Quaternion.Euler(0, target.eulerAngles.y,0) * offset;
        transform.position = rotate;

        transform.LookAt(target);

    }
}
