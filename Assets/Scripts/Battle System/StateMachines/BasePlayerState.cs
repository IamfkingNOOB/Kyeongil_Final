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

    // Move
    protected readonly int _move_AnimatorHash = Animator.StringToHash("IsMove");

    // Evade
    protected readonly int _evade_AnimatorHash = Animator.StringToHash("Evade");
    protected readonly int _evadeCount_AnimatorHash = Animator.StringToHash("EvadeCount");
    
    // Attack
    protected readonly int _attack_AnimatorHash = Animator.StringToHash("Attack");
    
    // Weapon
    protected readonly int _weapon_AnimatorHash = Animator.StringToHash("Weapon");
    
    // Ultimate
    protected readonly int _ultimate_AnimatorHash = Animator.StringToHash("Ultimate");

    #endregion

    #region 애니메이션의 전환에 필요한 변수

    // 선입력 대기 시간; 현재의 필수 행동이 실행되는 동안 다음 행동으로의 입력을 미리 할 수 있는 시간
    protected float _preInputDelay = 0.0f;
    // 후입력 가능 시간; 선입력 대기 시간 이후, 현재의 연계 행동으로 전환할 수 있는 입력의 최대 시간
    protected float _postInputDelay = 0.9f;
    protected Action _preInput; // 선입력 행동
    protected bool _isInTransition = false; // 애니메이션의 전환 여부; 선입력 이후에 입력에 대한 호출의 중복을 방지하기 위한 변수

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
}