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

    //public GameObject thisCup;
    //public GameObject otherCup;

    public GameObject iceCup;
    public GameObject hotCup;

    public Transform playerIceCup;
    public Transform playerHotCup;
    public Transform teaPickupSP;
    public Transform toppingPickupSP;

    //private Transform [] spawnPoints;

    private void Start() {
        iceCup.SetActive(false);
        hotCup.SetActive(false);

        /*spawnPoints[0] = teaPickupSP;
        spawnPoints[1] = toppingPickupSP;*/
    }

    public void Cup(){
        if (GamePlay.plate1Cup == "none"){

            if (gameObject.CompareTag("Ice")){
                GamePlay.plate1Temp = 0;
                iceCup.SetActive(true);

            } else if (gameObject.CompareTag("Hot")){
                GamePlay.plate1Temp = 1;
                hotCup.SetActive(true);
            }

            GamePlay.plate1Cup = "empty";
        }
    }

    public void Plate(){
        // TODO: NULL REF EXCEPTION
        Transform [] spawnPoints = {null, null, null};
        spawnPoints[1] = teaPickupSP;
        spawnPoints[2] = toppingPickupSP;

        if (GamePlay.plate1Cup == "full"){
            // setting pickup vars
            GamePlay.pickup = true;
            GamePlay.pickedDrink = ""+GamePlay.plate1Temp+GamePlay.plate1Tea+GamePlay.plate1Topping;
            print(GamePlay.pickedDrink);

            // moving picked up object
            if (GamePlay.plate1Temp == 0){      // cold
                // first move children
                int ord = 6;
                Transform [] t = iceCup.GetComponentsInChildren<Transform>();
                for (int i=1; i < t.Length; i++){
                    // set parent to player heirarchy
                    t[i].SetParent(playerIceCup);

                    // move object to player's cup; assume tea is first in heirarchy
                    t[i].position = spawnPoints[i].position;

                    // fix sorting order
                    SpriteRenderer spr = t[i].gameObject.GetComponent<SpriteRenderer>();
                    spr.sortingOrder = ord;
                    ord++;
                }
                iceCup.SetActive(false);
                playerIceCup.gameObject.SetActive(true);
                // then deactivate

                
            } else if (GamePlay.plate1Temp == 1){       // hot
                // first move children
                int ord = 6;
                Transform [] t = hotCup.GetComponentsInChildren<Transform>();
                for (int i=1; i < t.Length; i++){
                    // set parent to player heirarchy
                    t[i].SetParent(playerHotCup);

                    // move object to player's cup; assume tea is first in heirarchy
                    t[i].position = spawnPoints[i].position;

                    // fix sorting order
                    SpriteRenderer spr = t[i].gameObject.GetComponent<SpriteRenderer>();
                    spr.sortingOrder = ord;
                    ord++;
                }
                hotCup.SetActive(false);
                playerHotCup.gameObject.SetActive(true);
            }

            // resetting plating vars
            GamePlay.plate1Cup = "none";
            //TODO: reset all temp,tea,topping vars somewhere please
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