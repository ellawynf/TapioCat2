using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/*
public class VideoTransition : MonoBehaviour
{
    RawImage m_RawImage;
    public Texture videoTexture;
    public float videoLength;
    // Start is called before the first frame update
    void Start()
    {
        m_RawImage = GetComponent<RawImage>();
        m_RawImage.gameObject.SetActive(false);
        StartCoroutine(Wait1());
        m_RawImage.gameObject.SetActive(true);
        StartCoroutine(FadeAndLoadVideo());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Wait1(){
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        yield return new WaitForSeconds(5);
        
        
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }

    IEnumerator FadeAndLoadVideo(){
        
        
        m_RawImage.gameObject.SetActive(true);
        m_RawImage.texture = videoTexture;
        
        yield return new WaitForSeconds(videoLength);
        m_RawImage.gameObject.SetActive(false);
        
        
    }
}
*/