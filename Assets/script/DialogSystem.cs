using System.Collections;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    [Header("UI����")]
    [SerializeField] Text textLabal = null;
    [SerializeField] Image faceImage = null;
    [Header("�奻���e")]
    [SerializeField] TextAsset textFile = null;
    //-----------
    [SerializeField] Image ����ϥ�_�� = null;
    [SerializeField] Image ����ϥ�_�k = null;
    [SerializeField] Text ��ܤH�W = null;
    [SerializeField] Text ��ܤ��e = null;
    [SerializeField] Transform �~�򴣥� = null;

    ��ܤ奻 ��e�奻;
    bool ��ܤ� = false;

    public static DialogSystem instance = null;

    private void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// �}�l���
    /// </summary>
    /// <param name="�奻">�奻���e</param>
    public void �}�l���(��ܤ奻 �奻)
    {
        // �p�G���b��ܴN�������R�O
        if (��ܤ� == true)
        {
            Debug.Log("�w�g�b��ܤF");
            return;
        }
        // ���o�奻
        ��e�奻 = �奻;
        // �}�l���B������
        StartCoroutine(���());
    }

    IEnumerator ���()
    {
        // ��ܥ��b��ܪ�����W��
        ��ܤH�W.text = ��e�奻.��[0].����W��;
        // ��ܥ��b��ܪ�����ϥ�
        // �p�G�O���䪺���� �N��ܹϥܨ��⥪
        // �p�G�O�k�䪺���� �N��ܹϥܨ���k
        // ���� ? ���߰����Ʊ� : �����߰����Ʊ�
        ����ϥ�_��.sprite = ��e�奻.��[0].���䨤�� ? ��e�奻.��[0].����ϥܥ� : null;
        ����ϥ�_�k.sprite = ��e�奻.��[0].���䨤�� ? null : ��e�奻.��[0].����ϥܥk;
        /*
        if (��e�奻.��[0].���䨤�� == true)
        {
            ����ϥ�_�� = ��e�奻.��[0].����ϥܥ�;
        }
        else if(��e�奻.��[0].���䨤�� == false)
        {
            ����ϥ�_�k = ��e�奻.��[0].����ϥܥk;
        }
        */
        ��ܤ��e.text = "";
        �~�򴣥�.localScale = Vector3.zero;
        //����0.5��
        yield return new WaitForSeconds(0.5f);

        // ����`��
        for (int j = 0; j < ��e�奻.��.Count; j++)
        {
            ����ϥ�_��.sprite = ��e�奻.��[j].���䨤�� ? ��e�奻.��[j].����ϥܥ� : null;
            ����ϥ�_�k.sprite = ��e�奻.��[j].���䨤�� ? null : ��e�奻.��[j].����ϥܥk;
            �~�򴣥�.localScale = Vector3.zero;
            //�v�B��ܨC�@�Ӧr��e���W
            string textFinal = "";
            for (int i = 0; i < ��e�奻.��[j].�奻���e.Length; i++)
            {
                // ���X�Ӧr�]�O�Ӱj��
                textFinal = textFinal + ��e�奻.��[j].�奻���e[i];
                // ��ܨ�e���W
                ��ܤ��e.text = textFinal;
                yield return new WaitForSeconds(0.05f);
            }
            // ����~�򴣥� �����a���F�~��
            �~�򴣥�.localScale = Vector3.one;
        }

    }
}
