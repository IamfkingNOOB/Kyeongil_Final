using System;
using UnityEngine;

/// <summary>
/// 플레이어의 각 상태에 대한 행동을 구체화하기 위한 인터페이스입니다. (상태 패턴)
/// </summary>
public interface IPlayerState
{
    void Enter(); // 상태 진입 시
    void Execute(); // 상태 유지 시
    void Exit(); // 상태 탈출 시

    // Input Systems
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
    // 플레이어의 조작을 담당하는 최상위 클래스
    protected readonly BasePlayerController _playerController;

    // 애니메이터
    protected Animator _animator;

    // 애니메이터의 매개변수, 해시화
    protected readonly int _move_AnimatorHash = Animator.StringToHash("Move");
    protected readonly int _evade_AnimatorHash = Animator.StringToHash("Evade");
    protected readonly int _attack_AnimatorHash = Animator.StringToHash("Attack");
    protected readonly int _weapon_AnimatorHash = Animator.StringToHash("Weapon");
    protected readonly int _ultimate_AnimatorHash = Animator.StringToHash("Ultimate");

    protected readonly int _idle_AnimatorHash = Animator.StringToHash("Idle");

    // 생성자
    public BasePlayerState(BasePlayerController playerController)
    {
        _playerController = playerController;
        _animator = _playerController.GetComponent<Animator>();
    }

    // IPlayerState 인터페이스 함수
    public abstract void Enter();
    public abstract void Execute();
    public abstract void Exit();
    public abstract void OnMove(Vector2 inputVector);
    public abstract void OnEvade();
    public abstract void OnAttack();
    public abstract void OnWeaponSkill();
    public abstract void OnUltimate();
}