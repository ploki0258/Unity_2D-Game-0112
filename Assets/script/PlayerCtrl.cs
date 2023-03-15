using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    [Header("移動速度")]
    [SerializeField] float speed = 1.5f;

    private Rigidbody2D rig = null;
    private Animator ani = null;

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
    }

    /// <summary>
    /// 角色移動：動畫、翻轉
    /// </summary>
    private void Move()
    {
        float ws = Input.GetAxisRaw("Vertical");    // 垂直 -1~1
        float ad = Input.GetAxisRaw("Horizontal");  // 水平 -1~1

        Vector2 move = new Vector2(ad * speed, ws * speed);
        rig.velocity = move;           // 角色移動
        // transform.Translate(move);  // 角色移動(需在乘上Time.deltaTime)

        // 角色動畫
        /*
        if (move != Vector2.zero)
        {
            ani.SetBool("向上走", ws > 0);
            ani.SetBool("向下走", ws < 0);
            ani.SetBool("向右走", ad > 0);
        }
        */
        //翻轉
        /*
        if (move.x < 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        */
    }
}
