using System;
using UnityEngine;

/// <summary>
/// 플레이어의 WeaponSkill(무기 스킬) 상태를 관리하는 클래스입니다.
/// </summary>
public class PlayerWeaponSkillState : BasePlayerState
{
    #region 생성자

    public PlayerWeaponSkillState(BasePlayerController playerController) : base(playerController) { }

    #endregion 생성자

    #region 함수

    #region 상태 전환 함수

    // 상태 진입 시,
    public override void Enter()
    {
        _animator.SetTrigger(_weapon_AnimatorHash);
    }

    // 상태 유지 시,
    public override void Execute()
    {

    }

    // 상태 탈출 시,
    public override void Exit()
    {

    }

    #endregion 상태 전환 함수

    #region 입력 시스템

    // 이동
    public override void OnMove(Vector2 inputVector)
    {
        _preInputAction = () => { _playerController.ChangeState(new PlayerMoveState(_playerController)); };
    }

    // 회피
    public override void OnEvade()
    {
        // 회피는 선입력 없이 즉시 실행합니다.
        _playerController.ChangeState(new PlayerEvadeState(_playerController));
    }

    // 공격
    public override void OnAttack()
    {
        _preInputAction = () => { _playerController.ChangeState(new PlayerAttackState(_playerController)); };
    }

    // 무기 스킬
    public override void OnWeaponSkill()
    {
        _animator.SetTrigger(_weapon_AnimatorHash);
    }

    // 필살기
    public override void OnUltimate()
    {
        _preInputAction = () => { _playerController.ChangeState(new PlayerUltimateState(_playerController)); };
    }

    #endregion 입력 시스템

    #endregion 함수
}
