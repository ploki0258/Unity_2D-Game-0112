using UnityEngine;

public class TalkButton : MonoBehaviour
{
    public GameObject Button;
    public GameObject talkUI;
    public string objectName;

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
}
