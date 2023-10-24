using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    public float noteSpeed = 400f;

    private Image img;

    private void OnEnable()
    {

        if(img==null)
        {
            TryGetComponent(out img);
        }
        img.enabled = true;
    }

    //노트 이미지 숨기기
    public void HideNote()
    {
        img.enabled = false;
    }

    public bool getNoteFlag()
    {
        return img.enabled;
        /*
         enabled=true 
            => 판정 나지 않은 노드
         
         */
    }


    private void Update()
    {
        transform.localPosition += Vector3.right * noteSpeed * Time.deltaTime;
    }
}
