using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerOrder : MonoBehaviour
{
    public GameObject[] temp;
    public GameObject[] teaTypes;
    public GameObject[] toppingTypes;
    public string drinkOrdered;
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
        
        int ice = Random.Range(0,1);
        int tea = Random.Range(1,3);
        int topping = Random.Range(1,3);
        temp[ice].SetActive(true);
        teaTypes[tea-1].SetActive(true);
        toppingTypes[topping-1].SetActive(true);
        drinkOrdered = ice.ToString()+tea.ToString()+topping.ToString();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
            print("hit player");
            if (GamePlay.pickup == true){ //if the player is "carrying something"
                if (GamePlay.pickedDrink == drinkOrdered){ //if it's the thing we want
                    _audioSource.PlayOneShot(coins);
                    GamePlay.totalScore++;
                    GamePlay.pickup = false;
                    GamePlay.pickedDrink = "None";
                    //other resets go here too, probably something with the serving area
                    gameObject.SetActive(false); //leave lmao
                }
            }
        }
    }
}
