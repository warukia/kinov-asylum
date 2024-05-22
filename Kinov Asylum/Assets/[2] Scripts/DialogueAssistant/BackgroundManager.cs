using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour
{
    public UIDialogueAssistantViktorWin viktorDialogue;
    public GameObject canvas;

    // ILUSTRACIONES
    private SpriteRenderer sprRenderer;
    public Sprite illustration1;
    public Sprite illustration2;
    public Sprite illustration3;
    public Sprite illustration4;
    public Sprite illustration5;
    public Sprite illustration6;

    void Start()
    {
        sprRenderer = GetComponent<SpriteRenderer>();

        canvas.SetActive(false);

        sprRenderer.sprite = illustration1;
    }

    void Update()
    {
        if (viktorDialogue.messageInt == 1)
        {
            sprRenderer.sprite = illustration1;
        }
        else if (viktorDialogue.messageInt == 3)
        {
            sprRenderer.sprite = illustration2;
        }
        else if (viktorDialogue.messageInt == 4)
        {
            sprRenderer.sprite = illustration3;
        }
        else if (viktorDialogue.messageInt == 5)
        {
            sprRenderer.sprite = illustration4;
        }
        else if (viktorDialogue.messageInt == 6)
        {
            sprRenderer.sprite = illustration5;
        }
        else if (viktorDialogue.messageInt == 7)
        {
            sprRenderer.sprite = illustration6;
        }
        else if (viktorDialogue.messageInt == 8)
        {
            canvas.SetActive(true);
            Destroy(gameObject);
        }
    }
}