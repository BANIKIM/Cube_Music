using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ObjectInfo
{
    public GameObject Note_ob;
    public int count;//�Ѱ��� -> Ǯ�� �ִ밳��
    public Transform Parent_ob;
}


public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling instance=null;
    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public Queue<GameObject> nodeQueue = new Queue<GameObject>();
    [SerializeField] private ObjectInfo[] Stage_info = null;

    private void Start()
    {
        nodeQueue = Insert_queue(Stage_info[0]);
    }
    private Queue<GameObject> Insert_queue(ObjectInfo info)
    {
        //��ȯ�� ť ����
        Queue<GameObject> queue = new Queue<GameObject>();
        for(int i=0;i<info.count;i++)
        {
            //Ǯ���� ������Ʈ �����
            GameObject node_clone =
                 Instantiate(info.Note_ob, transform.position, Quaternion.identity);
            node_clone.SetActive(false);

            if(info.Parent_ob!=null)
            {
                node_clone.transform.SetParent(info.Parent_ob);
            }
            else
            {
                node_clone.transform.SetParent(this.transform);
            }
            queue.Enqueue(node_clone);
        }
        return queue;
    }
}
