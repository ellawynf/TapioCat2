using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookTea : MonoBehaviour
{
    /*************
    Goes on each TeaCook object at blending station
    *************/

    float cookTime;
    public int timeTilCooked = 6;
    public Animator animator;
    /*void Start() {
        cookTime = 0;    
    }*/
    //pour sounds
    public AudioClip dingSound;
    AudioSource _audioSource;

    void Start () {
		animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }
    private void OnEnable() {
        cookTime = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf){
            //print(cookTime);
            cookTime += Time.deltaTime;
            animator.SetBool("Blending", true);
            // blending sound
            if (cookTime > timeTilCooked){
                animator.SetBool("Blending", false);
                // ding sound?
                if(GamePlay.blender != "full"){
                    _audioSource.PlayOneShot(dingSound);
                }
                // TODO: add animations? add burning (add another range)?
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
