using UnityEngine;
using UnityEngine.AI;
public class ClickPositionMove : MonoBehaviour
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
        if (Input.GetMouseButton(0)&&!Input.GetMouseButton(1))
        {
            Ray mouseCursorPos = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(mouseCursorPos, out _clickHit))
            {
                _clickPos = _clickHit.point;
                _clickPos.y = 1;
            }
            if (_clickPos != null)
            {
                _navMeshAgent.SetDestination(_clickPos);    
            }
            

        }    
    }
}
