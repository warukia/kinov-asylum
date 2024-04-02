using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

namespace CifogDialogueSystem
{
    public class DialogueSystem : MonoBehaviour
    {
        public float characterDelay;
        public TextMeshProUGUI uiDialogueText;
        //public TextMeshProUGUI uiContinueText;
        public Image uiContinueIcon;
        public TextMeshProUGUI uiCharacterNameText;
        public Image uiCharacterImage;
        public Button[] choicesButtons;
        public string endOfSentenceText;
        public KeyCode keyToSkipText = KeyCode.E;

        private Dialogue currentDialogue;
        private bool isTypingText;

        public List<Choice> Choices { get; set; } = new List<Choice>();

        private float currentCharacterDelay;

        public void StartDialogue(Dialogue dialogue)
        {           
            currentDialogue = dialogue;
            currentCharacterDelay = characterDelay;

            StartCoroutine(ProcessDialogCoroutine());
        }

        public IEnumerator ProcessDialogCoroutine()
        {
            foreach (Monologue monologue in currentDialogue)
            {
                if (uiCharacterNameText != null)
                {
                    uiCharacterNameText.text = monologue.Character.Name;
                }

                if (uiCharacterImage != null)
                {
                    uiCharacterImage.sprite = monologue.Character.Image;
                }

                foreach (Sentence sentence in monologue)
                {
                    isTypingText = true;
                    uiDialogueText.text = string.Empty;

                    if (uiContinueIcon != null && !string.IsNullOrEmpty(endOfSentenceText))
                    {
                        uiContinueIcon.enabled = false;
                        //uiContinueText.text = string.Empty;
                    }

                    foreach (char c in sentence)
                    {
                        uiDialogueText.text += c.ToString();
                        yield return new WaitForSeconds(currentCharacterDelay);
                    }

                    isTypingText = false;

                    if (uiContinueIcon != null && !string.IsNullOrEmpty(endOfSentenceText))
                    {
                        uiContinueIcon.enabled = true;
                        //uiContinueText.text = endOfSentenceText;
                    }

                    currentCharacterDelay = characterDelay;

                    while (!Input.GetKeyDown(keyToSkipText))
                    {
                        yield return null;
                    }
                }
            }

            ShowChoices();
        }

        private void ShowChoices()
        {
            for (int i = 0; i < Choices.Count; i++)
            {
                Choice choice = Choices[i];
                choicesButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = choice.Text;
                choicesButtons[i].onClick.AddListener(() => { choice.Select(); });
            }
        }

        private void Update()
        {
            if (isTypingText && Input.GetKeyDown(keyToSkipText))
            {
                currentCharacterDelay = 0f;
            }
        }
    }
}
