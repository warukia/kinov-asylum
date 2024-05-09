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

    private int messageInt;

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


                string[] messageArray = DialogueScriptManager("LadyStart");

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



    public string[] DialogueScriptManager(string scriptName)
    {
        string[] messageArray;

        if (scriptName == "LadyStart")
        {
            messageArray = new string[]
            {
                "LADY\nOh, finally someone!",
                "LADY\nHarry, go get her.",
                "LADY\nShe will be the new skibidy toilet rizz.",
                "LADY\nSigma bananin chamba skibidi pomni chamba.",
            };
        }
        else if (scriptName == "LadyGameOver")
        {
            messageArray = new string[]
               {
                // Lady mordiendo a Yuliya
                "LADY\nI won't be alone anymore.",
                "LADY\nDon't worry, I'll take care of you, in your new form."
               };
        }
        else if (scriptName == "LadyVictory")
        {
            messageArray = new string[]
            {
                // Lady llorando
                "LADY\nWhy?",
                "LADY\nWhy would you want to go with Viktor when he did this to me.",
            };
        }
        else
        {
            messageArray = null;
        }

        return messageArray;
    }
}