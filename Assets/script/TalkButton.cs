using UnityEngine;

public class TalkButton : MonoBehaviour
{
    public GameObject Button;
    public GameObject talkUI;
    public string objectName;
    [SerializeField] 對話文本 lines;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Button.SetActive(true);     //顯示按鈕
        objectName = collision.gameObject.name;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Button.SetActive(false);    //隱藏按鈕
    }

    public void hideUI()
    {
        if (Button.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            talkUI.SetActive(true); // 顯示對話介面
            //Debug.Log(objectName);

        }
    }

    private void Update()
    {
        hideUI();
    }

    public void E()
    {
        // 如果沒有在對話中
        if (DialogSystem.instance.對話中 == false)
        {
            // 執行對話系統中的開始對話
            DialogSystem.instance.開始對話(lines);
        }
    }
}
