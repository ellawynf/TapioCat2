using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailScene : MonoBehaviour
{
    TransitionManager _transitionManager;
    public AudioClip returnSound;
    AudioSource _audioSource;

    private void Start(){
        _transitionManager = FindObjectOfType<TransitionManager>();
        _audioSource = GetComponent<AudioSource>();
        SceneRelatedGlobal.servedCustomerNum = 0;
		SceneRelatedGlobal.angryCustomerNum = 0;
    }
    public void ReturnToMainMenu(){
        _audioSource.PlayOneShot(returnSound);
        _transitionManager.LoadScene("MainMenu");
    }

    public void GoBack(){
        _audioSource.PlayOneShot(returnSound);
        _transitionManager.LoadScene("ChooseLevels");
    }

    /*public void Quit1(){
        _audioSource.PlayOneShot(returnSound);
        Application.Quit();
    }*/
}
