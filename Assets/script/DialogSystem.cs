using System.Collections;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    [Header("UI介面")]
    [SerializeField] Text textLabal = null;
    [SerializeField] Image faceImage = null;
    [Header("文本內容")]
    [SerializeField] TextAsset textFile = null;
    //-----------
    [SerializeField] Image 角色圖示_左 = null;
    [SerializeField] Image 角色圖示_右 = null;
    [SerializeField] Text 對話人名 = null;
    [SerializeField] Text 對話內容 = null;
    [SerializeField] Transform 繼續提示 = null;

    對話文本 當前文本;
    bool 對話中 = false;

    public static DialogSystem instance = null;

    private void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// 開始對話
    /// </summary>
    /// <param name="文本">文本內容</param>
    public void 開始對話(對話文本 文本)
    {
        // 如果正在對話就忽略此命令
        if (對話中 == true)
        {
            Debug.Log("已經在對話了");
            return;
        }
        // 取得文本
        當前文本 = 文本;
        // 開始異步執行對話
        StartCoroutine(對話());
    }

    IEnumerator 對話()
    {
        // 顯示正在對話的角色名稱
        對話人名.text = 當前文本.表[0].角色名稱;
        // 顯示正在對話的角色圖示
        // 如果是左邊的角色 就顯示圖示角色左
        // 如果是右邊的角色 就顯示圖示角色右
        // 條件 ? 成立做的事情 : 不成立做的事情
        角色圖示_左.sprite = 當前文本.表[0].左邊角色 ? 當前文本.表[0].角色圖示左 : null;
        角色圖示_右.sprite = 當前文本.表[0].左邊角色 ? null : 當前文本.表[0].角色圖示右;
        /*
        if (當前文本.表[0].左邊角色 == true)
        {
            角色圖示_左 = 當前文本.表[0].角色圖示左;
        }
        else if(當前文本.表[0].左邊角色 == false)
        {
            角色圖示_右 = 當前文本.表[0].角色圖示右;
        }
        */
        對話內容.text = "";
        繼續提示.localScale = Vector3.zero;
        //等待0.5秒
        yield return new WaitForSeconds(0.5f);

        // 對話總表
        for (int j = 0; j < 當前文本.表.Count; j++)
        {
            角色圖示_左.sprite = 當前文本.表[j].左邊角色 ? 當前文本.表[j].角色圖示左 : null;
            角色圖示_右.sprite = 當前文本.表[j].左邊角色 ? null : 當前文本.表[j].角色圖示右;
            繼續提示.localScale = Vector3.zero;
            //逐步顯示每一個字到畫面上
            string textFinal = "";
            for (int i = 0; i < 當前文本.表[j].文本內容.Length; i++)
            {
                // 有幾個字跑記個迴圈
                textFinal = textFinal + 當前文本.表[j].文本內容[i];
                // 顯示到畫面上
                對話內容.text = textFinal;
                yield return new WaitForSeconds(0.05f);
            }
            // 顯示繼續提示 讓玩家按了繼續
            繼續提示.localScale = Vector3.one;
        }

    }
}
