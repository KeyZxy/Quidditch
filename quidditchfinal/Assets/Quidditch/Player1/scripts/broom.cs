using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Broom
{
    public string broomName;
    public Player player;
    public Broom(string name)
    {
        broomName = name;
    }

    // �������ڳ�ȡ���ﲢ����ʵ��
    public static Broom ExtractBroom()
    {
        int rand = UnityEngine.Random.Range(0,100);

        if (rand <=50 )
        {
            return new NormalBroom("��ͨɨ��");
        }
        else if (rand >50&&rand<=60)
        {
            return new Comet("����");
        }
        else if (rand >60&&rand<=80)
        {
            return new Halo2000("����2000");
        }
        else if (rand >80&&rand<=90)
        {
            return new Halo2001("����2001");
        }
        else
        {
            return new FireCrossbow("�����");
        }
    }

    // �鷽������������������д��ʵ�־���ļӳ�Ч��
    public virtual void ApplyBuff(Player player)
    {
        // Ĭ������£���ͨɨ��û�мӳ�Ч��
    }
    public class NormalBroom : Broom
    {
        public NormalBroom(string name) : base(name)
        {
        }
    }
    public class Comet : Broom
    {
        public Comet(string name) : base(name)
        {
        }

        public override void ApplyBuff(Player player)
        {
            // ���ǣ�������ٽ��Ͱٷ�֮2
            player.maxspeed *= 0.98f;
        }
    }
    public class Halo2000 : Broom
    {
        public Halo2000(string name) : base(name)
        {
        }

        public override void ApplyBuff(Player player)
        {
            // ����2000������������Ӱٷ�֮2
            player.maxspeed *= 1.02f;
        }
    }
    public class Halo2001 : Broom
    {
        public Halo2001(string name) : base(name)
        {
        }

        public override void ApplyBuff(Player player)
        {
            // ����2001�����ٶ���߰ٷ�֮20��������ٲ���
            player.acceleration *= 1.2f;
        }
    }
    public class FireCrossbow : Broom
    {
        public FireCrossbow(string name) : base(name)
        {
        }

        public override void ApplyBuff(Player player)
        {
            // ����������ٶ���߰ٷ�֮10�����������߰ٷ�֮1
            player.acceleration *= 1.1f;
            player.maxspeed *= 1.01f;
        }
    }


}
