using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ComboManager : MonoBehaviour
{
    /*
     * 콤보가 활성화 되는 시점
     * 1. miss가 아니면 카운트 ++
     * 콤보가 비활성화 되는 시점
     * 1. miss일 때
     * 2. Bad일때는 콤보를 셈하지 않음.
     */

    [SerializeField] private GameObject Combo_Img;
    [SerializeField] private Text Combo_Txt;

    int current_combo = 0;

    Animator ani;
    private string anikey = "Combo";

    private void Start()
    {
        TryGetComponent(out ani);
        Combo_Img.SetActive(false);
        //모든 컴포넌트는 상속된 GameObject를 들고 올 수 있다.
        Combo_Txt.gameObject.SetActive(false);
    }
    public void RestCombo()
    {
        //Bad나 Miss가 나타날때 사용할거임.
        current_combo = 0;
        Combo_Txt.text = string.Format("{0:#,##0}",current_combo);//1,000
        Combo_Img.SetActive(false);
        Combo_Txt.gameObject.SetActive(false);
    }
    public void Addcombo(int combo=1)
    {
        current_combo += combo;
        //"{0:#,##0}" -> {(들어갈 변수 index : 들어갈 string 형식)}
        Combo_Txt.text = string.Format("{0:#,##0}", current_combo);//1,000
        if(current_combo>=2)
        {
            Combo_Img.SetActive(true);
            Combo_Txt.gameObject.SetActive(true);
            ani.SetTrigger(anikey);
        }

    }
}
