using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class b2 : MonoBehaviour
{
    public SpriteRenderer sr;//���
    public Sprite[] pic;//ͼƬ
    public string broomName;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        // ʾ�����
        GameObject player2 = GameObject.FindGameObjectWithTag("Player2");
        Player playerCom2 = player2.GetComponent<Player>();
        // ��ȡһ���������
        Broom selectedBroom = Broom.ExtractBroom();
        Debug.Log($"���2��ȡ�����{selectedBroom.broomName}");
        broomName = selectedBroom.broomName;
        if (selectedBroom.broomName == "��ͨɨ��")
        {
            sr.sprite = pic[0];
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
        selectedBroom.ApplyBuff(playerCom2);

        // �����ҵ����ԣ���������ӳɺ�
        Debug.Log($"���2������٣�{playerCom2.maxspeed}");
        Debug.Log($"���2���ٶȣ�{playerCom2.acceleration}");

    }

    // Update is called once per frame
    void Update()
    {

    }
}
