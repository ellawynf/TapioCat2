using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookTopping : MonoBehaviour
{
    private float cookTime = 0;
    public int timeTilCooked = 6;

    // Update is called once per frame
    void Update()
    {
        cookTime += Time.deltaTime;
        if (cookTime > timeTilCooked){
            // TODO: add animations? add burning (add another range)?
            if (gameObject.CompareTag("1")){
                print("topping1 cooked");
                GamePlay.topping1Cook = "full";
            } else if (gameObject.CompareTag("2")){
                print("topping2 cooked");
                GamePlay.topping2Cook = "full";
            } else if (gameObject.CompareTag("3")){
                print("topping3 cooked");
                GamePlay.topping3Cook = "full";
            }
        }
    }
}
