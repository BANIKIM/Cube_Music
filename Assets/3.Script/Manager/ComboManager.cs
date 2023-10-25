using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ComboManager : MonoBehaviour
{
    /*
     * �޺��� Ȱ��ȭ �Ǵ� ����
     * 1. miss�� �ƴϸ� ī��Ʈ ++
     * �޺��� ��Ȱ��ȭ �Ǵ� ����
     * 1. miss�� ��
     * 2. Bad�϶��� �޺��� ������ ����.
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
        //��� ������Ʈ�� ��ӵ� GameObject�� ��� �� �� �ִ�.
        Combo_Txt.gameObject.SetActive(false);
    }
    public void RestCombo()
    {
        //Bad�� Miss�� ��Ÿ���� ����Ұ���.
        current_combo = 0;
        Combo_Txt.text = string.Format("{0:#,##0}",current_combo);//1,000
        Combo_Img.SetActive(false);
        Combo_Txt.gameObject.SetActive(false);
    }
    public void Addcombo(int combo=1)
    {
        current_combo += combo;
        //"{0:#,##0}" -> {(�� ���� index : �� string ����)}
        Combo_Txt.text = string.Format("{0:#,##0}", current_combo);//1,000
        if(current_combo>=2)
        {
            Combo_Img.SetActive(true);
            Combo_Txt.gameObject.SetActive(true);
            ani.SetTrigger(anikey);
        }

    }
}
