using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class PlayerClickMove : MonoBehaviour  //プレイヤーの移動をマウスクリックで操作する
{
    NavMeshAgent _navMeshAgent;
    Vector3 _clickPos;              //マウスクリックで飛ばしたrayの座標を入れる変数

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0)&&!Input.GetMouseButton(1))  
        {
            Ray mouseCursorPos = Camera.main.ScreenPointToRay(Input.mousePosition);     //カメラからのマウス座標をmouseCursorPosに入れる
            if (Physics.Raycast(mouseCursorPos, out var clickHit))      
            {
                _clickPos = clickHit.point;         //ヒットした座標を_clickPosに入れる
                _clickPos.y = 1;
                transform.LookAt(_clickPos);                            
            }
            if (_clickPos != null)
            {
                _navMeshAgent.SetDestination(_clickPos);    //クリックした場所にナビメッシュのSetDestinationを使って移動するプレイヤーを動かす
            }
        }
    }
}