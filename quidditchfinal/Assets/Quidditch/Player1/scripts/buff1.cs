using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buff1 : MonoBehaviour
{
    public SpriteRenderer sr;//���
    public Sprite[] pic;//ͼƬ
    public string broomName;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        // ʾ�����
        GameObject player1 = GameObject.FindGameObjectWithTag("Player1");
        Player playerCom1 = player1.GetComponent<Player>();
        // ��ȡһ���������
        Broom selectedBroom = Broom.ExtractBroom();
        Debug.Log($"���1��ȡ�����{selectedBroom.broomName}");
        broomName = selectedBroom.broomName;
        if (selectedBroom.broomName=="��ͨɨ��")
        {
            sr.sprite= pic[0];
        }
        else if (selectedBroom.broomName == "����")
        {

            sr.sprite = pic[1];
        }
        else if (selectedBroom.broomName == "����2000")
        {

            sr.sprite = pic[2];
        }
        else if (selectedBroom.broomName == "����2001")
        {

            sr.sprite = pic[3];
        }
        else if (selectedBroom.broomName == "�����")
        {

            sr.sprite = pic[4];
        }
        // Ӧ������ļӳ�Ч��
        selectedBroom.ApplyBuff(playerCom1);

        // �����ҵ����ԣ���������ӳɺ�
        Debug.Log($"���1������٣�{playerCom1.maxspeed}");
        Debug.Log($"���1���ٶȣ�{playerCom1.acceleration}");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
