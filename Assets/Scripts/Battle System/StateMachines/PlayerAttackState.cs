using System;
using UnityEngine;

/// <summary>
/// 플레이어의 Attack(공격) 상태를 관리하는 클래스입니다.
/// </summary>
public class PlayerAttackState : BasePlayerState
{
    // 선입력 관련 변수
    private float _preInputDelay = 0.3f;
    private Action _preInput;
    private bool isTransit = false;

    // 생성자
    public PlayerAttackState(BasePlayerController playerController) : base(playerController) { }

    // 상태 진입 시,
    public override void Enter()
    {
        _animator.SetTrigger(_attack_AnimatorHash);
    }

    // 상태 유지 시,
    public override void Execute()
    {
        if (_preInputDelay > _animator.GetCurrentAnimatorStateInfo(0).normalizedTime)
        {
            isTransit = false;
        }

        if (_preInputDelay < _animator.GetCurrentAnimatorStateInfo(0).normalizedTime && !isTransit)
        {
            Debug.Log($"Pre Input Delay = {_preInputDelay}, GetCurrentAnimatorStateInfo().normalizedTime = {_animator.GetCurrentAnimatorStateInfo(0).normalizedTime}");

            _preInput?.Invoke();
            _preInput = null;
            isTransit = true;
        }
    }

    // 상태 탈출 시,
    public override void Exit()
    {

    }

    // Input Systems
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
        _preInput = () => { _animator.SetTrigger(_attack_AnimatorHash); };
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
