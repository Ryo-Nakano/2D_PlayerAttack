using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] float speed; //Playerの移動速度
    [SerializeField] GameObject bulletRight; //右に飛ぶBulletのPrefabをUnityからアタッチ
    [SerializeField] GameObject bulletLeft; //左に飛ぶBulletのPrefabをUnityからアタッチ

    bool goRight; //Playerが右に移動するかどうか
    bool goLeft; //Playerが左に移動するかどうか
    bool facingRight; //Playerが右を向いているかどうか(trueの時右を向いている)

    float bulletTimer; //弾の自動発射の頻度

    void Start()
    {
        facingRight = true; //最初Playerは左向き
    }

    void Update()
    {
        if (goRight == true)
        {
            this.transform.position += new Vector3(speed * Time.deltaTime, 0, 0); //右に移動
        }
        else if (goLeft == true)
        {
            this.transform.position -= new Vector3(speed * Time.deltaTime, 0, 0); //左に移動
        }
    }


    //左ボタン押し込んだ瞬間の処理
    public void RightButton_Down()
    {
        goRight = true; //右に移動できる状態に

        this.transform.rotation = Quaternion.Euler(0, 0, 0); //右を向かせる
        facingRight = true; //右を向いているフラグ立てる
    }

    //左ボタンを離した瞬間の処理
    public void RightButton_Up()
    {
        goRight = false; //右に移動できない状態に
    }

    //左ボタン押し込んだ瞬間の処理
    public void LeftButton_Down() {
        goLeft = true; //左に移動できる状態に

        this.transform.rotation = Quaternion.Euler(0, 180, 0); //左を向かせる
        facingRight = false; //左を向いているフラグ立てる
    }

    //左ボタン離した瞬間の処理
    public void LeftButton_Up()
    {
        goLeft = false; //左に移動できない状態に
    }

    //攻撃ボタンを押したときの処理
    public void AttackButton() {
        if (facingRight == true) //Playerが右向きの時
        {
            Vector3 diff = new Vector3(1.5f, 0, 0); //ちょっと生成位置を右にずらす
            Instantiate(bulletRight, this.transform.position + diff, Quaternion.identity); //弾を生成
        }
        else //PLayerが左向きの時
        {
            Vector3 diff = new Vector3(-1.5f, 0, 0); //ちょっと生成位置を左にずらす
            Instantiate(bulletLeft, this.transform.position + diff, Quaternion.identity); //弾を生成
        }
    }
}
