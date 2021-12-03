using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlenderBinControl : MonoBehaviour
{
    /****************
    Goes on blender object
    Move tea from blender to plating
    ****************/

    public Transform iceTeaSP;
    public Transform hotTeaSP;

    public GameObject tea1Plating;
    public GameObject tea2Plating;
    public GameObject tea3Plating;

    public GameObject tea1Cook;
    public GameObject tea2Cook;
    public GameObject tea3Cook;

    void OnTriggerEnter2D(Collider2D other)
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

                } else if (GamePlay.plate2Cup == "empty"){      // hot tea cup

                    if (GamePlay.blender_contents == 1){
                        Instantiate(tea1Plating, hotTeaSP.position, tea1Plating.transform.rotation); 
                        GamePlay.plate2Cup = "tea";
                        GamePlay.plate2Tea = 1;
                        GamePlay.blender = "empty";
                        GamePlay.blender_contents = 0;
                        tea1Cook.SetActive(false);                        
                    } else if (GamePlay.blender_contents == 2){
                        Instantiate(tea2Plating, hotTeaSP.position, tea2Plating.transform.rotation); 
                        GamePlay.plate2Cup = "tea";
                        GamePlay.plate2Tea = 2;
                        GamePlay.blender = "empty";
                        GamePlay.blender_contents = 0;
                        tea2Cook.SetActive(false);
                    } else if (GamePlay.blender_contents == 3){
                        Instantiate(tea3Plating, hotTeaSP.position, tea3Plating.transform.rotation); 
                        GamePlay.plate2Cup = "tea";
                        GamePlay.plate2Tea = 3;
                        GamePlay.blender = "empty";
                        GamePlay.blender_contents = 0;
                        tea3Cook.SetActive(false);
                    }
                }                
            }

        }        
    }
}
