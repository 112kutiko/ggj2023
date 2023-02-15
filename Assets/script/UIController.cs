using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private AudioSource[]  audioSource;
    public Sprite mute, unmute;
    public GameObject ButtonOfAudio;
    // Start is called before the first frame update
    void Start()
    {
       

        audioSource = FindObjectsOfType<AudioSource>();
        updateAudioImage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Quit() { Application.Quit(); Debug.LogError("Application.Quit()"); }


    public void AudioOnOff()
    {
        for(int i=0;i<audioSource.Length;i++)
        {
            audioSource[i].mute = !audioSource[i].mute;
        }
        updateAudioImage();
    }
    private void updateAudioImage()
    {
        if(audioSource[0].mute==true) { ButtonOfAudio.GetComponent<Image>().sprite = mute; }
        else { ButtonOfAudio.GetComponent<Image>().sprite = unmute; }
    }

}
