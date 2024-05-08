using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class ClickPositionMove : MonoBehaviour  //マウスクリックを使って移動するスクリプト
{
    NavMeshAgent _navMeshAgent;
    RaycastHit _clickHit;
    Vector3 _clickPos;
    bool _isClick;

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0)&&!Input.GetMouseButton(1))  //クリックした場所に移動するスクリプト
        {
            Ray mouseCursorPos = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(mouseCursorPos, out _clickHit))
            {
                _clickPos = _clickHit.point;
                _clickPos.y = 1;
                transform.LookAt(_clickPos);
            }
            if (_clickPos != null)
            {
                _navMeshAgent.SetDestination(_clickPos);    
            }
        }
    }
}
