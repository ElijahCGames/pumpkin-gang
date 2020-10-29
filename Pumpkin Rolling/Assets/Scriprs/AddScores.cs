using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddScores : MonoBehaviour
{
    public int score;

    public int winScore;

    public Text winText;

    public GameObject cap;

    private Text text;


    private void Start()
    {
        text = GetComponent<Text>();
        winText.text = "/" + winScore.ToString();

    }

    void OnEnable()
    {
        Roll.OnCollect += AddScore;
    }


    void OnDisable()
    {
        Roll.OnCollect -= AddScore;
    }

    void AddScore()
    {
        score += 1;
        text.text = score.ToString();

      

        AkSoundEngine.SetRTPCValue("Candy_Count", score, GameObject.Find("pumpkinMover"), 0100);

        if(score >= winScore)
        {
            cap.SetActive(false);
        }
    }
}
