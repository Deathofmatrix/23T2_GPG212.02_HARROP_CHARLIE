using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PetGame
{
    public class ColourPicker : MonoBehaviour
    {
        [SerializeField] private GameObject colourPicker;
        [SerializeField] private SpriteRenderer tortoiseColour;

        [SerializeField] private SpriteRenderer colourOptionOriginal;
        [SerializeField] private SpriteRenderer colourOption1;
        [SerializeField] private SpriteRenderer colourOption2;
        [SerializeField] private SpriteRenderer colourOption3;
/*        
        [SerializeField] private Color colourOriginal;
        [SerializeField] private Color colour1;
        [SerializeField] private Color colour2;
        [SerializeField] private Color colour3;*/

        [SerializeField] private List<Color> colourOptionsList = new List<Color>();

        private void Start()
        {
            colourOptionOriginal.color = tortoiseColour.color;
        }

        public void ShowOptions()
        {
            if (colourPicker.activeInHierarchy)
            {
                colourPicker.SetActive(false);
                return;
            }

            colourPicker.SetActive(true);
        }

        public void ChangeColour(Image colourOption)
        {
            tortoiseColour.color = colourOption.color;
        }
    }
}

