using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarFill : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update
    public void SetProgress(int progress){
        slider.value = progress;
    }
}
