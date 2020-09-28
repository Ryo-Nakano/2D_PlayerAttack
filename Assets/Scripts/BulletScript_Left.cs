using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript_Left : MonoBehaviour
{
    [SerializeField] float speed; //弾の飛ぶ速さ

    Rigidbody rb; //取得したRigidbodyを格納しておく為の変数

    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>(); //Rigidbodyを取得→変数rbに格納
        rb.velocity = -transform.right * speed; //弾をx軸の正方向に飛ばす

        Destroy(this.gameObject, 10f);
    }
}
