using UnityEngine;

public class TalkButton : MonoBehaviour
{
    public GameObject Button;
    public GameObject talkUI;
    public string objectName;
    [SerializeField] ��ܤ奻 lines;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Button.SetActive(true);     //��ܫ��s
            // objectName = collision.gameObject.name;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Button.SetActive(false);    //���ë��s
        }
    }

    /// <summary>
    /// ��ܧY���ù�ܤ���
    /// </summary>
    public void HideUI()
    {
        if (Button.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            if (DialogSystem.instance.��ܤ� == false)
            {
                // �����ܨt�Τ����}�l���
                DialogSystem.instance.�}�l���(lines);
            }
        }
    }

    private void Update()
    {
        HideUI();
    }
}
