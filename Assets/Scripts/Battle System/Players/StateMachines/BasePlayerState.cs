using System;
using UnityEngine;

/// <summary>
/// 플레이어를 상태(State) 패턴으로 구현하기 위한 인터페이스입니다.
/// </summary>
public interface IPlayerState
{
    // 상태의 전환에 따른 함수들
    void Enter(); // 상태 진입 시
    void Execute(); // 상태 유지 시
    void Exit(); // 상태 탈출 시

    // 입력 시스템(Input System)에 따른 함수들
    void OnMove(Vector2 inputVector);
    void OnEvade();
    void OnAttack();
    void OnWeaponSkill();
    void OnUltimate();
}

/// <summary>
/// 플레이어의 상태를 다루는 최상위 클래스입니다.
/// </summary>
public abstract class BasePlayerState : IPlayerState
{
    #region 변수

    // 플레이어의 조작을 다루는 최상위 클래스
    protected readonly BasePlayerController _playerController;

    // 애니메이터
    protected Animator _animator;

    #region 애니메이터의 매개변수, 해시화

    // Idle
    protected readonly int _idle_AnimatorHash = Animator.StringToHash("Idle");
    protected readonly int _idleCount_AnimatorHash = Animator.StringToHash("Idle_Index");

    // Move
    protected readonly int _move_AnimatorHash = Animator.StringToHash("IsMove");

    // Evade
    protected readonly int _evade_AnimatorHash = Animator.StringToHash("Evade");
    protected readonly int _evadeCount_AnimatorHash = Animator.StringToHash("EvadeCount");
    
    // Attack
    protected readonly int _attack_AnimatorHash = Animator.StringToHash("Attack");
    protected readonly int _qte_AnimatorHash = Animator.StringToHash("QTE");
    
    // Weapon
    protected readonly int _weapon_AnimatorHash = Animator.StringToHash("Weapon");
    
    // Ultimate
    protected readonly int _ultimate_AnimatorHash = Animator.StringToHash("Ultimate");

    #endregion

    #region 애니메이션의 전환에 필요한 변수

    protected bool _isPreInputTime = true; // 현재 선입력 시간인지를 판별하는 변수
    protected Action _preInputAction; // 선입력으로 들어간 예약 행동

    // protected bool _isInTransition = false; // 애니메이션의 전환 여부; 선입력 이후에 입력에 대한 호출의 중복을 방지하기 위한 변수

    protected Vector2 _inputVector; // 이동 입력(방향키)에 대한 변수; 상태 전환 간 값을 유지하기 위해 이곳에서 정의합니다.

    #endregion 애니메이션의 전환에 필요한 변수

    #endregion 변수

    #region 생성자

    // 생성자
    public BasePlayerState(BasePlayerController playerController)
    {
        _playerController = playerController;
        _animator = _playerController.GetComponent<Animator>();
    }

    #endregion 생성자

    #region 인터페이스 상속 함수

    // IPlayerState
    public abstract void Enter();
    public abstract void Execute();
    public abstract void Exit();
    public abstract void OnMove(Vector2 inputVector);
    public abstract void OnEvade();
    public abstract void OnAttack();
    public abstract void OnWeaponSkill();
    public abstract void OnUltimate();

    #endregion 인터페이스 상속 함수

    #region 커스텀 함수

    // 애니메이션 이벤트; 각 애니메이션 클립에서, 선입력에 대한 처리를 정의하여 실행합니다. (클립마다 선입력의 시점이나 후속 처리가 전부 다릅니다.)
    private void ExecutePreInput()
    {
        _isPreInputTime = false; // 선입력 시간을 종료하고,
        _preInputAction?.Invoke(); // 선입력된 값이 있을 경우, 호출합니다.
        _preInputAction = null; // 선입력된 값을 초기화합니다.
    }

    // Standby 이외의 상태에서, Standby 상태로의 전환을 확인합니다. (다른 상태에서 가만히 있을 경우 스스로 Standby 상태로 전환합니다.)
    protected void CheckTransitionToStandby()
    {
        // 현재 재생 중인 애니메이션이 Standby라면,
        if (_animator.GetCurrentAnimatorStateInfo(0).IsTag("Standby"))
        {
            // Standby 상태에 들어갑니다. (Standby 애니메이션의 재생은 FSM의 Exit Time 값을 설정하여 적용합니다.)
            _playerController.ChangeState(new PlayerStandbyState(_playerController));
        }
    }

    #endregion 커스텀 함수
}