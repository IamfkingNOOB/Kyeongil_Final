using System;
using UnityEngine;

/// <summary>
/// 플레이어의 Evade(회피) 상태를 관리하는 클래스입니다.
/// </summary>
public class PlayerEvadeState : BasePlayerState
{
    // 변수; 연속 회피 가능 횟수
    private int _currentEvadeCount = 0;
    private int _maxEvadeCount = 2;

    // 선입력 관련 변수
    private float _preInputDelay;
    private Action _preInput;

    // 생성자
    public PlayerEvadeState(BasePlayerController playerController) : base(playerController) { }

    // 상태 진입 시,
    public override void Enter()
    {
        _animator.SetTrigger(_evade_AnimatorHash);
        _currentEvadeCount++;
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
        if (_currentEvadeCount < _maxEvadeCount)
        {
            _preInput = () => { _animator.SetTrigger(_evade_AnimatorHash); _currentEvadeCount++; };
        }
    }

    public override void OnAttack()
    {
        _preInput = () => { _playerController.ChangeState(new PlayerAttackState(_playerController)); };
    }

    public override void OnWeaponSkill()
    {
        _preInput = () => { _playerController.ChangeState(new PlayerWeaponSkillState(_playerController)); };
    }

    public override void OnUltimate()
    {
        _preInput = () => { _playerController.ChangeState(new PlayerUltimateState(_playerController)); };
    }
}
