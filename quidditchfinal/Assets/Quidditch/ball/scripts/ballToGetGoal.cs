using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ballToGetGoal : MonoBehaviour
{
    private Rigidbody2D _Rigid;
    private Vector2 startPosition = new Vector2(0, -4);
    public AudioClip audioClip;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        _Rigid = GetComponent<Rigidbody2D>();
        setballInitial();
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = false;
        audioSource.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGo = collision.gameObject;
        if (collisionGo.CompareTag("player1score"))
        {
            GameObject play1 = GameObject.FindGameObjectWithTag("Player1");
            Player playerComponent = play1.GetComponent<Player>();
            playerComponent.ballscore += 1;
            audioSource.PlayOneShot(audioClip);
            setball();
        }
        else if (collisionGo.CompareTag("player2score"))
        {
            GameObject Play2 = GameObject.FindGameObjectWithTag("Player2");
            Player playerComponent = Play2.GetComponent<Player>();
            playerComponent.ballscore += 1;
            audioSource.PlayOneShot(audioClip);
            setball();
        }
        else
        {
        }
    }
    void setball()
    {
        transform.position = startPosition;
        _Rigid.velocity = new Vector2(0, 5);
    }
    void setballInitial()
    {
        transform.position = Vector2.zero;
    }
}
