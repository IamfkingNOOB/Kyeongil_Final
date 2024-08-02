using UnityEngine;
using UnityEngine.AI;

public class TempScript02 : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private NavMeshAgent _navMeshAgent;

    [SerializeField] private Transform _destinationTransform;

    private void Start()
    {
        _navMeshAgent.updatePosition = false;
        // _navMeshAgent.updateRotation = false;

        // _navMeshAgent.isStopped = true;
    }

    private void Update()
    {
        _navMeshAgent.SetDestination(_destinationTransform.position);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _navMeshAgent.SetDestination(_destinationTransform.position);
        }

        // Debug.Log(_navMeshAgent.destination);
        Debug.Log($"NavMeshAgent.RemainingDistance = {_navMeshAgent.remainingDistance}, NavMeshAgent.velocity = {_navMeshAgent.velocity}");
    }

    private void OnAnimatorMove()
    {
        // NavMeshAgent의 위치를 Animator의 Root Position에 동기화시킨다.
        Vector3 position = _animator.rootPosition;
        position.y = _navMeshAgent.nextPosition.y;
        transform.position = position;
        _navMeshAgent.nextPosition = transform.position;
    }
}
