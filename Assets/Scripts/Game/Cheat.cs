using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MazesAndMore
{
    public class Cheat : MonoBehaviour
    {
        LevelManager lvlManager;
        bool pressed = false;
        float time = 0;
        int timesPressed = 0;

        void Update()
        {
            if (pressed)
            {
                time -= Time.deltaTime;
                if (timesPressed >= 3)
                {
                    for (int i = 0; i < 3; i++)
                        lvlManager.ShowNewHint();
                }
                if (time < 0.0f)
                {
                    pressed = false;
                    timesPressed = 0;
                }
            }
        }

        public void Init(LevelManager lvl)
        {
            lvlManager = lvl; 
        }

        public void ButtonClick()
        {
            if (!pressed)
            {
                pressed = true;
                time = 1.0f;
            }

            timesPressed++;
        }
    }
}
