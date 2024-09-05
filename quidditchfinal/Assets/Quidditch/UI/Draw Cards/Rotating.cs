using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour
{
    [Tooltip("���̽ڵ�")]
    public Transform Roulette;
    [Tooltip("������ת��Ȧ��")]
    public int RotateNumber = 4;
    //[Tooltip("������Ҫ��ת�Ķ���")]
    private float degrees = 0;
    [Tooltip("������ת���ٶ�")]
    public int RotateSpeed = 500;
    //[Tooltip("��ǰ������ת�ٶ�")]
    private float curRotateSpeed = 0;
    [Tooltip("���ٶ�")]
    public float deceleration = 3;
    [Tooltip("����ٶ�")]
    public float minSpeed = 50;
    [Tooltip("����ʣ����ת����ʱ��ʼ����")]
    public float surRotate = 720;
    [Tooltip("���������������")]
    public int All = 6;
    [Tooltip("��תֹͣ��λ��")]
    public int selectedIndex = 1;
    [Tooltip("��׼�Ƕ�")]
    public Boolean enblePrecise = false;
    //��������ת��
    private Boolean enbleLunpan = false;

    private void Start()
    {
        //ÿ���֡�ʸ�Ϊ60�����Ǳ�Ҫ��
        Application.targetFrameRate = 60;
    }

    private void Update()
    {

        if (this.enbleLunpan)
        {
            //�洢ÿ֡��Ҫ��ת�ĽǶ�
            float curRotate = 0;

            if (this.degrees > 0)
            {
                //�����֡��Ҫ��ת�ĽǶ�
                curRotate = Time.deltaTime * this.curRotateSpeed;

                //��׼��ָ���Ƕ�
                if (this.enblePrecise && curRotate > this.degrees)
                {
                    if (this.curRotateSpeed >= this.minSpeed)
                    {
                        //�ٶȼ���
                        this.curRotateSpeed = this.minSpeed / 2;
                        curRotate = Time.deltaTime * this.curRotateSpeed;
                        if (curRotate > this.degrees)
                        {
                            curRotate = this.degrees;
                        }
                    }
                    else
                    {
                        curRotate = this.degrees;
                    }

                }

                //����
                if (this.curRotateSpeed > this.minSpeed && this.degrees < this.surRotate)
                {
                    this.curRotateSpeed -= deceleration;
                }

                //��ʼ��ת
                this.Roulette.Rotate(Vector3.back * curRotate);
                this.degrees -= curRotate;

                if (this.degrees <= 0)
                {
                    this.enbleLunpan = false;
                }

            }
        }



    }

    /// <summary>
    /// ��ʼת��
    /// </summary>
    public void StartRoulette()
    {
        this.curRotateSpeed = this.RotateSpeed;

        //������������Ҫ��ת�ĽǶ�
        this.degrees = this.RotateNumber * 360 - ((this.selectedIndex - 1) * 360) / this.All - (360 - this.Roulette.eulerAngles.z);
        this.enbleLunpan = true;
    }
}
