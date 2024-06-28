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
    #region Fields

    #region Collider / Rigidbody

    private CapsuleCollider _capsuleCollider;
    private Rigidbody _rigidbody;

    #endregion Collider / Rigidbody

    #region Animator

    protected Animator _animator;

    protected readonly int _move_AnimatorHash = Animator.StringToHash("Move");
    protected readonly int _evade_AnimatorHash = Animator.StringToHash("Evade");
    protected readonly int _attack_AnimatorHash = Animator.StringToHash("Attack");
    protected readonly int _weapon_AnimatorHash = Animator.StringToHash("Weapon");
    protected readonly int _ultra_AnimatorHash = Animator.StringToHash("Ultra");

    protected readonly int _comboAble_AnimatorHash = Animator.StringToHash("Combo-able");

    #endregion Animator

    #region Move

    // 카메라의 위치 값
    private Transform _cameraTransform;
    
    // 입력(방향 키) 값
    private Vector2 inputVector;

    // 회전 속도
    [SerializeField] private float rotateSpeed;

    #endregion Move

    #endregion Fields

    #region Methods

    #region Unity Life Cycle Methods

    protected virtual void Awake()
    {
        _capsuleCollider = GetComponent<CapsuleCollider>();
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();

        _cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        Move(inputVector);
    }

    #endregion Unity Life Cycle Methods

    #region Input Systems

    // 사용자로부터 입력을 받아, 그에 해당하는 행동을 취한다.

    // 이동
    public virtual void OnMove(InputAction.CallbackContext callbackContext)
    {
        inputVector = callbackContext.ReadValue<Vector2>();
        Debug.Log(inputVector);
    }

    // 회피
    public virtual void OnEvade(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            _animator.SetTrigger(_evade_AnimatorHash);
        }
    }

    // 공격
    public virtual void OnAttack(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            _animator.SetTrigger(_attack_AnimatorHash);
        }
    }

    // 무기 스킬 (무기 스킬은 없을 수도 있다.)
    public virtual void OnWeapon(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            // _animator.SetTrigger(_weapon_AnimatorHash);
        }
    }

    // 궁극기
    public virtual void OnUltra(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            _animator.SetTrigger(_ultra_AnimatorHash);
        }
    }

    #endregion Input Systems

    #region Custom Methods

    // 캐릭터의 이동을 구현하는 함수
    private void Move(Vector2 inputVector)
    {
        // 카메라의 방향과 입력 값을 참조하여 이동 방향을 계산한다.
        Vector3 moveVector = inputVector.y * _cameraTransform.forward + inputVector.x * _cameraTransform.right;
        moveVector.y = 0f;
        moveVector.Normalize();

        // 입력 값이 있을 때만 이동과 회전을 수행한다.
        bool isMove = (inputVector != Vector2.zero);

        _animator.SetBool(_move_AnimatorHash, isMove); // 루트 모션(Root Motion)을 사용하여 이동한다.

        if (isMove) // 회전
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveVector), rotateSpeed * Time.deltaTime);
        }
    }

    private void SetComboUnable()
    {
        _animator.SetBool(_comboAble_AnimatorHash, false);
    }

    #endregion Custom Methods

    #endregion Methods
}
