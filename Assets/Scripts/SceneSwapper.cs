using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PetGame
{
    public class SceneSwapper : MonoBehaviour
    {
        public void SwapSceneTo(string scene)
        {
            SceneManager.LoadScene(scene);
        }
    }
}

