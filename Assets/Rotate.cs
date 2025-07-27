using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 2 - 4);
    public float smoothSpeed = 5f;

    private void LateUpdate()
    {
        
        Vector3 desiredPostion = target.position + Quaternion.Euler(0, target.eulerAngles.y, 0) * offset;
    }
    // Update is called once per frame
    void Update()
    {
        float input = Input.GetAxis("Horizontal");
        Quaternion rotate =  Quaternion.Euler(0, input * 45 * Time.deltaTime, 0);

        transform.rotation *= rotate;
    }
}
