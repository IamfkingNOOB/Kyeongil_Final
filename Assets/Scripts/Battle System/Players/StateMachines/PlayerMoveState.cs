using UnityEngine;

/// <summary>
/// 플레이어의 Move(이동) 상태를 관리하는 클래스입니다.
/// </summary>
public class PlayerMoveState : BasePlayerState
{
    #region 변수

    private Transform _cameraTransform; // 플레이어를 비추는 카메라의 위치 값

    #endregion 변수

    #region 생성자

    // 생성자
    public PlayerMoveState(BasePlayerController playerController) : base(playerController) { }

    public PlayerMoveState(BasePlayerController playerController, Vector2 inputVector) : base(playerController) { _inputVector = inputVector; }

    #endregion 생성자

    #region 상태 전환 함수

    // 상태 진입 시,
    public override void Enter()
    {
        // 카메라의 위치 값을 참조합니다.
        _cameraTransform = _playerController.CameraTransform;
    }

    // 상태 유지 시,
    public override void Execute()
    {
        // 플레이어는 입력을 받아 이동합니다.
        Move(_inputVector);

        // Standby로의 전환을 확인합니다.
        CheckTransitionToStandby();
    }

    // 상태 탈출 시,
    public override void Exit()
    {
        _animator.SetBool(_move_AnimatorHash, false);
    }

    #endregion 상태 전환 함수

    #region 입력 시스템

    // Input Systems
    public override void OnMove(Vector2 inputVector)
    {
        _inputVector = inputVector;
    }

    public override void OnEvade()
    {
        _playerController.ChangeState(new PlayerEvadeState(_playerController));
    }

    public override void OnAttack()
    {
        _playerController.ChangeState(new PlayerAttackState(_playerController));
    }

    public override void OnWeaponSkill()
    {
        _playerController.ChangeState(new PlayerWeaponSkillState(_playerController));
    }

    public override void OnUltimate()
    {
        _playerController.ChangeState(new PlayerUltimateState(_playerController));
    }

    #endregion 입력 시스템

    #region 커스텀 함수

    // 캐릭터의 이동을 구현합니다.
    private void Move(Vector2 inputVector)
    {
        // 카메라의 방향과 입력 값을 참조하여 이동 방향을 계산합니다.
        Vector3 moveVector = inputVector.y * _cameraTransform.forward + inputVector.x * _cameraTransform.right;
        moveVector.y = 0f; // Y축으로는 이동하지 않습니다.
        moveVector.Normalize(); // 값을 정규화합니다.

        // 입력 값이 있을 때만 이동과 회전을 수행합니다.
        bool isMove = (inputVector != Vector2.zero);

        _animator.SetBool(_move_AnimatorHash, isMove); // 이동; 루트 모션을 사용합니다.

        if (isMove) // 회전
        {
            _playerController.transform.rotation = Quaternion.Slerp(_playerController.transform.rotation, Quaternion.LookRotation(moveVector), 10.0f * Time.deltaTime * (1.0f / Time.timeScale));
        }
    }

    #endregion 커스텀 함수
}
