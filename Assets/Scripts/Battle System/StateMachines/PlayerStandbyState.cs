using UnityEngine;

/// <summary>
/// 플레이어의 Standby(출격 시의 기본 값) 상태를 다루는 클래스입니다.
/// </summary>
public class PlayerStandbyState : BasePlayerState
{
    // 변수
    private float tempTimeValue; // 시간과 관련한 값을 저장할 임시 변수 공간
    private float timeToIdle = 10.0f; // Idle 애니메이션을 재생하기까지의 대기 시간

    // 생성자
    public PlayerStandbyState(BasePlayerController playerController) : base(playerController) { }

    // 상태 진입 시, 
    public override void Enter()
    {
        // 진입했을 때의 시간을 저장한다.
        tempTimeValue = Time.time;
    }

    // 상태 유지 시,
    public override void Execute()
    {
        Debug.Log($"PlayerStandbyState : GetCurrentAnimatorStateInfo().normalizedTime = {_animator.GetCurrentAnimatorStateInfo(0).normalizedTime}");


        // 만약 일정 시간 이상 Standby 상태를 유지할 경우,
        if (tempTimeValue + timeToIdle < Time.time)
        {
            // Idle 상태에 진입합니다.
            _playerController.ChangeState(new PlayerIdleState(_playerController));
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
