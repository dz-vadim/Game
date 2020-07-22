using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestroy : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Ball>())
        {
            Destroy(collision.gameObject);
            if (gameObject.tag == "Block")
            {
                Destroy(gameObject);
                GameController.Score++;
                GameController.countBlock--;
            }
        }
    }
}
