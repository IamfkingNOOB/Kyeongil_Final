using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class PlayerController : MonoBehaviour
{
    /*
     * 필요한 기능 목록
     * 
     * 1. 키 선입력 기능: 다른 행동 중일 때, 미리 다음 행동을 입력할 수 있다.
     * 2. 키 선입력 해제: 선입력이 적절하지 않을 경우, 현재 행동이 종료된 후 선입력된 행동을 취소해야 한다.
     * 3. 키 입력 시간에 따른 기능 분류: 같은 키를 짧게/길게 눌렀을 때 서로 다른 역할을 해야 한다. (Clear!)
     * 4. 콤보 공격
     */

    [SerializeField] private Animator _animator;
    private readonly int _attack_A_ToHash = Animator.StringToHash("Attack_A");
    private readonly int _attack_B_ToHash = Animator.StringToHash("Attack_B");
    private readonly int _attack_C_ToHash = Animator.StringToHash("Attack_C");
    private readonly int _attack_Ultra_ToHash = Animator.StringToHash("Attack_Ultra");
    private int attackType = 0;

    [Header("Weapons")]
    [SerializeField] private GameObject _weapon_A;
    [SerializeField] private GameObject _weapon_B_01;
    [SerializeField] private GameObject _weapon_B_02;
    [SerializeField] private GameObject _weapon_C;

    private void Start()
    {
        _weapon_A.SetActive(true);
        _weapon_B_01.SetActive(false);
        _weapon_B_02.SetActive(false);
        _weapon_C.SetActive(false);
    }

    // 일반 공격 (KeyCode: K)
    public void OnAttack(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            switch (attackType)
            {
                case 0:
                    _animator.SetTrigger(_attack_A_ToHash);
                    break;
                case 1:
                    _animator.SetTrigger(_attack_B_ToHash);
                    break;
                case 2:
                    _animator.SetTrigger(_attack_C_ToHash);
                    break;
                default:
                    Debug.Log("잘못된 접근입니다.");
                    break;
            }
        }
    }

    // 궁극기 (KeyCode: I)
    public void OnUltra(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            // 길게 눌렀을 경우, 궁극기를 발동한다.
            if (callbackContext.interaction is HoldInteraction)
            {
                _animator.SetTrigger(_attack_Ultra_ToHash);
            }

            // 짧게 눌렀을 경우, 일반 공격의 형태를 바꾼다.
            if (callbackContext.interaction is PressInteraction)
            {
                attackType = ++attackType % 3;
            }
        }
    }
}
