using UnityEngine;

public class Play : MonoBehaviour
{
    [Header("隨機球")]
    [SerializeField] GameObject[] ballArray = new GameObject[0];
    [Header("最小X軸")]
    [SerializeField] float xMin = 0f;
    [Header("最大X軸")]
    [SerializeField] float xMax = 0f;
    [Header("最小Y軸")]
    [SerializeField] float yMin = 0f;
    [Header("最大Y軸")]
    [SerializeField] float yMax = 0f;

    private void Start()
    {
        CreateBall();

    }

    // 生成隨機球
    private void CreateBall()
    {
        float xRan = Random.Range(xMin, xMax);                      // 設置隨機X軸座標介於最大與最小之間
        float yRan = Random.Range(yMin, yMax);                      // 設置隨機Y軸座標介於最大與最小之間
                
        for (int i = 0; i < ballArray.Length; i++)
        {
            int noRan = Random.Range(0, ballArray.Length);              // 隨機取得編號
            Vector3 pos = new Vector3(xRan, yRan, 0f);                   // 設置隨機座標
            Instantiate(ballArray[noRan], pos, Quaternion.identity);    // 生成隨機位置
        }
    }
}
