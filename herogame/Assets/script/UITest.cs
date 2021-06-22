using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class UITest : MonoBehaviour
{
    public Button pauseBtn;
    public Slider masterVolueSlider;
    public AudioMixer masterMixer;
    bool isPause = false;
    // Start is called before the first frame update
    void Start()
    {
        pauseBtn.onClick.AddListener(PauseGame);
        masterVolueSlider.onValueChanged.AddListener(VolumeChange);
    }
    public void VolumeChange(float volume)
    {
        masterMixer.SetFloat("masterVolume",volume);
    }
    public void PauseGame()
    {
        isPause = !isPause;
        if(isPause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
