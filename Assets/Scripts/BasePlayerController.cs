using UnityEngine;
using UnityEngine.InputSystem;

interface IPlayerController // 플레이어로서의 캐릭터가 입력을 받아 행동할 내용을 정의한다.
{
    // 이동
    void OnMove(InputAction.CallbackContext callbackContext);

    // 회피
    void OnEvade(InputAction.CallbackContext callbackContext);

    // 공격
    void OnAttack(InputAction.CallbackContext callbackContext);

    // 무기
    void OnWeapon(InputAction.CallbackContext callbackContext);

    // 궁극기
    void OnUltra(InputAction.CallbackContext callbackContext);
}

// 플레이어로서의 캐릭터가 입력을 받아 행동할 내용을 다루는 최상위 클래스
public abstract class BasePlayerController : MonoBehaviour, IPlayerController
{
    #region Animator

    protected Animator _animator;

    protected readonly int _moveAnim_ToHash = Animator.StringToHash("Move");
    protected readonly int _evadeAnim_ToHash = Animator.StringToHash("Evade");
    protected readonly int _attackAnim_ToHash = Animator.StringToHash("Attack");
    protected readonly int _weaponAnim_ToHash = Animator.StringToHash("Weapon");
    protected readonly int _ultraAnim_ToHash = Animator.StringToHash("Ultra");

    #endregion Animator

    protected virtual void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    #region Input Systems

    // 이동
    public virtual void OnMove(InputAction.CallbackContext callbackContext)
    {

    }

    // 회피
    public virtual void OnEvade(InputAction.CallbackContext callbackContext)
    {
        _animator.SetTrigger(_evadeAnim_ToHash);
    }

    // 공격
    public virtual void OnAttack(InputAction.CallbackContext callbackContext)
    {
        _animator.SetTrigger(_attackAnim_ToHash);
    }

    // 무기 (무기는 없을 수도 있으므로 Virtual로 선언한다.)
    public virtual void OnWeapon(InputAction.CallbackContext callbackContext)
    {
        // _animator.SetTrigger(_weaponAnim_ToHash);
    }

    // 궁극기
    public virtual void OnUltra(InputAction.CallbackContext callbackContext)
    {
        _animator.SetTrigger(_ultraAnim_ToHash);
    }

    #endregion Input Systems
}
