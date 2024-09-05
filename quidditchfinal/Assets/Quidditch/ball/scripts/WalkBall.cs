using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class WalkBall : MonoBehaviour
{
    public float walkSpeed = 0.8f;
    public float PursuitSpeed = 8;
    public float checkDistance = 3;
    public float generateLength;
    public float generateWidth;
    public float force;
    private GameObject player1;
    private GameObject player2;
    private bool isMoveing = false;
    private Rigidbody2D _Rigid;
    private Vector2 lastDir;
    public AudioClip audioClip;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
        _Rigid = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = false;
        audioSource.Stop();
    }
    void Update()
    {
        float distance1 = Vector2.Distance(transform.position, player1.transform.position);
        float distance2 = Vector2.Distance(transform.position, player2.transform.position);
        //�����ж�
        if (distance1 < checkDistance)
        {
            if (!isMoveing)
            {
                if (!player1.GetComponent<Player>().isCloaking)
                {
                    Attack(player1);
                    Debug.Log($"��⵽{player1.name}");
                    //�������һ
                }

            }
        }
        else if (distance2 < checkDistance)
        {
            if (!isMoveing)
            {
                if (!player2.GetComponent<Player>().isCloaking)
                {
                    //������Ҷ�
                    Debug.Log($"��⵽{player2.name}");
                    Attack(player2);
                }
                    
            }
        }
        if (_Rigid.velocity == Vector2.zero) 
        {
            isMoveing = false;
            //thinkingTime = 0;
            //��������
            Move();
        }
        lastDir = _Rigid.velocity.normalized;
    }
    void Move()
    {
        float x;
        float y;
        Vector2 targetPosition;
        Collider2D[] collider2Ds;
        do
        {
            x = Random.Range(-generateLength, generateLength);
            y = Random.Range(-generateWidth, generateWidth);
            targetPosition = new Vector2(x, y);
            collider2Ds = Physics2D.OverlapCircleAll(targetPosition, transform.localScale.x / 2);
        }
        while (collider2Ds.Length != 0);
        Debug.Log("������ʼ�ƶ�");
        _Rigid.velocity = (targetPosition - new Vector2(transform.position.x, transform.position.y)).normalized * walkSpeed;
    }
    void Attack(GameObject player)
    {
        _Rigid.velocity = (player.transform.position - transform.position).normalized * PursuitSpeed;
        audioSource.PlayOneShot(audioClip);
        isMoveing = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGO = collision.gameObject;
        if (collisionGO.CompareTag("Player1") || collisionGO.CompareTag("Player2"))
        {
            collisionGO.GetComponent<Rigidbody2D>().AddForce(lastDir * force, ForceMode2D.Force);
            Player player = collisionGO.GetComponent<Player>();
            if (!player.isShielding)
            {
                player.isshocking = true;
            }
        }
    }
}
