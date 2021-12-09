using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToppingBinControl : MonoBehaviour
{
    /*************
    Goes on all topping bin objects
    Move topping to plating station
    *************/

    public GameObject toppingPlating;
    
    public Transform toppingPlateSP;

    public GameObject iceParentCup;
    public GameObject hotParentCup;

    //public Transform hotToppingSP;

    // try to get this to work generically
    public bool PlaceTopping(){
        // topping must go on after tea for now
        if (GamePlay.plate1Cup == "tea"){
            // determine which cup to instantiate as parent
            if (iceParentCup.activeSelf){
                Instantiate(toppingPlating, toppingPlateSP.position, toppingPlating.transform.rotation, iceParentCup.transform);
            } else if (hotParentCup.activeSelf){
                Instantiate(toppingPlating, toppingPlateSP.position, toppingPlating.transform.rotation, hotParentCup.transform);
            }
            GamePlay.plate1Cup = "full";
            return true;
        } else {
            return false;
        }
    }

    public void Boba(){
        // topping must go on after tea for now
        if (PlaceTopping()){
            GamePlay.plate1Topping = 1;
        }
    }

    public void Jelly(){
        if (PlaceTopping()){
            GamePlay.plate1Topping = 2;
        }
    }

    public void Pudding(){
        if (PlaceTopping()){
            GamePlay.plate1Topping = 3;
        }
    }

    /*void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
            if (GamePlay.plate1Cup == "tea"){       // ice cup; topping must go on after tea for now
                Instantiate(toppingPlating, iceToppingSP.position, toppingPlating.transform.rotation); 
                GamePlay.plate1Cup = "full";
                if (gameObject.CompareTag("1")){
                    GamePlay.plate1Topping = 1;
                } else if (gameObject.CompareTag("2")){
                    GamePlay.plate1Topping = 2;
                } else if (gameObject.CompareTag("3")){
                    GamePlay.plate1Topping = 3;
                }
            }
        }        
    }*/
}
