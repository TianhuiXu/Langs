using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTING : MonoBehaviour
{
    SpeechSystem dialogue;
    // Start is called before the first frame update
    void Start()
    {
        dialogue = SpeechSystem.instance;
    }

    public string[] s = new string[]
    {
        "Hello:Vendor",
        "Hello:User",
        "What do you want to buy？:Vendor"
    };

    int index = 0;
    // Update is called once per frame
    void Update()
    {
        // iterate through array of dialogue when pressing space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!dialogue.isSpeaking || dialogue.isWaitingForUserInput)
            {
                if (index >= s.Length)
                {
                    return;
                }
                Say(s[index]);
                index++;
            }
        }
    }

    void Say(string s)
    {
        string[] parts = s.Split(':');
        string speech = parts[0];
        string speaker = (parts.Length >= 2) ? parts[1] : "";

        dialogue.Say(speech, speaker);
    }
}
