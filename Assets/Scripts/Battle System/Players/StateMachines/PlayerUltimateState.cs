using UnityEngine;

/// <summary>
/// 플레이어의 Ultimate(필살기) 상태를 관리하는 클래스입니다.
/// </summary>
public class PlayerUltimateState : BasePlayerState
{
    // 필살기 모드에 진입하는 조건
    // 1. 현재 SP가 소모 SP 이상일 경우

    // 필살기 모드에 진입했을 경우, 아래와 같은 특수 상황이 발생한다.
    // 1. 컷신이 재생된다.
    // 2. 컷신이 재생되는 동안, 모든 조작이 불가능해진다.
    // 3. 필살기는 전환을 아예 하지 않아도 괜찮을 수도 있다.

    #region 변수

    // private TimelineClip _cutScene; // 컷신을 타임라인으로 구현하여 재생시킨다.

    #endregion 변수

    #region 생성자

    public PlayerUltimateState(BasePlayerController playerController) : base(playerController) { }

    #endregion 생성자

    #region 함수

    #region 상태 전환 함수

    // 상태 진입 시,
    public override void Enter()
    {
        // _cutScene = _playerController.GetCutScene();

        _animator.SetTrigger(_ultimate_AnimatorHash);
    }

    // 상태 유지 시,
    public override void Execute()
    {
        CheckTransitionToStandby();
    }

    // 상태 탈출 시,
    public override void Exit()
    {
        _animator.ResetTrigger(_ultimate_AnimatorHash);
    }

    #endregion 상태 전환 함수

    #region 입력 시스템

    public override void OnMove(Vector2 inputVector)
    {
        // _preInput = () => { _playerController.ChangeState(new PlayerMoveState(_playerController)); };
    }

    public override void OnEvade()
    {
        // _preInput = () => { _playerController.ChangeState(new PlayerEvadeState(_playerController)); };
    }

    public override void OnAttack()
    {
        // _preInput = () => { _playerController.ChangeState(new PlayerAttackState(_playerController)); };
    }

    public override void OnWeaponSkill()
    {
        // _preInput = () => { _playerController.ChangeState(new PlayerWeaponSkillState(_playerController)); };
    }

    public override void OnUltimate()
    {
        // _preInput = () => { _playerController.ChangeState(new PlayerUltimateState(_playerController)); };
    }

    #endregion 입력 시스템

    #endregion 함수
}
