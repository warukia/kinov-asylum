using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CifogDialogueSystem
{
    public class Sentence : IEnumerable<char>
    {
        private int currentIndex;

        public string Text { get; set; }

        public event Action sentenceStarted;
        public event Action sentenceEnded;

        public IEnumerator<char> GetEnumerator()
        {
            sentenceStarted?.Invoke();

            foreach (char c in Text)
            {
                yield return c;
            }

            sentenceEnded?.Invoke();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
