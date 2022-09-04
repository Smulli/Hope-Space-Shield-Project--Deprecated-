using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManagement : MonoBehaviour
{
    public static ScoreManagement scoreManager{get;  set;}
    public int _score = 0;
    //Using TMPro libraries
    public TextMeshProUGUI scoreText;

    void Awake(){
        if(ScoreManagement.scoreManager == null){
            scoreManager = this;
        }
        else{Destroy(gameObject);}
    }

    void Update()
    {
        scoreText.text = _score.ToString();
    }
}
