using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookTea : MonoBehaviour
{
    /*************
    Goes on each TeaCook object at blending station
    *************/

    private float cookTime;
    public int timeTilCooked = 6;

    void Start() {
        cookTime = 0;    
    }
    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf){
            cookTime += Time.deltaTime;
            if (cookTime > timeTilCooked){
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
                }
            }           
        } else {
            cookTime = 0;
        }
    }
}
