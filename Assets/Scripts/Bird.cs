using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    //向上施力的大小
    public float upForce;

    private bool isDead = false;
    private Rigidbody2D rbody;
    private Animator animator;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isDead)
        {
            return;
        }
        // 鼠标左键点击、键盘按键、手柄按键
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            // 动画
            animator.SetTrigger("Flap");
            // 施力前直接初始化速度为0（也可以不用）
            //rbody.velocity = Vector2.zero;
            // 给鸟向上的力
            rbody.AddForce(new Vector2(0, upForce));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 设置禁止（可不用）
        //rbody.velocity = Vector2.zero;
        // 不设置0，而是和背景交换速度，可以滑行
        rbody.velocity = new Vector2(-GameController.instance.scrollSpeed, rbody.velocity.y);
        isDead = true;
        // TODO: 判断碰撞对象
        animator.SetTrigger("Die");
        GameController.instance.BirdDied();
    }
}
