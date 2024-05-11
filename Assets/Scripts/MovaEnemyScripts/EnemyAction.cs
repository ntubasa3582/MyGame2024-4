using UnityEngine;
using UnityEngine.AI;

public class EnemyAction : MonoBehaviour
{
    NavMeshAgent _navMeshAgent;
    enum ActionState      //自身の行動を管理する変数
    {
        DefaultMove,
        Attack,
        NewTarget
    }
    ActionState _actionState;
}
