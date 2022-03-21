using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragItem : MonoBehaviour
{
    Vector3 cubeScreenPos;
    Vector3 offset;

    void Start()
    {
        StartCoroutine(OnMouseDown());
    }


    IEnumerator OnMouseDown()
    {
        //1. 得到物体的屏幕坐标
        cubeScreenPos = Camera.main.WorldToScreenPoint(transform.position);

        //2. 计算偏移量
        //鼠标的三维坐标
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cubeScreenPos.z);
        //鼠标三维坐标转为世界坐标
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        offset = transform.position - mousePos;

        //3. 物体随着鼠标移动
        while (Input.GetMouseButton(0))
        {
            //目前的鼠标二维坐标转为三维坐标
            Vector3 curMousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cubeScreenPos.z);
            //目前的鼠标三维坐标转为世界坐标
            curMousePos = Camera.main.ScreenToWorldPoint(curMousePos);

            //物体世界位置
            transform.position = curMousePos + offset;
            yield return new WaitForFixedUpdate(); //这个很重要，循环执行
        }
    }
}
