using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class HighSchoolSlayer : MonoBehaviour
    {
        public GameObject gameContainer, playerContainer;
        public GameObject inGameCanvas, characterCreationCanvas; // , menu?
        public CharacterLinkMenuGame[] characters;
        public Transform characterListContainer;
        public Scrollbar scrollbar;

        int crtIdx;

		void Start()
		{
            foreach (var c in characters)
                Instantiate(c.menuCharacter, characterListContainer);
            scrollbar.value = 0;
        }

		public void PreviousCharacter()
        {
            crtIdx--;
            if (crtIdx < 0)
                crtIdx = 0;
            scrollbar.value = crtIdx / (characters.Length - 1);
        }

        public void NextCharacter()
		{
            crtIdx++;
            if (crtIdx >= characters.Length)
                crtIdx = characters.Length - 1;
            scrollbar.value = crtIdx / (characters.Length - 1);
        }

        public void StartGame()
		{
            if (characters == null || characters[crtIdx] == null)
            {
                Debug.LogError("Character selection error!");
                return;
            }

            Instantiate(characters[crtIdx].gameCharacter, playerContainer.transform);
            gameContainer.SetActive(true);
            inGameCanvas.SetActive(true);
            characterCreationCanvas.SetActive(false);
		}

        private void SetCharacter()
		{
            //TODO
		}
    }
}