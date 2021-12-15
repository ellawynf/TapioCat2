using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBin : MonoBehaviour
{
    /******************
    Goes on trash bin object, Trash function gets assigned to TrashButton in Canvas
    Clears drink that player is carrying OR current drink on plate
    ******************/

    private GameObject player;
    public GameObject hotCup;
    public GameObject iceCup;

    //trash sounds
    public AudioClip trashSound;
    AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        _audioSource = GetComponent<AudioSource>();
    }

    // trashes EITHER the drink in the player's hand OR the drink on the plate
    public void Trash(){
        // if player is carrying a drink
        if (GamePlay.pickup){
            // deactivate cup and Destroy toppings
                // deactivating and destroying player objects
                // child is each cup object (ice and hot)
                foreach (Transform child in player.transform){
                    if (child.gameObject.CompareTag("Ice") || child.gameObject.CompareTag("Hot")){      // making sure we don't try this on the spawn point objects
                        if (child.gameObject.activeSelf){           // only do this to the active cup
                            while (child.childCount > 0){           // destroying each child of the active cup
                                DestroyImmediate(child.GetChild(0).gameObject);
                            }
                            child.gameObject.SetActive(false);      // setting the active cup to inactive
                            _audioSource.PlayOneShot(trashSound);
                        }
                    }
                }
            // clear GamePlay vars
            GamePlay.pickup = false;
            GamePlay.pickedDrink = "None";            
        } 
        
        // or if there is something on the plate
        else if (GamePlay.plate1Cup != "none"){

            if (GamePlay.plate1Temp == 0){      // cold
                // destroying the children of the cup (tea, topping)
                while (iceCup.transform.childCount > 0){
                    DestroyImmediate(iceCup.transform.GetChild(0).gameObject);
                }
                // deactivating the cup
                iceCup.SetActive(false);
                _audioSource.PlayOneShot(trashSound);

            } else if (GamePlay.plate1Temp == 1){       // hot
                // destroying the children of the cup (tea, topping)
                while (hotCup.transform.childCount > 0){
                    DestroyImmediate(hotCup.transform.GetChild(0).gameObject);
                }
                // deactivating the cup
                hotCup.SetActive(false);
                _audioSource.PlayOneShot(trashSound);
            }

            // clear GamePlay vars
            GamePlay.plate1Cup = "none";
            GamePlay.plate1Tea = 0;
            GamePlay.plate1Topping = 0;
        }
    }
}
