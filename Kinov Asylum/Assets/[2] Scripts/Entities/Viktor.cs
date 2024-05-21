using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Viktor : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    private UIDialogueAssistantViktorEncounter viktorEncounterDialogue;

    private bool isGone;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rb.velocity = Vector2.zero;
        isGone = false;

        viktorEncounterDialogue = GameObject.Find("Canvas Dialogues/DialogueAssistant")?.GetComponent<UIDialogueAssistantViktorEncounter>();

    }

    void Update()
    {
        if (viktorEncounterDialogue.messageInt == 6 && !isGone)
        {
            isGone = true;
            Vector2 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;

            rb.velocity = new Vector2(4, 0);
        }
    }
}