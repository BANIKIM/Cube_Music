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
     첫번쨰 노드가 지나갈 때 노래를 한번 만 플레이
        -> 첫번 째 노드가 충돌 되었을 떄 
        -> 충돌 이벤트는 트리거
     */

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(!isstartMusic)//현재 노래가 실행중 이지 않고,
        {
            if(coll.CompareTag("Note"))
            {
                Source.Play();
                isstartMusic = true;
            }
        }
    }
}
