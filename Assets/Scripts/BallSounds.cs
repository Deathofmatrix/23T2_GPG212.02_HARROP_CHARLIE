using EasyAudioSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PetGame
{
    public class BallSounds : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Tortoise"))
            {
                FindObjectOfType<AudioManager>().Play("TortoiseHit");
                return;
            }
            FindObjectOfType<AudioManager>().Play("Bounce");
        }
    }
}

