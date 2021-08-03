using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    AudioManager audioManager;
    private void Start()
    {
        audioManager = GameObject.FindObjectOfType<AudioManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "coin")
        {
            audioManager.PlayAudio("Coin");
            ScoreScript.scoreInstance.CoinIncrement();
            Destroy(other.gameObject);
        }
    }

}
