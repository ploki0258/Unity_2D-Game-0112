using UnityEngine;

public class BallController : MonoBehaviour
{
	[SerializeField, Header("移動速度"), Range(0, 10)]
	float speed = 3f;
	[SerializeField, Header("移動方向")]
	Vector2 direction = Vector2.zero;

	private Rigidbody2D rig2D;
	private float random_X;
	private float random_Y;
	[Tooltip("是否碰到牆")]
	private bool hitWall = false;   // 是否碰到牆

	private void Awake()
	{
		rig2D = GetComponent<Rigidbody2D>();
	}

	private void Start()
	{
		random_X = Random.Range(0, 180);
		random_Y = Random.Range(0, 180);
	}

	private void Update()
	{
		BallMove();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		int randomValue;

		if (collision.gameObject.name.Contains("air wall") || collision.gameObject.name.Contains("ball"))
		{
			hitWall = true;
			
			if (Random.value < 0.5)
			{
				randomValue = -1;
			}
			else
			{
				randomValue = 1;
			}
			random_X = randomValue * Random.Range(0, 180);
			random_Y = randomValue * Random.Range(0, 180);
		}
	}

	/// <summary>
	/// 球移動
	/// </summary>
	void BallMove()
	{
		direction = new Vector2(random_X, random_Y);
		rig2D.velocity = direction * speed * Time.deltaTime;
		// rig2D.AddForce(direction * speed * Time.deltaTime, ForceMode2D.Force);
		/*
		if (hitWall)
		{
			float randomValue = Random.Range(1f, 6f);

			random_X = -1 * random_X;
			random_Y = -1 * random_Y;

			// Debug.Log($"<color=yellow>{randomValue}</color>");
		}
		*/
		// Debug.Log($"<color=#900500>{hitWall}</color>");
	}
}
