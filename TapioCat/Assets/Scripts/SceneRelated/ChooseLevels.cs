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
        SceneRelatedGlobal.levelToLoad = 1; //Level to load is just level loaded now
    }
    public void Level2(){
        _audioSource.PlayOneShot(returnSound);
        _transitionManager.LoadScene("Level2");
        SceneRelatedGlobal.levelToLoad = 2;
    }

    public void Level3(){
        _audioSource.PlayOneShot(returnSound);
        _transitionManager.LoadScene("Level3");
        SceneRelatedGlobal.levelToLoad = 3;
    }

    public void Level4(){
        _audioSource.PlayOneShot(returnSound);
        _transitionManager.LoadScene("Level4");
        SceneRelatedGlobal.levelToLoad = 4;
    }

    public void Level5(){
        _audioSource.PlayOneShot(returnSound);
        _transitionManager.LoadScene("Level5");
        SceneRelatedGlobal.levelToLoad = 5;
    }

}
