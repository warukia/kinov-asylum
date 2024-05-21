using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDialogueAssistantChillmeister : MonoBehaviour
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
                       "CHILLMEISTER\nValid to eat fingers.",
                       "YULIYA\n?",
                       "CHILLMEISTER\nYaay pelleds",
                       "YULIYA\nWhat?",
                       "CHILLMEISTER\nMy dream is eat cocaine",
                       "CHILLMEISTER\nI cause salmonela",
                       "YULIYA\nPlease stop",
                       "CHILLMEISTER\nPee (lobotomy)",
                       "YULIYA\n...",
                       "YULIYA\nMaybe I should kill myself at this point.",
                       "CHILLMEISTER\napaluajize. Have you met by any chance my little friend?",
                       "YULIYA\nWho?",
                       "CHILLMEISTER\nSimon, my little worm friend, only seeks hugs and friendship.",
                       "CHILLMEISTER\nDo not mind his addiction to drugs, he is really lovely once you get to know him.",
                       "CHILLMEISTER\nPerhaps you should give him a chance.",
                       "YULIYA\nAre you talking about that disgusting worm?",
                       "YULIYA\nI don't think I'm gonna give him a chance.",
                       "CHILLMEISTER\nOkay fuck you *spits on you*",
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