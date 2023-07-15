using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] Image PopLoco;
    [Header("咬住的圖片")]
    [SerializeField] Sprite isPress;
    [Header("張開的圖片")]
    [SerializeField] Sprite notPress;
    [Header("牙齒按鈕")]
    [SerializeField] Button[] buttonArray = null;
    [Header("正確按鈕編號")]
    [SerializeField] int correctAnswer;

    private int switchOn;

    private void Start()
    {
        RandomButtonNo();
        PopLoco.sprite = notPress;
    }

    /// <summary>
    /// 遊戲方法：點擊正確按鈕
    /// </summary>
    public void CorrectButtonOn()
    {
        if (switchOn == correctAnswer)
        {
            PopLoco.sprite = isPress;
        }
        else
        {
            PopLoco.sprite = notPress;
        }
    }

    /// <summary>
    /// 遊戲開始：隨機產生正確按鈕
    /// </summary>
    private void RandomButtonNo()
    {
        correctAnswer = Random.Range(0, buttonArray.Length);    // 隨機取得按鈕編號
    }
}
