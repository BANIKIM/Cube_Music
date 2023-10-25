using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectManager : MonoBehaviour
{
    [SerializeField] private Animator note_hitAnimator;
    [SerializeField] private Animator Judgement_Animator;
    [SerializeField] private Image Judgement_img;

    private string Key = "Hit";

    [Header("Perfect>Cool>Good>Bad")]
    [SerializeField] private Sprite[] Judgement_sprite;

    private void Awake()
    {
        transform.GetChild(0).TryGetComponent(out note_hitAnimator);
        transform.GetChild(1).TryGetComponent(out Judgement_Animator);
        transform.GetChild(1).TryGetComponent(out Judgement_img);

    }

    public void Judgement_Effect(int index)
    {
        Judgement_img.sprite = Judgement_sprite[index];
        Judgement_Animator.SetTrigger(Key);
    }
    public void Notehit_Effect()
    {
        note_hitAnimator.SetTrigger(Key);
    }

}
