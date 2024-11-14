using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    const float CharacterJumpPower = 7f;
    const int MaxJump = 2;
    int RemainJump = 0;
    GameManager GM;

    void Awake()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // 좌클릭시 RemainJump를 하나 소모하여 CharacterJumpPower의 힘으로 점프한다.
        // ---------- TODO ---------- 
        if (Input.GetMouseButtonDown(0))
        {
            RemainJump -= 1;
            Jump(CharacterJumpPower);
        }
        // -------------------- 
    }

    // Jump with power
    void Jump(float power)
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector3(0, CharacterJumpPower, 0), ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // tag가 Platform인 것과 충돌하면 RemainJump를 초기화한다.
        // tag가 Obstacle인 것과 충돌하면 게임 오버한다.
        // ---------- TODO ---------- 
        if (col.collider.CompareTag("Platform"))
        {
            RemainJump = 0;
        }
        if (col.collider.CompareTag("Obstacle"))
        {
            Time.timeScale = 0;
            GM.GameOver();
        }
        // -------------------- 
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // tag가 Point인 것과 충돌하면 Point를 하나 얻고, 충돌한 오브젝트를 삭제한다.
        // ---------- TODO ---------- 
        if (col.CompareTag("Point"))
        {
            int point = 1;
            GM.GetPoint(point);
            Destroy(col.gameObject);
        }
        // -------------------- 
    }
}