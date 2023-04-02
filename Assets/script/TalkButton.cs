using UnityEngine;

public class TalkButton : MonoBehaviour
{
    public GameObject Button;
    public GameObject talkUI;
    public string objectName;
    [SerializeField] ��ܤ奻 lines;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Button.SetActive(true);     //��ܫ��s
        objectName = collision.gameObject.name;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Button.SetActive(false);    //���ë��s
    }

    public void hideUI()
    {
        if (Button.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            talkUI.SetActive(true); // ��ܹ�ܤ���
            //Debug.Log(objectName);

        }
    }

    private void Update()
    {
        hideUI();
    }

    public void E()
    {
        // �p�G�S���b��ܤ�
        if (DialogSystem.instance.��ܤ� == false)
        {
            // �����ܨt�Τ����}�l���
            DialogSystem.instance.�}�l���(lines);
        }
    }
}
