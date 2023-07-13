using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public Image soundImage;
    public Image musicImage;
    public Sprite soundOnSprite;
    public Sprite soundOffSprite;
    public Sprite musicOnSprite;
    public Sprite musicOffSprite;

    private bool soundOn = true;
    private bool musicOn = true;

    public AudioSource[] musicSources;

    private void Start()
    {
        if (PlayerPrefs.HasKey("SoundOn"))
        {
            soundOn = PlayerPrefs.GetInt("SoundOn") == 1;
        }

        if (PlayerPrefs.HasKey("MusicOn"))
        {
            musicOn = PlayerPrefs.GetInt("MusicOn") == 1;
        }

        UpdateSoundImage();
        UpdateMusicImage();
        UpdateMusic();
    }

    public void ToggleSound()
    {
        soundOn = !soundOn;
        PlayerPrefs.SetInt("SoundOn", soundOn ? 1 : 0);
        UpdateSoundImage();

        if (soundOn)
        {
            AudioListener.volume = 1f;
        }
        else
        {
            AudioListener.volume = 0f;
        }
    }

    public void ToggleMusic()
    {
        musicOn = !musicOn;
        PlayerPrefs.SetInt("MusicOn", musicOn ? 1 : 0);
        UpdateMusicImage();
        UpdateMusic();
    }

    private void UpdateSoundImage()
    {
        if (soundOn)
        {
            soundImage.sprite = soundOnSprite;
        }
        else
        {
            soundImage.sprite = soundOffSprite;
        }
    }

    private void UpdateMusicImage()
    {
        if (musicOn)
        {
            musicImage.sprite = musicOnSprite;
        }
        else
        {
            musicImage.sprite = musicOffSprite;
        }
    }

    private void UpdateMusic()
    {
        foreach (var musicSource in musicSources)
        {
            musicSource.enabled = musicOn;
        }
    }
}