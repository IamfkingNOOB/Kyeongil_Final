using UnityEngine;

/// <summary>
/// 플레이어의 Idle(출격 시의 AFK 값) 상태를 관리하는 클래스입니다.
/// </summary>
public class PlayerIdleState : BasePlayerState
{
    // 생성자
    public PlayerIdleState(BasePlayerController playerController) : base(playerController) { }

    // 상태 진입 시,
    public override void Enter()
    {
        // Idle 애니메이션을 재생합니다.
        _animator.SetTrigger(_idle_AnimatorHash);
    }

    // 상태 유지 시,
    public override void Execute()
    {
        // 만약 Standby 상태로 전환 중이라면, (Has Exit Time에 의한 자동 전환)
        if (_animator.GetAnimatorTransitionInfo(0).IsName("Idle -> Standby"))
        {
            // Standby 상태에 진입합니다.
            _playerController.ChangeState(new PlayerStandbyState(_playerController));
        }
    }

    // 상태 탈출 시,
    public override void Exit() { }

    // Input Systems
    public override void OnMove(Vector2 inputVector)
    {
        _playerController.ChangeState(new PlayerMoveState(_playerController));
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
}
