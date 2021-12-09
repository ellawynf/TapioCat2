using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerOrder : MonoBehaviour
{
    public GameObject[] temp;
    public GameObject[] teaTypes;
    public GameObject[] toppingTypes;
    public GameObject customerSprite;
    public int customerQueue;
    int ice;
    int tea;
    int topping;
    public string drinkOrdered;
    public bool atCounter;
    public AudioClip coins;
    AudioSource _audioSource;


    // Start is called before the first frame update
    void Start()
    {
        //set up audio
        _audioSource = GetComponent<AudioSource>();

        //set all cup variables to no
        foreach (GameObject temps in temp){
            temps.SetActive(false);
        }
        //temp[0].SetActive(false);
        //temp[1].SetActive(false);
        foreach (GameObject teas in teaTypes){
            teas.SetActive(false);
        }
        foreach (GameObject top in toppingTypes){
            top.SetActive(false);
        }
        customerQueue = 0;
        //will want to move this out of start and into the code that checks for a new customer
        ice = (Random.Range(1,4)%2);
        tea = Random.Range(1,3);
        topping = Random.Range(1,3);
        temp[ice].SetActive(true);
        teaTypes[tea-1].SetActive(true);
        toppingTypes[topping-1].SetActive(true);
        drinkOrdered = ice.ToString()+tea.ToString()+topping.ToString();
    }

    public void Deliver(){
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
        if (atCounter == false && customerQueue > 0){//GamePlay.customerQueue > 0){
            atCounter = true;
            customerSprite.SetActive(true);
            ice = (Random.Range(1,4)%2);
            tea = Random.Range(1,3);
            topping = Random.Range(1,3);
            temp[ice].SetActive(true);
            teaTypes[tea-1].SetActive(true);
            toppingTypes[topping-1].SetActive(true);
            drinkOrdered = ice.ToString()+tea.ToString()+topping.ToString();
        }
    }
}
