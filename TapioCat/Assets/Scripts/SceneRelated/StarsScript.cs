using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsScript : MonoBehaviour
{  
    public GameObject[] stars;
    private float percentCollected;

    public AudioClip StarSound;
    AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void StarsManager(){
        IEnumerator ShowTwoStar(){
            stars[0].SetActive(true);
            _audioSource.PlayOneShot(StarSound);
            yield return new WaitForSeconds(1);
            stars[1].SetActive(true);
            _audioSource.PlayOneShot(StarSound);
        }

        IEnumerator ShowThreeStar(){
            stars[0].SetActive(true);
            _audioSource.PlayOneShot(StarSound);
            yield return new WaitForSeconds(1);
            stars[1].SetActive(true);
            _audioSource.PlayOneShot(StarSound);
            yield return new WaitForSeconds(1);
            stars[2].SetActive(true);
            _audioSource.PlayOneShot(StarSound);
        }

        if(SceneRelatedGlobal.levelToLoad == 1){
            percentCollected = float.Parse(SceneRelatedGlobal.servedCustomerNum.ToString())/float.Parse(SceneRelatedGlobal.level1NumCustomer.ToString()) * 100f;
            
        }
        else if(SceneRelatedGlobal.levelToLoad == 2){
            percentCollected = float.Parse(SceneRelatedGlobal.servedCustomerNum.ToString())/float.Parse(SceneRelatedGlobal.level2NumCustomer.ToString()) * 100f;
        }
        else if(SceneRelatedGlobal.levelToLoad == 3){
            percentCollected = float.Parse(SceneRelatedGlobal.servedCustomerNum.ToString())/float.Parse(SceneRelatedGlobal.level3NumCustomer.ToString()) * 100f;
        }
        else if(SceneRelatedGlobal.levelToLoad == 4){
            percentCollected = float.Parse(SceneRelatedGlobal.servedCustomerNum.ToString())/float.Parse(SceneRelatedGlobal.level4NumCustomer.ToString()) * 100f;
        }
        else if(SceneRelatedGlobal.levelToLoad == 5){
            percentCollected = float.Parse(SceneRelatedGlobal.servedCustomerNum.ToString())/float.Parse(SceneRelatedGlobal.level5NumCustomer.ToString()) * 100f;
        }
        
        if(percentCollected >= 30 && percentCollected <60){
            
            stars[0].SetActive(true);
            _audioSource.PlayOneShot(StarSound);
        }
        else if(percentCollected >= 60 && percentCollected < 90){
            StartCoroutine(ShowTwoStar());
        }
        else if(percentCollected >= 90){
            
            StartCoroutine(ShowThreeStar());
            
        }

        SceneRelatedGlobal.servedCustomerNum = 0;
		SceneRelatedGlobal.angryCustomerNum = 0;
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
}
