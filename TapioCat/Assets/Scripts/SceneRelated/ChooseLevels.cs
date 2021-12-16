using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseLevels : MonoBehaviour
{
    TransitionManager _transitionManager;
    public AudioClip returnSound;
    AudioSource _audioSource;

    private void Start(){
        _transitionManager = FindObjectOfType<TransitionManager>();
        _audioSource = GetComponent<AudioSource>();
    }
    public void ReturnToMainMenu(){
        _audioSource.PlayOneShot(returnSound);
        _transitionManager.LoadScene("MainMenu");
    }
    public void Level1(){
        _audioSource.PlayOneShot(returnSound);
        _transitionManager.LoadScene("Level1");
    }
    public void Level2(){
        _audioSource.PlayOneShot(returnSound);
        _transitionManager.LoadScene("Level2");
    }

    public void Level3(){
        _audioSource.PlayOneShot(returnSound);
        _transitionManager.LoadScene("Level3");
    }

    public void Level4(){
        _audioSource.PlayOneShot(returnSound);
        _transitionManager.LoadScene("Level4");
    }

    public void Level5(){
        _audioSource.PlayOneShot(returnSound);
        _transitionManager.LoadScene("Level5");
    }

}
