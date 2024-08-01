using UnityEngine;

/// <summary>
/// 플레이어의 Evade(회피) 상태를 관리하는 클래스입니다.
/// </summary>
public class PlayerEvadeState : BasePlayerState
{
    #region 생성자

    public PlayerEvadeState(BasePlayerController playerController) : base(playerController) { }

    #endregion 생성자

    #region 함수

    #region 상태 전환 함수

    // 상태 진입 시,
    public override void Enter()
    {
        // 회피 애니메이션을 재생합니다.
        PlayEvadeAnimation(_animator);
    }

    // 상태 유지 시,
    public override void Execute()
    {
        // 현재 재생 중인 애니메이션의 시점을 가져옵니다. (0 ~ 1 사이의 정규화된 값)
        float currentAnimatorStateTime = _animator.GetCurrentAnimatorStateInfo(0).normalizedTime;

        //// 만약 현재 애니메이션의 전환이 불가능한 시점일 경우,
        //if (_preInputDelay >= currentAnimatorStateTime) // 선입력 대기 시간일 경우,
        //{
        //    // 전환하지 않습니다.
        //    _isInTransition = false;
        //}
        //// 만약 현재 애니메이션의 전환이 가능한 시점일 경우,
        //else if (_preInputDelay < currentAnimatorStateTime && !_isInTransition)
        //{
        //    _preInput?.Invoke(); // 선입력한 값이 있다면, 그것을 호출한다.
        //    _preInput = null; // 선입력 버퍼를 지운다.
        //    _isInTransition = true; // 전환한다.
        //}

        if (_isPreInputTime) return;

        // 선입력 시간이 지나고 입력 값이 들어오면,
        if (_preInputAction != null)
        {
            _preInputAction.Invoke(); // 입력 값을 즉시 실행하고,
            _preInputAction = null; // 입력 값을 초기화하고,
            _isPreInputTime = true; // 선입력 시간에 들어갑니다.
        }

        // Standby 상태로의 전환을 확인합니다.
        CheckTransitionToStandby();
    }

    // 상태 탈출 시,
    public override void Exit()
    {
        // 회피 애니메이션의 매개변수를 초기화합니다.
        _animator.ResetTrigger(_evade_AnimatorHash);
        _animator.SetInteger(_evadeCount_AnimatorHash, 0);

        _preInputAction = null;
    }

    #endregion 상태 전환 함수

    #region 입력 시스템

    // 이동
    public override void OnMove(Vector2 inputVector)
    {
        // [TODO]: 방향키와 함께 회피할 경우, 그 방향으로 회피하는 애니메이션을 재생해야 한다.
        _preInputAction = () => { _playerController.ChangeState(new PlayerMoveState(_playerController, inputVector)); };
    }

    // 회피
    public override void OnEvade()
    {
        // 회피 중 다시 회피할 수 있습니다. 이때는 '상태의 전환'이 일어나지는 않습니다.
        _preInputAction = () => { PlayEvadeAnimation(_animator); };
    }

    // 공격
    public override void OnAttack()
    {
        _preInputAction = () => { _playerController.ChangeState(new PlayerAttackState(_playerController)); };
    }

    // 무기 스킬
    public override void OnWeaponSkill()
    {
        _preInputAction = () => { _playerController.ChangeState(new PlayerWeaponSkillState(_playerController)); };
    }

    // 필살기
    public override void OnUltimate()
    {
        _preInputAction = () => { _playerController.ChangeState(new PlayerUltimateState(_playerController)); };
    }

    #endregion 입력 시스템

    #region 커스텀 함수

    // 회피 애니메이션을 재생합니다.
    private void PlayEvadeAnimation(Animator animator)
    {
        // 회피 애니메이션을 재생하고,
        animator.SetTrigger(_evade_AnimatorHash);
        // 회피 횟수를 증가시킵니다.
        animator.SetInteger(_evadeCount_AnimatorHash, _animator.GetInteger(_evadeCount_AnimatorHash) + 1);
    }

    #endregion 커스텀 함수

    #endregion 함수
}
