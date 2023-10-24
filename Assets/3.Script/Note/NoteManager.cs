using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    /*
     BPM 120 가정하에
     분당 60개
        노드 -> 4분음표(1beat)
    60/120 => 0.5 1개식

     */


    [Header("BPM을 설정해 주세용^^7")]
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
        //if(0.5초)
        if(currentTime>=(60d/BPM))
        {
            //GameObject note_ob = Instantiate(NotePrefrabs, Notespawner.position, Quaternion.identity);
            //note_ob.transform.SetParent(this.transform);

            //큐에서 꺼냄
            GameObject note = ObjectPooling.instance.nodeQueue.Dequeue();
            note.transform.position = Notespawner.position;
            note.SetActive(true);

            //타이밍 매니저의 순서대로 넣음. 
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
                if(note.getNoteFlag())//노트의 이미지가 활성화가 되어 있다면? 
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
