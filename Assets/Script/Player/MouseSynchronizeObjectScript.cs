using UnityEngine;
using System.Collections;
using Microsoft.Unity.VisualStudio.Editor;

public class MouseSynchronizeObjectScript : MonoBehaviour
{
    // 位置座標
    private Vector3 position;
    // スクリーン座標をワールド座標に変換した位置座標
    private Vector3 screenToWorldPointPosition;
    // Use this for initialization
    [SerializeField] RectTransform lock_on_image;
    [SerializeField] float pos_z;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //// Vector3でマウス位置座標を取得する
        //position = Input.mousePosition;
        //// Z軸修正
        //position.z = 20f;
        //// マウス位置座標をスクリーン座標からワールド座標に変換する
        //screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(position);

        //// ワールド座標に変換されたマウス座標を代入
        

        position = lock_on_image.position;
        // Z軸修正
        position.z = pos_z;
        // かいた
        position.y -= 20.0f;

        screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(position);

        gameObject.transform.position = screenToWorldPointPosition;
    }
}