using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting.Antlr3.Runtime;

public class UIDialogueAssistant : MonoBehaviour
{
    private TextMeshProUGUI messageText;
    private TextWriter.TextWriterSingle textWriterSingle;

    private void Awake()
    {
        messageText = transform.Find("message/messageText").GetComponent<TextMeshProUGUI>();
        Application.targetFrameRate = 60;

        transform.Find("message").GetComponent<Button_UI>().ClickFunc = () =>
        {
            if (textWriterSingle != null && textWriterSingle.IsActive())
            {
                // Currently active TextWriter
                textWriterSingle.WriteAllAndDestroy();
            }
            else
            {
                string[] messageArray = new string[]
                {
                "This is the pepe",
                "Hi pepes",
                "This is a cool pepe",
                "Let's learn some pepes",
                "Check out pepes",
                };

                string message = messageArray[Random.Range(0, messageArray.Length)];
                textWriterSingle = TextWriter.AddWriter_Static(messageText, message, .05f, true, true);
            }
        };
    }


    //canvas = GameObject.Find("Canvas Rooms").GetComponent<Canvas>();
    //    StaminaBar = canvas.transform.Find("Stamina Bar/Stamina").GetComponent<Image>();

    void Start()
    {
        //TextWriter.AddWriter_Static(messageText, "123456789102341942549816", .1f, true);
    }

    void Update()
    {
        
    }
}