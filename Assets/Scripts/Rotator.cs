using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace PetGame
{
    public class Rotator : MonoBehaviour
    {
        [SerializeField] private float rotationRate;
        private void FixedUpdate()
        {
            transform.eulerAngles += new Vector3(0,0,rotationRate); 
        }
    }
}

