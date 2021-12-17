using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        
        ShowStars();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowStars(){
        GetComponent<StarsScript>().StarsManager();
    }
}
