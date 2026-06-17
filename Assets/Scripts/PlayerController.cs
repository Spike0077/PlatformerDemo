using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("移动参数")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 7f;

    [Header("地面检测")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float checkRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D _rb;
    private float _horizontalInput;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 获取左右输入 A/D、左右方向键
        _horizontalInput = Input.GetAxisRaw("Horizontal");

        // 圆形范围检测脚底是否碰到地面层
        bool isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        // 空格跳跃，仅落地时生效
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
        }
    }

    // 物理移动固定帧率更新，防止卡顿
    void FixedUpdate()
    {
        _rb.velocity = new Vector2(_horizontalInput * moveSpeed, _rb.velocity.y);
    }

    // Scene窗口绘制检测圆圈，方便调试
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }
}