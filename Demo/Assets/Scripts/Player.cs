
using UnityEngine;

public class Player : MonoBehaviour
{
    #region 欄位區域
    [Header("速度")][Range(0f,100f)]//最小值與最大值
   public float speed = 3.5f;
    [Header("跳躍"),Range(100,2000)]
    public int jump = 250; //跳躍高度
    [Header("物理判定"),Tooltip("用於判定角色是否在地板")]
    public bool isGround = false;
    [Header("角色名稱")]
    public string name = "Neke"; //名字
    [Header("2D剛體")]
    [Header("元件")] //引用 
    public Rigidbody2D r2d;
    public Animator ani;
    #endregion



    //定義方法
    // 修飾詞 傳回類型 方法名稱 (){}
    private void Move()//移動
    {
       float h= Input.GetAxisRaw("Horizontal");  //檢測玩家輸入按鍵 -1為左 1為右
        r2d.AddForce(new Vector2(speed *h ,0)); //速度
        ani.SetBool("跑步開關",h != 0);//動畫元件設定值 
    }

    private void Jump() //跳躍 
    {//判斷按下空白鍵，並且在地板上判定isGround 為啓用
        if (Input.GetKeyDown(KeyCode.Space) && isGround==true) //設置案件       
        {
            isGround = false;
            //力度(往上)
            r2d.AddForce(new Vector2(0, jump));
            
        }

    }

    private void Dead() //死亡
    {

    }


    //事件:指定位置指定次數執行
    //一秒執行約60次（60FPS）
    private void Update()
    {
        Move();
        Jump();
    }
    //碰撞事件:2D物件踫撞時執行一次
    // collision 參數： 踫到物件的名字
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //檢測是否踫到地板
        if (collision.gameObject.name=="地板")
        {
            isGround = true;
        }
    }
}
