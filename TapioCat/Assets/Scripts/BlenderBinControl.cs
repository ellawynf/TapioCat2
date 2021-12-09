using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlenderBinControl : MonoBehaviour
{
    /****************
    Goes on blender object
    Move tea from blender to plating
    ****************/

    public Transform teaPlateSP;
    //public Transform hotTeaSP;

    public GameObject tea1Plating;
    public GameObject tea2Plating;
    public GameObject tea3Plating;

    public GameObject tea1Cook;
    public GameObject tea2Cook;
    public GameObject tea3Cook;

    public void Blender(){
        if (GamePlay.blender == "full"){

            if (GamePlay.plate1Cup == "empty"){     // tea must go in before topping
                GamePlay.plate1Cup = "tea";
                GamePlay.blender = "empty";

                if (GamePlay.blender_contents == 1){
                    Instantiate(tea1Plating, teaPlateSP.position, tea1Plating.transform.rotation); 
                    GamePlay.plate1Tea = 1;
                    tea1Cook.SetActive(false);
                } else if (GamePlay.blender_contents == 2){
                    Instantiate(tea2Plating, teaPlateSP.position, tea2Plating.transform.rotation); 
                    GamePlay.plate1Tea = 2;
                    tea2Cook.SetActive(false);
                } else if (GamePlay.blender_contents == 3){
                    Instantiate(tea3Plating, teaPlateSP.position, tea3Plating.transform.rotation); 
                    GamePlay.plate1Tea = 3;
                    tea3Cook.SetActive(false);
                }
                GamePlay.blender_contents = 0;
            }              
        }
    }

    /*void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")){

            if (GamePlay.blender == "full"){

                if (GamePlay.plate1Cup == "empty"){     // ice tea cup

                    if (GamePlay.blender_contents == 1){
                        Instantiate(tea1Plating, iceTeaSP.position, tea1Plating.transform.rotation); 
                        GamePlay.plate1Cup = "tea";
                        GamePlay.plate1Tea = 1;
                        GamePlay.blender = "empty";
                        GamePlay.blender_contents = 0;
                        tea1Cook.SetActive(false);
                    } else if (GamePlay.blender_contents == 2){
                        Instantiate(tea2Plating, iceTeaSP.position, tea2Plating.transform.rotation); 
                        GamePlay.plate1Cup = "tea";
                        GamePlay.plate1Tea = 2;
                        GamePlay.blender = "empty";
                        GamePlay.blender_contents = 0;
                        tea2Cook.SetActive(false);
                    } else if (GamePlay.blender_contents == 3){
                        Instantiate(tea3Plating, iceTeaSP.position, tea3Plating.transform.rotation); 
                        GamePlay.plate1Cup = "tea";
                        GamePlay.plate1Tea = 3;
                        GamePlay.blender = "empty";
                        GamePlay.blender_contents = 0;
                        tea3Cook.SetActive(false);
                    }
                }               
            }

        }        
    }*/
}
