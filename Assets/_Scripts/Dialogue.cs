using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField]
    private GameObject subtitleBox;
    public AudioSource AS;
    public AudioClip[] audioFiles;
    //used to save the subtitle Texts
    public string[] dialogueTexts;
    public TextMeshProUGUI DialogueBox;

    // Update is called once per frame
    void Update()
    {
        if (AS.isPlaying)
        {
            subtitleBox.SetActive(true);
            DialogueBox.text = "";
            Diologue1();
        }
        else
        {
            subtitleBox.SetActive(false);
        }
 
    }

    private void Diologue1()
    {
        if ("dialogueone" == AS.clip.name)
        {
            if (AS.time >= 12.0f)
            {
                DialogueBox.text = dialogueTexts[2];
                //subtitleBox.GetComponent<Text>().text = dialogueTexts[2];
                return;
            }
            if (AS.time >= 8.0f)
            {
                DialogueBox.text = dialogueTexts[1];
                return;
            }
            if (AS.time >= 2.0f)
            {
                DialogueBox.text = dialogueTexts[0];
                return;
            }
        }
    }
}
