using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CifogDialogueSystem
{

    public class Choice
    {
        public string Text { get; set; }

        public event Action choiceSelected;

        public void Select()
        {
            choiceSelected?.Invoke();
        }
    }
}
