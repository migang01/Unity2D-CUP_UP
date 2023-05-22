using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SoundManager : MonoBehaviour
{
    public Text effectText;
    public Text musicText;
    public Image effectOffImage;
    public Image effectOnImage;
    public Image MusicOffImage;
    public Image MusicOnImage;
    public bool isEffectMuted;
    public bool isMusicMuted;
    public MusicManager musicManager;
    public bool intToBool(int val)
    {
        if (val != 0)
            return true;
        else
            return false;

    }

    public int boolToInt(bool val)
    {
        if (val)
            return 1;

        else
            return 0;
    }


    void Start()
    {
        // how to remember even when you quit game ? (q1)
        isEffectMuted = false;
        isMusicMuted = false;

        loadData();
        // (q1) answer **********************
        if (isMusicMuted == false)
        {
            musicManager.musicPlay();
            MusicOnImage.gameObject.SetActive(true);
            MusicOffImage.gameObject.SetActive(false);
            musicText.text = "MUSIC ON";
        }
        else if (isMusicMuted == true)
        {
            musicManager.musicStop();
            MusicOnImage.gameObject.SetActive(false);
            MusicOffImage.gameObject.SetActive(true);
            musicText.text = "MUSIC OFF";
        }

        if (isEffectMuted == false)
        {
            effectOnImage.gameObject.SetActive(true);
            effectOffImage.gameObject.SetActive(false);
            effectText.text = "EFFECT ON";
        }
        else if (isEffectMuted == true)
        {
            effectOnImage.gameObject.SetActive(false);
            effectOffImage.gameObject.SetActive(true);
            effectText.text = "EFFECT OFF";
        }

    }

    private void Update()
    {

        loadData();

       
        // (q1) answer **********************
    }


    public void effectOnOffBtn()
    {
        Audio.UISoundPlay();

        if (isEffectMuted == false)
        {
            // how to maintain even when scene is changed -> playerprefs            
            effectOnImage.gameObject.SetActive(false); 
            effectOffImage.gameObject.SetActive(true);
            effectText.text = "EFFECT ON";
            isEffectMuted = true;
        }

        else if (isEffectMuted == true)
        {
            effectOnImage.gameObject.SetActive(true);
            effectOffImage.gameObject.SetActive(false);
            effectText.text = "EFFECT OFF";
            isEffectMuted = false;
        }
        saveData();
    }

    public void musicOnOff()
    {
        Audio.UISoundPlay();

        if (isMusicMuted == false)
        {
            musicManager.musicStop();
            MusicOnImage.gameObject.SetActive(false);
            MusicOffImage.gameObject.SetActive(true);
            musicText.text = "MUSIC OFF";
            isMusicMuted = true;
            // music off
        }

        else if (isMusicMuted == true)
        {
            musicManager.musicPlay();
            MusicOnImage.gameObject.SetActive(true);
            MusicOffImage.gameObject.SetActive(false);
            musicText.text = "MUSIC ON";
            isMusicMuted = false;
            // music on
        }
        saveData();
    }

    void saveData()
    {
        PlayerPrefs.SetInt("Effect", boolToInt(isEffectMuted));

        PlayerPrefs.SetInt("Music", boolToInt(isMusicMuted));
    }

    void loadData()
    {
        // (q1) answer **********************
        isEffectMuted = intToBool(PlayerPrefs.GetInt("Effect", 0));
        isMusicMuted = intToBool(PlayerPrefs.GetInt("Music", 0));
        // (q1) answer **********************
    }
}
