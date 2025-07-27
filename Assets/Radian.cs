using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Radian : MonoBehaviour
{
    public Transform player;
    public float viewAngle;

    Vector3 maxScale = new Vector3(5, 5, 5);
    public float maxView;

    public Transform target;
    public float lotateSpeed;
    public float distance;

    private bool isChek;

    private float degree = 0;
    /* // Start is called before the first frame update
     void Start()
     {
         float degrees = 45f;
         float radians = degrees * Mathf.Deg2Rad;
         Debug.Log("45도 -> 라디안 : " + radians);

         float radianValue = Mathf.PI / 3;
         float degreeValue = radianValue * Mathf.Rad2Deg;
         Debug.Log("파이/3 라디안 -> 도 변환  : " + degreeValue);
     }

     private void Update()
     {
         float speed = 5f;
         float angle = 30f;
         float radian = angle * Mathf.Deg2Rad;

         Vector3 direction = new Vector3(Mathf.Cos(radian), 0, Mathf.Sin(radian));
         transform.position += direction * speed * Time.deltaTime;
     }*/

    /* private void Update()
     {
         if (Input.GetKeyDown(KeyCode.RightArrow))
         {
             angle += 15;
         }
         if (Input.GetKeyDown(KeyCode.LeftArrow))
         {
             angle -= 15;
         }
         if (Input.GetKeyDown(KeyCode.UpArrow))
         {
             speed++;
         }
         if (Input.GetKeyDown(KeyCode.DownArrow))
         {
             speed--;
         }

         if (angle == 500)
             return;

         float radian = angle * Mathf.PI / 180;
         Vector3 direction = new Vector3(Mathf.Cos(radian), 0, Mathf.Sin(radian));
         transform.position += direction * speed * Time.deltaTime;
     }*/

    private void Update()
      {
          Vector3 toPlayer = (player.position - transform.position).normalized;
          Vector3 forward = transform.forward;

          float dot = forward.x * toPlayer.x + forward.y * toPlayer.y + forward.z * toPlayer.z;
          float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;

        if(Vector3.Distance(transform.position, player.transform.position) <= maxView)
        {
            if (angle < viewAngle / 2 && !isChek)
            {
                Debug.LogError("위혐");
                isChek = true;
               
                StartCoroutine(ScaleUp());
            }
        }
      }

    private IEnumerator ScaleUp()
    {
        while (transform.localScale.x < maxScale.x)
        {
            Vector3 scale = transform.localScale + Vector3.one * 0.55f;
            transform.localScale = scale;
            yield return new WaitForSeconds(0.01f);
        }

        Debug.Log("dksehlsek");
        isChek = false;
        transform.localScale = Vector3.one;
        player.transform.position = player.GetComponent<Move>().startPos;
    }
  
   /* private void Update()
    {
        degree += Time.deltaTime * lotateSpeed;
        transform.position = new Vector3(target.position.x + Mathf.Cos(degree) * distance, target.position.y, target.position.z + Mathf.Sin(degree) * distance) ;
    }*/


}
