using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text Score_Text;
    [SerializeField] private Animator ani;

    private string anikey = "Score";

    int current_Score = 0;
    int Defult_Score = 10;

    [SerializeField] private float[] weight = null;
    private void Awake()
    {
        ani = GetComponent<Animator>();
        Score_Text = transform.GetChild(0).GetComponent<Text>();
    }

    public void AddScore(int index)
    {
        int _score = (int)(Defult_Score*weight[index]);

        current_Score += _score;
        Score_Text.text = string.Format("{0:#,##0}", current_Score);
        ani.SetTrigger(anikey);
    }

}
