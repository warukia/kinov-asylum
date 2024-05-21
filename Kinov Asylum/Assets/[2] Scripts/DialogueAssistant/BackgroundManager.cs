using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour
{
    private SpriteRenderer sprRenderer;
    public UIDialogueAssistantViktorWin viktorDialogue;
    public Sprite illustration1;
    public Sprite illustration2;
    public Sprite illustration3;
    public Sprite illustration4;
    public Sprite illustration5;

    void Start()
    {
        sprRenderer = GetComponent<SpriteRenderer>();

        sprRenderer.sprite = illustration1;
    }

    void Update()
    {

    }
}