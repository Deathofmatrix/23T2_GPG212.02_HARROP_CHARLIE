using EasyAudioSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PetGame
{
    public class PlaySound : MonoBehaviour
    {
        [SerializeField] private string soundName;

        public void Play()
        {
            FindObjectOfType<AudioManager>().Play(soundName);
        }

        public void PlayThisSound(string sound)
        {
            FindObjectOfType<AudioManager>().Play(sound);
        }
    }
}
