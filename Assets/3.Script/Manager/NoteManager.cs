using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    /*
     BPM 120 �����Ͽ�
     �д� 60��
        ��� -> 4����ǥ(1beat)
    60/120 => 0.5 1����

     */


    [Header("BPM�� ������ �ּ���^^7")]
    public int BPM = 0;

    double currentTime = 0d;

    [Header("ETC")]
    [SerializeField] private Transform Notespawner;
    [SerializeField] private GameObject NotePrefrabs;

    [SerializeField] private TimingManager timingManger;
    private void Awake()
    {
        timingManger = FindObjectOfType<TimingManager>();
    }
    private void Update()
    {
        currentTime += Time.deltaTime;
        //if(0.5��)
        if(currentTime>=(60d/BPM))
        {
            //GameObject note_ob = Instantiate(NotePrefrabs, Notespawner.position, Quaternion.identity);
            //note_ob.transform.SetParent(this.transform);

            //ť���� ����
            GameObject note = ObjectPooling.instance.nodeQueue.Dequeue();
            note.transform.position = Notespawner.position;
            note.SetActive(true);

            //Ÿ�̹� �Ŵ����� ������� ����. 
            timingManger.BoxNote_List.Add(note);


            currentTime -= (60d / BPM);
        }
    }


    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.CompareTag("Note"))
        {
            if(coll.TryGetComponent(out Note note))
            {
                if(note.getNoteFlag())//��Ʈ�� �̹����� Ȱ��ȭ�� �Ǿ� �ִٸ�? 
                {
                    Debug.Log("Miss");
                }
            }
            //Destroy(coll.gameObject);
            timingManger.BoxNote_List.Remove(coll.gameObject);
            ObjectPooling.instance.nodeQueue.Enqueue(coll.gameObject);
            coll.gameObject.SetActive(false);
        }
    }

}
