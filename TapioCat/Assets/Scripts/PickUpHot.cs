using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpHot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
            if (GamePlay.plate1Topping != 0){
                    GamePlay.pickup = true;
                    GamePlay.pickedDrink = "1"+GamePlay.plate1Tea+GamePlay.plate1Topping;
                    print(GamePlay.pickedDrink);
            }
        }
    }
}
