using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        _transitionManager.LoadScene("ChooseLevels");
    }
    public void instructions(){
        _audioSource.PlayOneShot(buttonSound);
        _transitionManager.LoadScene("Instructions");
    }
    /*public void quit(){
        _audioSource.PlayOneShot(buttonSound);
        #if (UNITY_EDITOR)
            UnityEditor.EditorApplication.isPlaying = false;
        #elif (UNITY_STANDALONE)
            Application.Quit();
        #endif
    }*/
}
