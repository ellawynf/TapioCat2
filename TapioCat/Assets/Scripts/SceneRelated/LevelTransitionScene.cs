using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTransitionScene : MonoBehaviour
{
    TransitionManager _transitionManager;
    public AudioClip returnSound;
    AudioSource _audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        _transitionManager = FindObjectOfType<TransitionManager>();
        _audioSource = GetComponent<AudioSource>();
    }
    public void ReturnToMainMenu(){
        _audioSource.PlayOneShot(returnSound);
        _transitionManager.LoadScene("MainMenu");
    }

    public void NextLevel(){
        _audioSource.PlayOneShot(returnSound);
        _transitionManager.LoadScene("Level"+SceneRelatedGlobal.levelToLoad.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
