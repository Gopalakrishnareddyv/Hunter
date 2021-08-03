using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    public Slider volumeSlider;
   
    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        print(PlayerPrefManager.GetMasterVolume());
      
        volumeSlider.value = PlayerPrefManager.GetMasterVolume();
   
        audioManager = GameObject.FindObjectOfType<AudioManager>();
    }

    private void Update()
    {
        audioManager.SetVolume("Background", volumeSlider.value);
    }

    public void SaveAndExit()
    {
        PlayerPrefManager.SetMasterVolume(volumeSlider.value);
     }
    public void SetDefaults()
    {
        volumeSlider.value = 0.5f;
       
    }
}
