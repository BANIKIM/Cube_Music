using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterFrame : MonoBehaviour
{
    private AudioSource Source;
    private bool isstartMusic=false;

    private void Start()
    {
        Source = GetComponent<AudioSource>();
    }

    /*
     ù���� ��尡 ������ �� �뷡�� �ѹ� �� �÷���
        -> ù�� ° ��尡 �浹 �Ǿ��� �� 
        -> �浹 �̺�Ʈ�� Ʈ����
     */

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(!isstartMusic)//���� �뷡�� ������ ���� �ʰ�,
        {
            if(coll.CompareTag("Note"))
            {
                Source.Play();
                isstartMusic = true;
            }
        }
    }
}
