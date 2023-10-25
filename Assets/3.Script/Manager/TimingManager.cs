using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingManager : MonoBehaviour
{
    //Timing -> node ������ ����� position ���� ������ ������. 
    [Header("Time Rect(���� : Perfect-> cool-> good-> bad)")]
    [SerializeField] private RectTransform[] TimmingRect;
    private Vector2[] TimingBox;

    [SerializeField] private RectTransform Center;

    public List<GameObject> BoxNote_List = new List<GameObject>();
    private void Start()
    {
        TimingBox = new Vector2[TimmingRect.Length];
        for(int i=0;i< TimingBox.Length;i++)
        {
            //�ּҰ� ���ϴ� ���
            //�̹����� �߽� - (�̹����� �ʺ� /2)
            //�ִ밪�� ���ϴ� ���
            // �̹����� �߽� +(�̹����� �ʺ� /2)

            //�迭 0���� -> Perfect 
            //�迭�� ������ -> Bad
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
                 ���� ���� �ȿ� �ִ� �� Ȯ�� -> notePos_x �������� ���̴ϴ�. 

                 TimingBox �ּҰ�(x) �� �ִ밪(y) �ȿ� �ִٸ� �� �������� ����
                 */
                if (TimingBox[x].x<=notePos_x&&notePos_x<=TimingBox[x].y)
                    //�����ȿ� �ִٸ�?
                {
                    //���� �� ��Ȳ
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
        //����Ʈ �� �� ���
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
