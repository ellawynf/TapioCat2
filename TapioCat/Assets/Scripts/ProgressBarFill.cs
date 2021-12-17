using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarFill : MonoBehaviour
{
    public AudioClip StarSound;
    AudioSource _audioSource;
    public GameObject[] stars;
    public Slider slider;

    
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    
    void Update(){
        SceneRelatedGlobal.percentServed = float.Parse(SceneRelatedGlobal.servedCustomerNum.ToString())/float.Parse(SceneRelatedGlobal.totalNumCustomer.ToString()) * 100f;
        
        SetProgress(SceneRelatedGlobal.percentServed);
    }
    
    public void SetProgress(float progress){
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
        slider.value = progress;
        if(SceneRelatedGlobal.percentServed >= 30 && SceneRelatedGlobal.percentServed  <60){
            
            stars[0].SetActive(true);
            _audioSource.PlayOneShot(StarSound);
        }
        else if(SceneRelatedGlobal.percentServed  >= 60 && SceneRelatedGlobal.percentServed  < 90){
            StartCoroutine(ShowTwoStar());
        }
        else {
            
            StartCoroutine(ShowThreeStar());
            
        }
    }
}
