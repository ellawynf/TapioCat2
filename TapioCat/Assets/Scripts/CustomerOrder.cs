using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerOrder : MonoBehaviour
{
    public GameObject[] temp;
    public GameObject[] teaTypes;
    public GameObject[] toppingTypes;
    public GameObject customerSprite;
    int ice;
    int tea;
    int topping;
    public string drinkOrdered;
    public bool atCounter;
    public AudioClip coins;
    AudioSource _audioSource;

    private GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        //set up audio
        _audioSource = GetComponent<AudioSource>();
        player = GameObject.FindWithTag("Player");

        //set all cup variables to no
        //temp[0].SetActive(false);
        //temp[1].SetActive(false);
        foreach (GameObject temps in temp){
            temps.SetActive(false);
        }
        foreach (GameObject teas in teaTypes){
            teas.SetActive(false);
        }
        foreach (GameObject top in toppingTypes){
            top.SetActive(false);
        }
        //will want to move this out of start and into the code that checks for a new customer
        ice = (Random.Range(1,4)%2);
        tea = Random.Range(1,3);
        topping = Random.Range(1,3);
        //I do not know why we don't need these lines of code, but getting rid of them solves the sprite problem
        /*temp[ice].SetActive(true);
        teaTypes[tea-1].SetActive(true);
        toppingTypes[topping-1].SetActive(true);*/
        drinkOrdered = ice.ToString()+tea.ToString()+topping.ToString();
    }

    public void Deliver(){
        if (GamePlay.pickup == true){ //if the player is "carrying something"
            print("clicked");
            if (GamePlay.pickedDrink == drinkOrdered){ //if it's the thing we want
                print("delivering");
                _audioSource.PlayOneShot(coins);

                // resetting gameplay vars
                GamePlay.totalScore++;
                GamePlay.pickup = false;
                GamePlay.pickedDrink = "None";

                // deactivating and destroying player objects
                // child is each cup object
                foreach (Transform child in player.transform){
                    if (child.gameObject.CompareTag("Ice") || child.gameObject.CompareTag("Hot")){      // making sure we don't try this on the spawn point objects
                        if (child.gameObject.activeSelf){           // only do this to the active cup
                            while (child.childCount > 0){           // destroying each child of the active cup
                                DestroyImmediate(child.GetChild(0).gameObject);
                            }
                            child.gameObject.SetActive(false);      // setting the active cup to inactive
                        }
                    }
                }

                // resetting customer vars
                atCounter = false;
                temp[ice].SetActive(false);
                teaTypes[tea-1].SetActive(false);
                toppingTypes[topping-1].SetActive(false);
                drinkOrdered = "None";
                customerSprite.SetActive(false);
                atCounter = false;
                print("delivered, CQ: ");
                print(GamePlay.customerQueue);
                // yeah, also gotta set the sprites to destroy, we can figure that out later
                //other resets go here too, probably something with the serving area
            }
        } 
    }

    /*void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
            print("hit player");
            if (GamePlay.pickup == true){ //if the player is "carrying something"
                if (GamePlay.pickedDrink == drinkOrdered){ //if it's the thing we want
                    _audioSource.PlayOneShot(coins);
                    GamePlay.totalScore++;
                    GamePlay.pickup = false;
                    GamePlay.pickedDrink = "None";
                    atCounter = false;
                    temp[ice].SetActive(false);
                    teaTypes[tea-1].SetActive(false);
                    toppingTypes[topping-1].SetActive(false);
                    drinkOrdered = "";
                    customerSprite.SetActive(false);
                    //other resets go here too, probably something with the serving area
                }
            }
        }
    }*/


    void Update(){
        //check if there's an "empty" space and if there's a customer in the queue
        //if yes then set to active
        if (atCounter == false && GamePlay.customerQueue > 0){
            GamePlay.customerQueue--;
            atCounter = true;
            customerSprite.SetActive(true);
            ice = (Random.Range(1,4)%2);
            tea = Random.Range(1,3);
            topping = Random.Range(1,3);
            temp[ice].SetActive(true);
            teaTypes[tea-1].SetActive(true);
            toppingTypes[topping-1].SetActive(true);
            drinkOrdered = ice.ToString()+tea.ToString()+topping.ToString();
            print("new cust, CQ: ");
            print(GamePlay.customerQueue);
        }
    }
}
