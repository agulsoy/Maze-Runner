using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage1Timer : MonoBehaviour
{
    public Text timerText;
    private float startTime;
    private bool timerFinish = false;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(timerFinish){
            return;
        }
        float t = Time.time - startTime;
        string minutes = ((int) t/ 60).ToString();
        string seconds = (t % 60).ToString("f2");
        timerText.text = minutes + " : " + seconds;
    }

    public void Finish(){
        timerFinish = true;
        timerText.color = Color.yellow;
    }
}