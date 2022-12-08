using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    [SerializeField]
    private GameObject subtitleBox;
    public AudioSource AS;
    public AudioClip[] audioFiles;
    //used to save the subtitle Texts
    public string[] dialogueTexts;

    // Update is called once per frame
    void Update()
    {
        if (AS.isPlaying)
        {
            subtitleBox.SetActive(true);
            subtitleBox.GetComponent<Text>().text = "";
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
                subtitleBox.GetComponent<Text>().text = dialogueTexts[2];
                return;
            }
            if (AS.time >= 8.0f)
            {
                subtitleBox.GetComponent<Text>().text = dialogueTexts[1];
                return;
            }
            if (AS.time >= 2.0f)
            {
                subtitleBox.GetComponent<Text>().text = dialogueTexts[0];
                return;
            }
        }
    }
}
