using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer_Consume : MonoBehaviour
{
    Image fillImage;
    float timeAmount =8;
    float time;

    //public Text timeText;
    // Start is called before the first frame update
    void Start()
    {
        fillImage = this.GetComponent<Image>();
        time = timeAmount;

    }

    // Update is called once per frame
    void Update()
    {
        if(time > 0){
            time -= Time.deltaTime;
            fillImage.fillAmount = time/timeAmount;
            //timeText.text = "Time :" + time.ToString("F");
        }
    }
}
