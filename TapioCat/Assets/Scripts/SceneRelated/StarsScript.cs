using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsScript : MonoBehaviour
{  
    public GameObject[] stars;
    private float percentCollected;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StarsManager(){
        if(SceneRelatedGlobal.levelToLoad == 2){
            percentCollected = float.Parse(SceneRelatedGlobal.servedCustomerNum.ToString())/float.Parse(SceneRelatedGlobal.level1NumCustomer.ToString()) * 100f;
            Debug.Log("Level to Load =2");
            Debug.Log(percentCollected.ToString());
        }
        else if(SceneRelatedGlobal.levelToLoad == 3){
            percentCollected = SceneRelatedGlobal.servedCustomerNum/SceneRelatedGlobal.level2NumCustomer;
        }
        else if(SceneRelatedGlobal.levelToLoad == 4){
            percentCollected = SceneRelatedGlobal.servedCustomerNum/SceneRelatedGlobal.level3NumCustomer;
        }
        else if(SceneRelatedGlobal.levelToLoad == 5){
            percentCollected = SceneRelatedGlobal.servedCustomerNum/SceneRelatedGlobal.level4NumCustomer;
        }
        else if(SceneRelatedGlobal.levelToLoad == 1){
            percentCollected = SceneRelatedGlobal.servedCustomerNum/SceneRelatedGlobal.level5NumCustomer;
        }
        
        if(percentCollected >= 33f && percentCollected <66){
            Debug.Log("first if");
            stars[0].SetActive(true);
        }
        else if(percentCollected >= 66 && percentCollected < 90){
            stars[0].SetActive(true);
            stars[1].SetActive(true);
        }
        else {
            Debug.Log("Else");
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
