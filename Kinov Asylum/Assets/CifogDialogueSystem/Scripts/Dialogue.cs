using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CifogDialogueSystem
{
    public class Dialogue : IEnumerable<Monologue>
    {
        public event Action dialogueStarted;
        public event Action dialogueEnded;

        public List<Monologue> Monologues { get; set; } = new List<Monologue>();

        public IEnumerator<Monologue> GetEnumerator()
        {
            dialogueStarted?.Invoke();

            foreach (Monologue monologue in Monologues)
            {
                yield return monologue;
            }

            dialogueEnded?.Invoke();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}