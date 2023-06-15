using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PetGame
{
    public class TortoiseName : MonoBehaviour
    {
        public string tortoiseName;
        public GameObject output;
        public bool isStartScreen;

        public void SetName(GameObject inputField)
        {
            tortoiseName = inputField.GetComponent<TMP_InputField>().text;
            PlayerPrefs.SetString("name", tortoiseName);
        }

        public void GetName()
        {
            tortoiseName = PlayerPrefs.GetString("name");
            output.GetComponent<TextMeshProUGUI>().text = $"{tortoiseName} the Tortoise";
        }

        private void Start()
        {
            if (isStartScreen)
            {
                PlayerPrefs.DeleteKey("name");
            }
            else if (!isStartScreen)
            {
                GetName();
            }
        }

    }
}

