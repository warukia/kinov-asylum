using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDialogueAssistantViktorWin : MonoBehaviour
{
    private TextMeshProUGUI messageText;
    private TextWriter.TextWriterSingle textWriterSingle;

    public GameObject victoryCanvas;
    public GameObject illustrationManager;
    
    public int messageInt;

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
                       // Yuliya despertando desconcertada.
                       "VIKTOR\nWait, WAIT! Put that down",
                       "VIKTOR\nThis drug isn't supposed to be tested on me!",
                       "VIKTOR\nDon't you dare!!!",
                       " ",
                       " ",
                       " ",
                       " ",
                };
                if (messageInt >= messageArray.Length)
                {
                    // End here the conversation.
                    messageInt = 0;
                    victoryCanvas.SetActive(true);
                    Destroy(illustrationManager);
                    Destroy(gameObject);
                }

                string message = messageArray[messageInt];
                messageInt++;

                textWriterSingle = TextWriter.AddWriter_Static(messageText, message, .05f, true, true);
            }
        };
    }
}