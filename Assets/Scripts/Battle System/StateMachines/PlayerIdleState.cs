using UnityEngine;

/// <summary>
/// 플레이어의 Idle(출격 시의 AFK 값) 상태를 관리하는 클래스입니다.
/// </summary>
public class PlayerIdleState : BasePlayerState
{
    #region 변수

    private int _idleAnimationCount = 0;

    #endregion 변수

    #region 생성자

    public PlayerIdleState(BasePlayerController playerController) : base(playerController) { }

    #endregion 생성자

    #region 함수

    #region 상태 전환 함수

    // 상태 진입 시,
    public override void Enter()
    {
        // 변수를 초기화합니다.
        InitializeField();

        // Idle 애니메이션을 재생합니다.
        PlayIdleAnimation();
    }

    // 상태 유지 시,
    public override void Execute()
    {
        Debug.Log("Idle State!");

        // Standby 상태로의 전환을 확인합니다.
        CheckTransitionToStandby();
    }

    // 상태 탈출 시,
    public override void Exit()
    {
        // Idle 애니메이션의 트리거를 해제합니다.
        _animator.ResetTrigger(_idle_AnimatorHash);
    }

    #endregion 상태 전환 함수

    #region 입력 시스템

    public override void OnMove(Vector2 inputVector)
    {
        _playerController.ChangeState(new PlayerMoveState(_playerController, inputVector));
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

    private void InitializeField()
    {
        _idleAnimationCount = 2;
    }

    private void PlayIdleAnimation()
    {
        // 여러 개의 Idle 애니메이션이 있을 경우, 그 중 하나를 무작위로 고릅니다.
        int idleAnimationIndex = Random.Range(0, _idleAnimationCount);

        // Idle 애니메이션을 재생합니다.
        _animator.SetInteger(_idleCount_AnimatorHash, idleAnimationIndex);
        _animator.SetTrigger(_idle_AnimatorHash);
    }

    // Standby 상태로의 전환을 확인합니다.
    private void CheckTransitionToStandby()
    {
        // 만약 Standby 상태로 전환 중이라면, (Has Exit Time에 의한 자동 전환)
        if (_animator.GetAnimatorTransitionInfo(0).IsUserName("[Exit] Idle -> Standby"))
        {
            // Standby 상태에 진입합니다.
            _playerController.ChangeState(new PlayerStandbyState(_playerController));
        }
    }

    #endregion 커스텀 함수

    #endregion 함수
}
