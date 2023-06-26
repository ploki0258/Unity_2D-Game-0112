using UnityEngine;

public class TalkButton : MonoBehaviour
{
    public GameObject Button;
    public GameObject talkUI;
    public string objectName;
    [SerializeField] 對話文本 lines;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Button.SetActive(true);     //顯示按鈕
            // objectName = collision.gameObject.name;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Button.SetActive(false);    //隱藏按鈕
        }
    }

    /// <summary>
    /// 顯示即隱藏對話介面
    /// </summary>
    public void HideUI()
    {
        if (Button.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            if (DialogSystem.instance.對話中 == false)
            {
                // 執行對話系統中的開始對話
                DialogSystem.instance.開始對話(lines);
            }
        }
    }

    private void Update()
    {
        HideUI();
    }
}
