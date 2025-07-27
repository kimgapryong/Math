using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 5;

    private float angle;
    private Vector3 target;
    public Vector3 startPos = Vector3.zero;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            angle += 15f;
            RotateMethod();

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            angle -= 15f;
            RotateMethod();
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
                target = hit.point;
        }

        if (target == Vector3.zero)
            return;

        Vector3 dir = target - transform.position;
        float magnitude = Mathf.Sqrt(dir.x * dir.x + dir.y * dir.y + dir.z * dir.z);

        if (Vector3.Distance(target, transform.position) < 0.1f)
            return;

        Vector3 normalized = dir / magnitude;
        Vector3 move = normalized * speed * Time.deltaTime;
        transform.position += move;



    }

    private void RotateMethod()
    {
        Vector3 direction = new Vector3(0, angle, 0);
        Debug.Log(angle);
        Quaternion quant = Quaternion.Euler(direction);
        transform.rotation *= quant;
    }

}
