using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToppingBinControl : MonoBehaviour
{
    /*************
    Goes on all topping bin objects
    Move topping to plating station
    *************/

    public GameObject timer;

    public GameObject fullbin;
    public GameObject halfbin;
    public GameObject lowbin;
    public GameObject emptybin;
    private bool cooking = false;

    public GameObject toppingPlating;
    
    public Transform toppingPlateSP;

    public GameObject iceParentCup;
    public GameObject hotParentCup;

    //sounds
    public AudioClip toppingSound;
    AudioSource _audioSource;

    private int quantity = 12;

    public Animator topAnim;
    //public Transform hotToppingSP;
    void Start(){
        _audioSource = GetComponent<AudioSource>();
        timer.SetActive(false);

        halfbin.SetActive(false);
        lowbin.SetActive(false);
        emptybin.SetActive(false);

    }

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
            _audioSource.PlayOneShot(toppingSound);
            Deplete();
            return true;
        } else {
            return false;
        }
    }

    private void Deplete(){
        quantity -= 2;          // 2 is the amount that is used each time, can increase or decrease to make toppings run out faster/slower respectively
        if (quantity == 8){
            // change to sprite 2
            fullbin.SetActive(false);
            halfbin.SetActive(true);
        } else if (quantity == 4){
            // change to sprite 3
            halfbin.SetActive(false);
            lowbin.SetActive(true);
        } else if (quantity == 0){
            // change to sprite 4
            lowbin.SetActive(false);
            emptybin.SetActive(true);
        }
    }

    IEnumerator CookMore(){
        float duration = 6f; // 6 seconds 
        float normalizedTime = 0;
        while (normalizedTime <= duration){
            normalizedTime += Time.deltaTime;

            topAnim.SetBool("Blending", true);
            /*if ((int)normalizedTime == duration / 3){
                
                timer.transform.GetChild(0).gameObject.SetActive(false);

            } else if ((int)normalizedTime == duration / 1.5f){
                timer.transform.GetChild(1).gameObject.SetActive(false);

            }*/
            yield return null;
        }
        // when equal to duration
        topAnim.SetBool("Blending", false);
        //timer.transform.GetChild(2).gameObject.SetActive(false);
        //reactivate full sprite
        emptybin.SetActive(false);
        fullbin.SetActive(true);
        //deactivate timer
        
        timer.SetActive(false);
        // reset quantity
        quantity = 12;
        cooking = false;
    }

    public void Boba(){
        // topping must go on after tea for now
        if (quantity > 0){
            if (PlaceTopping()){
                GamePlay.plate1Topping = 1;
            }            
        } else if (!cooking){
            cooking = true;
            // replenish; set timer and children to active
            timer.SetActive(true);
            /*foreach (Transform child in timer.transform){
                child.gameObject.SetActive(true);
            }*/
            StartCoroutine(CookMore());
        }

    }

    public void Jelly(){
        if (quantity > 0){
            if (PlaceTopping()){
                GamePlay.plate1Topping = 2;
            }            
        } else if (!cooking){
            cooking = true;
            // replenish; set timer and children to active
            timer.SetActive(true);
            /*foreach (Transform child in timer.transform){
                child.gameObject.SetActive(true);
            }*/
            StartCoroutine(CookMore());
        }
    }

    public void Pudding(){
        if (quantity > 0){
            if (PlaceTopping()){
                GamePlay.plate1Topping = 3;
            }            
        } else if (!cooking){
            cooking = true;
            // replenish; set timer and children to active
            timer.SetActive(true);
            /*foreach (Transform child in timer.transform){
                child.gameObject.SetActive(true);
            }*/
            StartCoroutine(CookMore());
        }
    }

    public void Bean(){
        if (quantity > 0){
            if (PlaceTopping()){
                GamePlay.plate1Topping = 4;
            }            
        } else if (!cooking){
            cooking = true;
            // replenish; set timer and children to active
            timer.SetActive(true);
            /*foreach (Transform child in timer.transform){
                child.gameObject.SetActive(true);
            }*/
            StartCoroutine(CookMore());
        }
    }

    public void Popping(){
        if (quantity > 0){
            if (PlaceTopping()){
                GamePlay.plate1Topping = 5;
            }            
        } else if (!cooking){
            cooking = true;
            // replenish; set timer and children to active
            timer.SetActive(true);
            /*foreach (Transform child in timer.transform){
                child.gameObject.SetActive(true);
            }*/
            StartCoroutine(CookMore());
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
