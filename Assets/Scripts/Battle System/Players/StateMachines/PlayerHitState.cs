using UnityEngine;

/// <summary>
/// 플레이어의 Hit(피격) 상태를 관리하는 클래스입니다.
/// </summary>
public class PlayerHitState : BasePlayerState
{
    #region 생성자

    public PlayerHitState(BasePlayerController controller) : base(controller) { }

    #endregion 생성자

    #region 상태 전환 함수

    // 상태 진입 시,
    public override void Enter()
    {
        // 피격 애니메이션을 재생합니다.
        PlayHitAnimation(_animator);
    }

    // 상태 유지 시,
    public override void Execute()
    {
        // 발키리의 체력이 0 이하가 되었다면,
        if (_playerController._valkyrieData.CurrentHP <= 0)
        {
            // 죽은 상태가 됩니다.
            _playerController.ChangeState(new PlayerDieState(_playerController));
        }

        // Standby 상태로의 전환을 확인합니다.
        CheckTransitionToStandby();
    }

    // 상태 탈출 시,
    public override void Exit()
    {
        // 피격 애니메이션의 매개변수를 초기화합니다.
        _animator.ResetTrigger(_hit_AnimatorHash);
    }

    #endregion 상태 전환 함수

    #region 커스텀 함수

    private void PlayHitAnimation(Animator animator)
    {
        animator.SetTrigger(_hit_AnimatorHash);
    }

    #endregion 커스텀 함수

    #region 입력 시스템 (피격 상태에서는 조작할 수 없습니다.)

    public override void OnAttack() { }

    public override void OnEvade() { }

    public override void OnMove(Vector2 inputVector) { }

    public override void OnUltimate() { }

    public override void OnWeaponSkill() { }

    #endregion 입력 시스템 (피격 상태에서는 조작할 수 없습니다.)
}
