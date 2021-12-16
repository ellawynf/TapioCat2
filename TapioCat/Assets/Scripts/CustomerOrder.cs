using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerOrder : MonoBehaviour
{
    //lists of objects needed to become invisible
    public GameObject[] temp;
    public GameObject[] teaTypes;
    public GameObject[] toppingTypes;
    public GameObject[] customerTypes;
    public GameObject customerSprite;
    //integers that can be changed to the number of toppings etc in each level
    public int numTea = 3;
    public int numTop = 3;
    int ice;
    int tea;
    int topping;
    int cust;
    public string drinkOrdered;
    public bool atCounter;
    //timer variables
    float timeWaited;
    public int leavingTime = 50;
    public GameObject timer;
    //audio
    public AudioClip doorbell;
    public AudioClip coins;
    public AudioClip angrySound;
    public AudioClip leaveSound;
    AudioSource _audioSource;
    private GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        //set up audio
        _audioSource = GetComponent<AudioSource>();
        player = GameObject.FindWithTag("Player");

        //setup timer
        timer.SetActive(false);

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
        foreach (GameObject customer in customerTypes){
            customer.SetActive(false);
        }
        //will want to move this out of start and into the code that checks for a new customer
        ice = (Random.Range(1,4)%2);
        tea = Random.Range(1,numTea);
        topping = Random.Range(1,numTop);
        cust = Random.Range(1,5);
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
                customerTypes[cust-1].SetActive(false);
                drinkOrdered = "None";
                customerSprite.SetActive(false);
                atCounter = false;
                timeWaited = 0;
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
            tea = Random.Range(1,numTea);
            topping = Random.Range(1,numTop);
            cust = Random.Range(1,5);
            temp[ice].SetActive(true);
            teaTypes[tea-1].SetActive(true);
            toppingTypes[topping-1].SetActive(true);
            customerTypes[cust-1].SetActive(true);
            drinkOrdered = ice.ToString()+tea.ToString()+topping.ToString();
            _audioSource.PlayOneShot(doorbell);
            print("new cust, CQ: ");
            print(GamePlay.customerQueue);
        }
        if (atCounter == true){
            timeWaited += Time.deltaTime;
            if ((int) timeWaited == (leavingTime / 3)){       // 1/3 of the way done, deactivating first block
                Transform this_seg = timer.transform.GetChild(0);
                this_seg.gameObject.SetActive(false);
            }
            if ((int) timeWaited == (leavingTime / 1.5f)){     // 2/3 of the way done, deactivating second block
                Transform this_seg = timer.transform.GetChild(1);
                this_seg.gameObject.SetActive(false);  
                _audioSource.PlayOneShot(angrySound);              
            }
            if ((int) timeWaited == leavingTime){
                Transform this_seg = timer.transform.GetChild(2);       // 3/3 of the way done, deactivating 3rd block
                this_seg.gameObject.SetActive(false);
                _audioSource.PlayOneShot(leaveSound);
                //copy and pasted from deliver, only difference is no additional points and no happy coin sound
                atCounter = false;
                temp[ice].SetActive(false);
                teaTypes[tea-1].SetActive(false);
                toppingTypes[topping-1].SetActive(false);
                customerTypes[cust-1].SetActive(false);
                drinkOrdered = "None";
                customerSprite.SetActive(false);
                atCounter = false;
                timeWaited = 0;
            }
        }
    }
}
