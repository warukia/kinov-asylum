using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDialogueAssistantLady : MonoBehaviour
{
    private TextMeshProUGUI messageText;
    private TextWriter.TextWriterSingle textWriterSingle;
    private PlayerController playerController;

    private int messageInt;

    private void Awake()
    {
        messageText = transform.Find("message/messageText").GetComponent<TextMeshProUGUI>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
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
                       // Yuliya despertando desconcertada.
                       "LADY\nOh, finally someone!",
                       "LADY\nI won't be alone anymore!",
                       "LADY\nHarry, go get her.",
                };
                if (messageInt >= messageArray.Length)
                {
                    // End here the conversation.
                    messageInt = 0;
                    Destroy(gameObject);
                }

                string message = messageArray[messageInt];
                messageInt++;

                textWriterSingle = TextWriter.AddWriter_Static(messageText, message, .05f, true, true);
            }
        };
    }
}