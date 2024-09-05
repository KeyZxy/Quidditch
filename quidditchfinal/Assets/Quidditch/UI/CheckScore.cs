using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class CheckScore : MonoBehaviour
{
    
    public int player1BallScore;
    public int player2BallScore;
    public int player1GoldenBallScore;
    public int player2GoldenBallScore;
    public int player1totalscore;
    public int player2totalscore;
    public float gamingTime = 180;
    public float gamingTimeNow = 0;
    private Player player1Component;
    private Player player2Component;
    public Text player1Text;
    public Text player2Text;
    public Text countTime;
    public Text countScore;
    private float TextLivingTime;
    private GameObject play1;
    private GameObject play2;
    // Start is called before the first frame update
    void Start()
    {
        play1 = GameObject.FindGameObjectWithTag("Player1");
        play2 = GameObject.FindGameObjectWithTag("Player2");
        player1Component = play1.GetComponent<Player>();
        player2Component = play2.GetComponent<Player>();
    }
    // Update is called once per frame
    void Update()
    {
        TextLivingTime += Time.deltaTime; 
        gamingTimeNow += Time.deltaTime;
        player1BallScore = player1Component.ballscore;
        player2BallScore = player2Component.ballscore;
        player1GoldenBallScore = player1Component.goldenthievesscore;
        player2GoldenBallScore = player2Component.goldenthievesscore;
        player1totalscore = player1Component.score;
        player2totalscore = player2Component.score;
        countTime.text = $"��ʱ��{(int)gamingTimeNow}s";
        countScore.text = $"�÷֣�{player1totalscore}:{player2totalscore}";
        if (TextLivingTime > 1.5)
        {
            player1Text.text = $"����ȡ����ɨ���ǣ�{play1.GetComponent<buff1>().broomName}";
            player2Text.text = $"����ȡ����ɨ���ǣ�{play2.GetComponent<b2>().broomName}";
        }
        if ( TextLivingTime >3)
        {
            Destroy(player1Text);
            Destroy(player2Text);
        }
        //if (player1totalscore >= 10)
        //{
        //    //��Ϸ�������� ��ת���һʤ��
        //}
        //else if(player2totalscore >= 10)
        //{
        //    //��Ϸ�������� ��ת��Ҷ�ʤ��
        //}
        if (gamingTimeNow >= gamingTime)
        {
            if (player1totalscore > player2totalscore)
            {
                SceneManager.LoadScene("win"); //��Ϸ�������� ��ת���һʤ��
            }
            else if (player1totalscore < player2totalscore)
            {
                SceneManager.LoadScene("win2"); //��Ϸ�������� ��ת��Ҷ�ʤ��
            }
            else if (player1totalscore == player2totalscore)
            {
                SceneManager.LoadScene("draw");//��Ϸ�������� ��תƽ��
            }
        }
    }
}
