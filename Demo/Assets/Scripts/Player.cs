
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("速度")][Range(0f,100f)]//最小值與最大值
   public float speed = 3.5f;
    [Header("跳躍"),Range(100,2000)]
    public int jump = 250; //跳躍高度
    [Header("物理判定"),Tooltip("用於判定角色是否在地板")]
    public bool isGround = false;
    [Header("角色名稱")]
    public string name = "Neke"; //名字
}
