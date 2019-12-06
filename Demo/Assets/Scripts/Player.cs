
using UnityEngine;
using UnityEngine.UI;
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
    [Header("音效區域")]
    public AudioSource aud;
    public AudioClip soundDiamod;
    [Header("磚石區域")]
    public int diamondCurrent;
    public int diamondTotal;
    public Text textDiamond;
    #endregion



    //定義方法
    // 修飾詞 傳回類型 方法名稱 (){}
    private void Move()//移動
    {
       float h= Input.GetAxisRaw("Horizontal");  //檢測玩家輸入按鍵 -1為左 1為右
        r2d.AddForce(new Vector2(speed *h ,0)); //速度
        ani.SetBool("跑步開關",h != 0);//動畫元件設定值 
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) transform.eulerAngles = new Vector3(0, 180, 0);
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) transform.eulerAngles=new Vector3(0,0,0);
    }

    private void Jump() //跳躍 
    {//判斷按下空白鍵，並且在地板上判定isGround 為啓用
        if ( Input.GetKeyDown(KeyCode.Space) ||Input.GetKeyDown(KeyCode.W)&& isGround==true) //設置案件       
        {
            isGround = false;
            //力度(往上)
            r2d.AddForce(new Vector2(0, jump));
            ani.SetTrigger("跳躍觸發");
            
        }

    }

    private void Dead() //死亡
    {

    }
    //開始事件:播放時執行一次
    private void Start()
    {
        diamondTotal =GameObject.FindGameObjectsWithTag("磚石").Length;
        textDiamond.text = "鑽石:0 /" + diamondTotal;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag =="磚石")
        {
            aud.PlayOneShot(soundDiamod, 1.5f);
            Destroy(collision.gameObject);
            diamondCurrent++;
            textDiamond.text = "鑽石:" + diamondCurrent+"/"+diamondTotal;
        }
    }
}
