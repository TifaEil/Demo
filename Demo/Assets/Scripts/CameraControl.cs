using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [Header("跟隨目標")]
    public Transform target;
    [Header("跟隨速度"), Range(0f, 100f)]
    public float speed = 1.5f;

    private void Track()
    {
        float limitY = Mathf.Clamp(target.position.y, -0.35f, 3f);
        //鏡頭跟隨
        Vector3 targetPos = new Vector3(target.position.x, limitY, -5);
        //配置鏡頭坐標=三位向量.插值(鏡頭.座標,目標.座標,百分比*速度*一幀的時間)
        transform.position = Vector3.Lerp(transform.position,targetPos, 0.3f * speed * Time.deltaTime);
    }
    private void LateUpdate()
    {
        Track();
    }
}
