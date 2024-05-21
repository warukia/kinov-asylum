using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDialogueAssistantViktorEncounter : MonoBehaviour
{
    private TextMeshProUGUI messageText;
    private TextWriter.TextWriterSingle textWriterSingle;
    private PlayerController playerController;
    
    public int messageInt;

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
                       "YULIYA\nViktor!",
                       "VIKTOR\nOh, hi Yuliya.",
                       "YULIYA\nWhat did you do? I've been having some weird hallucinations since I woke up.",
                       "YULIYA\nYou didn't drug me, did you?",
                       "VIKTOR\nI did, I needed to do some tests, so I used you. Now if you excuse me.",
                       "YULIYA\nWhat? HEY!!",
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