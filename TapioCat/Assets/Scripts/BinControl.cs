using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinControl : MonoBehaviour
{
    // TODO: make order deliverable

    /*****************
    Goes on all tea/flavor bin objects
    Technique here is that all objects are already on blender, but they get deactivated at Start
    When cooking needs to occur, appropriate tea object is activated.
    Moves tea from bin to blender.
    *****************/
    public GameObject teaCook;
    public AudioClip teaSound;
    //public AudioClip toppingSound;
    AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        teaCook.SetActive(false);
        _audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
            if (GamePlay.blender == "empty"){
                // put the tea in the blender
                teaCook.SetActive(true);
                _audioSource.PlayOneShot(teaSound);
                GamePlay.blender = "cooking";

                // keeping track of what tea is in there
                if (gameObject.CompareTag("1")){
                    GamePlay.blender_contents = 1;
                } else if (gameObject.CompareTag("2")){
                    GamePlay.blender_contents = 2;
                } else if (gameObject.CompareTag("3")){
                    GamePlay.blender_contents = 3;
                }
            }              
        }
    }
}
