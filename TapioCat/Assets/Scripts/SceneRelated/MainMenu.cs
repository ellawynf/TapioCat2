using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioClip startSound;
    public AudioClip buttonSound;
    AudioSource _audioSource;
    TransitionManager _transitionManager;
    private void Start(){
        _transitionManager = FindObjectOfType<TransitionManager>();
        _audioSource = GetComponent<AudioSource>();
    }
    public void play(){
        _audioSource.PlayOneShot(startSound);
        _transitionManager.LoadScene("Level1");
    }
    public void instructions(){
        _audioSource.PlayOneShot(buttonSound);
        _transitionManager.LoadScene("Instructions");
    }
    public void quit(){
        _audioSource.PlayOneShot(buttonSound);
        Application.Quit();
    }
}
