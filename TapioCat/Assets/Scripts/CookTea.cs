using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookTea : MonoBehaviour
{
    /*************
    Goes on each TeaCook object at blending station
    *************/

    public GameObject timer;

    float cookTime;
    public int timeTilCooked = 6;
    public Animator animator;
    public Animator blenderTimer;
    /*void Start() {
        cookTime = 0;    
    }*/
    //pour sounds
    public AudioClip dingSound;
    AudioSource _audioSource;

    void Start () {
		animator = GetComponent<Animator>();
        blenderTimer = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }
    private void OnEnable() {
        cookTime = 0;
        timer.SetActive(true);
        foreach (Transform child in timer.transform){
            child.gameObject.SetActive(true);
        }
        animator.SetBool("Blending", true);
        blenderTimer.SetBool("Blending", true);
    }
    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf){
            print(cookTime);
            cookTime += Time.deltaTime;

            //Because of the automatic animation, this_seg it no long needed
            //Only needs to deactivate timer once cook is done.
            if ((int) cookTime == timeTilCooked){
                //Transform this_seg = timer.transform.GetChild(2);       // done, deactivating
                //this_seg.gameObject.SetActive(false);
                timer.SetActive(false);
                animator.SetBool("Blending", false);
                
                // ding sound?
                //if(GamePlay.blender != "full"){
                _audioSource.PlayOneShot(dingSound);
                    // do we wanna animate the timer first or should it just stay there empty? or should it leave idk?
                //}
                // TODO: add burning (add another range)?
                if (gameObject.CompareTag("1")){
                    print("tea1 cooked");
                    GamePlay.blender = "full";
                } else if (gameObject.CompareTag("2")){
                    print("tea2 cooked");
                    GamePlay.blender = "full";
                } else if (gameObject.CompareTag("3")){
                    print("tea3 cooked");
                    GamePlay.blender = "full";
                } else if (gameObject.CompareTag("4")){
                    print("tea4 cooked");
                    GamePlay.blender = "full";
                }else if (gameObject.CompareTag("5")){
                    print("tea5 cooked");
                    GamePlay.blender = "full";
                }
            }           
        }
    }
}
