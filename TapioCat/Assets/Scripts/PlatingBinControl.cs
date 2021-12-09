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
    public GameObject otherCup;

    private void Start() {
        thisCup.SetActive(false);
        otherCup.SetActive(false);
    }

    public void Cup(){
        if (GamePlay.plate1Cup == "none"){
            thisCup.SetActive(true);
            GamePlay.plate1Cup = "empty";

            if (gameObject.CompareTag("Ice")){
                GamePlay.plate1Temp = 0;
            } else if (gameObject.CompareTag("Hot")){
                GamePlay.plate1Temp = 1;
            }
        }
    }

    public void Plate(){
        if (GamePlay.plate1Cup == "full"){
            GamePlay.pickup = true;
            GamePlay.pickedDrink = ""+GamePlay.plate1Temp+GamePlay.plate1Tea+GamePlay.plate1Topping;
            print(GamePlay.pickedDrink);
            GamePlay.plate1Cup = "none";
            //TODO: reset all temp,tea,topping vars somewhere please
            thisCup.SetActive(false);
            otherCup.SetActive(false);
        }
    }

    /*void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
            if (GamePlay.plate1Cup == "none"){
                thisCup.SetActive(true);
                GamePlay.plate1Cup = "empty";
            }
            else if (GamePlay.plate1Topping != 0){
                GamePlay.pickup = true;
                GamePlay.pickedDrink = "0"+GamePlay.plate1Tea+GamePlay.plate1Topping;
                print(GamePlay.pickedDrink);
            }
        }
    }*/
}