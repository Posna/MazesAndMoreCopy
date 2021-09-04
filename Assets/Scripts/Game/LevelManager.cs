using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazesAndMore
{
    public class LevelManager : MonoBehaviour
    {
        public BoardManager boardManager;

        public TextAsset level;
        public GameObject finLevel;
        public GameObject levelUI;

        public Cheat cheatButton;

        private Color color_;
        private Color wallColor_;

        delegate void Del(string m);

        void si(string m)
        {
            Debug.Log(m);
        }

        /// <summary>
        /// Crea el nivel con un color concreto
        /// </summary>
        /// <param name="c"> Color del nivel </param>
        public void CreateLevel(Color c, Color wallColor)
        {
            color_ = c;
            wallColor_ = wallColor;
            boardManager.Init(this);
            boardManager.SetMap(level.text);

            Del del = si;
            del("hola");
#if UNITY_EDITOR || DEVELOPMENT_BUILD || CHEATS_AVAILABLE
            cheatButton.Init(this);
            cheatButton.gameObject.SetActive(true);
#endif
        }

        /// <summary>
        /// Limpia la escena
        /// </summary>
        public void ClearScene()
        {
            boardManager.ClearMap();
        }

        /// <returns> Devuelve el color del nivel </returns>
        public Color GetLevelColor()
        {
            return color_;
        }

        /// <returns> Devuelve el color del muro </returns>
        public Color GetWallColor()
        {
            return wallColor_;
        }

        /// <summary>
        /// Enseña una nueva pista
        /// </summary>
        public void ShowNewHint()
        {
            boardManager.NewHint();
        }

        /// <summary>
        /// Termina el nivel
        /// </summary>
        public void FinishLevel()
        {
            finLevel.SetActive(true);
            levelUI.SetActive(false);
        }

    }
}
