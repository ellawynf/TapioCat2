using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarFill : MonoBehaviour
{
    
    public GameObject[] stars;
    public Slider slider;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    void Update(){
        SceneRelatedGlobal.percentServed = float.Parse(SceneRelatedGlobal.servedCustomerNum.ToString())/float.Parse(SceneRelatedGlobal.totalNumCustomer.ToString()) * 100f;
        
        SetProgress(SceneRelatedGlobal.percentServed);
    }
    
    public void SetProgress(float progress){
        
        slider.value = progress;
        if(SceneRelatedGlobal.percentServed >= 30 && SceneRelatedGlobal.percentServed  <60){
            
            stars[0].SetActive(true);
            
        }
        else if(SceneRelatedGlobal.percentServed  >= 60 && SceneRelatedGlobal.percentServed  < 90){
            stars[1].SetActive(true);
            
        }
        else if(SceneRelatedGlobal.percentServed  >= 90){
            
            stars[2].SetActive(true);
            
            
        }
    }
}
