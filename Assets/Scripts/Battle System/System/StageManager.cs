using UnityEngine;

public class StageManager : MonoBehaviour
{
    // 몬스터가 순찰할 위치들
    [SerializeField] private Transform[] _patrolTransforms;

    public Transform[] PatrolTransforms
    {
        get { return _patrolTransforms; }
    }
}
