using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CifogDialogueSystem
{
    public class Monologue : IEnumerable<Sentence>
    {
        public event Action monologueStarted;
        public event Action monologueEnded;

        public DialogueCharacter Character { get; set; }
        public List<Sentence> Sentences { get; set; } = new List<Sentence>();

        public IEnumerator<Sentence> GetEnumerator()
        {
            monologueStarted?.Invoke();

            foreach (Sentence sentence in Sentences)
            {
                yield return sentence;
            }

            monologueEnded?.Invoke();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
