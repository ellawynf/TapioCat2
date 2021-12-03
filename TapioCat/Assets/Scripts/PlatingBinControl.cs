using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatingBinControl : MonoBehaviour
{
    // TODO: make order deliverable
    // TODO: make cups dispense

    /*****************
    Goes on all ice/hot bin objects
    Eventually deliver the order to customer
    *****************/

    public GameObject thisCup;

    private void Start() {
        thisCup.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
            if (gameObject.CompareTag("Ice")){
                if (GamePlay.plate1Cup == "none"){
                    thisCup.SetActive(true);
                    GamePlay.plate1Cup = "empty";
                }
                else if (GamePlay.plate1Topping != 0){
                    GamePlay.pickup = true;
                    GamePlay.pickedDrink = "0"+GamePlay.plate1Tea+GamePlay.plate1Topping;
                    print(GamePlay.pickedDrink);
                }
            } else if (gameObject.CompareTag("Hot")){
                if (GamePlay.plate2Cup == "none"){
                    thisCup.SetActive(true);
                    GamePlay.plate2Cup = "empty";
                }
                else if (GamePlay.plate2Topping != 0){
                    GamePlay.pickup = true;
                    GamePlay.pickedDrink = "1"+GamePlay.plate1Tea+GamePlay.plate1Topping;
                    print(GamePlay.pickedDrink);
                }
            }
        }
    }
}