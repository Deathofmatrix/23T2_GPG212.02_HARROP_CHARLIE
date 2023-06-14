using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PetGame
{
    public class BallSpawner : MonoBehaviour
    {

        public void SpawnBall()
        {
            if (gameObject.activeInHierarchy == false)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                gameObject.transform.position = new Vector2(gameObject.transform.position.x, 3);
                gameObject.SetActive(true);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}
