using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{
	[SerializeField, Header("隨機球物件")]
	GameObject ballObject = null;
	[SerializeField, Header("生成數量"), Range(1, 100)]
	int ballCount = 1;
	[SerializeField, Header("生成位置")]
	Transform[] ballTranforms;
	[SerializeField, Header("球的顏色")]
	SpriteRenderer[] colorArray;
	[SerializeField, Header("最小X軸範圍")]
	float xMin = 0f;
	[SerializeField, Header("最大X軸範圍")]
	float xMax = 0f;
	[SerializeField, Header("最小Y軸範圍")]
	float yMin = 0f;
	[SerializeField, Header("最大Y軸範圍")]
	float yMax = 0f;
	[SerializeField, Header("中心偏移量")]
	Vector3 offset;
	[SerializeField, Header("繪製X軸範圍")]
	float offset_X;
	[SerializeField, Header("繪製Y軸範圍")]
	float offset_Y;

	[Tooltip("正確編號")]
	private int correctAnswer;

	List<GameObject> ballList = new List<GameObject>();

	private void Awake()
	{
		// 指定陣列大小
		colorArray = new SpriteRenderer[ballCount];
	}

	private void Start()
	{
		CreateBall();
		// 取得所有特定物件的指定組件
		GetComponentArrayByObject("Ball");
	}

	// 繪製圖形
	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.cyan;
		Gizmos.DrawCube(transform.position + offset, new Vector3(offset_X, offset_Y, 0f));
	}

	/// <summary>
	/// 生成隨機球
	/// </summary>
	private void CreateBall()
	{
		float xRan = Random.Range(xMin, xMax);                  // 設置隨機X軸座標介於最大與最小之間
		float yRan = Random.Range(yMin, yMax);                  // 設置隨機Y軸座標介於最大與最小之間

		for (int i = 0; i < colorArray.Length; i++)
		{
			int noRan = Random.Range(0, ballTranforms.Length);          // 隨機取得編號
			Vector2 pos = new Vector2(xRan, yRan);              // 設置隨機座標
			GameObject tempBall = Instantiate(ballObject, pos, Quaternion.identity);    // 生成隨機位置
			ballList.Add(tempBall);

			float r = Random.Range(0, 255);
			float g = Random.Range(0, 255);
			float b = Random.Range(0, 255);
			SpriteRenderer ballRenderer = ballObject.GetComponent<SpriteRenderer>();

			if (ballRenderer != null)
			{
				ballRenderer.color = new Color(r, g, b);
			}
		}
		// Debug.Log($"<color=blue>{ballCount}</color>");
	}

	/// <summary>
	/// 隨機給予球顏色
	/// </summary>
	void RandomColor()
	{
		for (int i = 0; i < colorArray.Length; i++)
		{
			float r = Random.Range(0, 255);
			float g = Random.Range(0, 255);
			float b = Random.Range(0, 255);
			SpriteRenderer ballRenderer = ballObject.GetComponent<SpriteRenderer>();
		}
	}

	/// <summary>
	/// 取得所有特定物件的指定組件
	/// </summary>
	/// <param name="name">物件名稱</param>
	void GetComponentArrayByObject(string name)
	{
		for (int i = 0; i < ballCount; i++)
		{
			colorArray[i] = GameObject.FindGameObjectWithTag(name).GetComponent<SpriteRenderer>();
		}
	}

	/// <summary>
	/// 遊戲開始：隨機產生正確編號
	/// </summary>
	private void RandomButtonNo()
	{
		// 隨機設置正確編號
		correctAnswer = Random.Range(0, colorArray.Length);
	}

	/// <summary>
	/// 遊戲方法：點擊正確按鈕
	/// </summary>
	public void CorrectButtonOn()
	{

	}
}
