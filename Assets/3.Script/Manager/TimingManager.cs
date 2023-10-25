using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingManager : MonoBehaviour
{
    //Timing -> node 판정은 노드의 position 판정 기준을 내린다. 
    [Header("Time Rect(순서 : Perfect-> cool-> good-> bad)")]
    [SerializeField] private RectTransform[] TimmingRect;
    private Vector2[] TimingBox;

    [SerializeField] private RectTransform Center;

    public List<GameObject> BoxNote_List = new List<GameObject>();
    private void Start()
    {
        TimingBox = new Vector2[TimmingRect.Length];
        for(int i=0;i< TimingBox.Length;i++)
        {
            //최소값 구하는 방법
            //이미지의 중심 - (이미지의 너비 /2)
            //최대값을 구하는 방법
            // 이미지의 중심 +(이미지의 너비 /2)

            //배열 0번쨰 -> Perfect 
            //배열의 마지막 -> Bad
            TimingBox[i].Set
                (
                Center.localPosition.x-TimmingRect[i].rect.width/2,
                Center.localPosition.x+TimmingRect[i].rect.width/2
                );

        }
    }

    public bool Check_Timming()
    {
        for(int i=0;i<BoxNote_List.Count;i++)
        {
            float notePos_x = BoxNote_List[i].transform.localPosition.x;
            for(int x=0;x<TimingBox.Length;x++)
            {
                /*
                 판정 범위 안에 있는 지 확인 -> notePos_x 기준으로 갈겁니다. 

                 TimingBox 최소값(x) 과 최대값(y) 안에 있다면 그 판정으로 ㄱㄱ
                 */
                if (TimingBox[x].x<=notePos_x&&notePos_x<=TimingBox[x].y)
                    //범위안에 있다면?
                {
                    //판정 난 상황
                    if(BoxNote_List[i].transform.TryGetComponent(out Note note))
                    {
                        note.HideNote();
                    }
                    Debug.Log(Debug_Note(x));


                    return true;
                }
            }
        }
        return false;
    }

    public string Debug_Note(int i)
    {
        //퍼펙트 쿨 굿 배드
        switch(i)
        {
            case 0:
                return "Perfect";
            case 1:
                return "Cool";
            case 2:
                return "Good";
            case 3:
                return "Bad";
            default:
                return string.Empty;
        }
    }


}
