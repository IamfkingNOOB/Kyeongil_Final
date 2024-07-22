using System;
using UnityEngine;

/// <summary>
/// 플레이어의 WeaponSkill(무기 스킬) 상태를 관리하는 클래스입니다.
/// </summary>
public class PlayerWeaponSkillState : BasePlayerState
{
    // 선입력 관련 변수
    private float _preInputDelay;
    private Action _preInput;

    // 생성자
    public PlayerWeaponSkillState(BasePlayerController playerController) : base(playerController) { }

    // 상태 진입 시,
    public override void Enter()
    {
        _animator.SetTrigger(_weapon_AnimatorHash);
    }

    // 상태 유지 시,
    public override void Execute()
    {
        if (_preInputDelay < _animator.GetCurrentAnimatorStateInfo(0).normalizedTime)
        {
            _preInput?.Invoke();
        }
    }

    // 상태 탈출 시,
    public override void Exit()
    {

    }

    public override void OnMove(Vector2 inputVector)
    {
        _preInput = () => { _playerController.ChangeState(new PlayerMoveState(_playerController)); };
    }

    public override void OnEvade()
    {
        // 회피는 선입력 없이 즉시 실행합니다.
        _playerController.ChangeState(new PlayerEvadeState(_playerController));
    }

    public override void OnAttack()
    {
        _preInput = () => { _playerController.ChangeState(new PlayerAttackState(_playerController)); };
    }

    public override void OnWeaponSkill()
    {
        // ?
    }

    public override void OnUltimate()
    {
        _preInput = () => { _playerController.ChangeState(new PlayerUltimateState(_playerController)); };
    }
}
