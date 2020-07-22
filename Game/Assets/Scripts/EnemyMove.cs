using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private GameObject Target;
    public static float speedMove = 1f;


    void Update()
    {
        Target = GameObject.FindWithTag("Ball");
        if (Target)
        {
            float direction = Target.transform.position.x - transform.position.x;

            if (Mathf.Abs(direction) < 20)
            {
                Vector3 pos = transform.position;
                pos.x += Mathf.Sign(direction) * speedMove * Time.deltaTime;
                transform.position = pos;
            }
        }
    }
}
