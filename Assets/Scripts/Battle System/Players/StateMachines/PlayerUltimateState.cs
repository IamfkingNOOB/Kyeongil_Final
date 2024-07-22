using System;
using UnityEngine;

/// <summary>
/// 플레이어의 Ultimate(필살기) 상태를 관리하는 클래스입니다.
/// </summary>
public class PlayerUltimateState : BasePlayerState
{
    // 필살기 모드에 진입했을 경우, 아래와 같은 특수 상황이 발생한다.
    // 1. 컷신이 재생된다.
    // 2. 컷신이 재생되는 동안, 모든 조작이 불가능해진다.
    // 3. 필살기는 전환을 아예 하지 않아도 괜찮을 수도 있다.

    // 선입력 관련 변수
    private float _preInputDelay;
    private Action _preInput;

    // 생성자
    public PlayerUltimateState(BasePlayerController playerController) : base(playerController) { }

    // 상태 진입 시,
    public override void Enter()
    {
        _animator.SetTrigger(_ultimate_AnimatorHash);
    }

    // 상태 유지 시,
    public override void Execute()
    {

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
        _preInput = () => { _playerController.ChangeState(new PlayerEvadeState(_playerController)); };
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
