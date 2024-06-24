using UnityEngine.InputSystem;

public class PlayerController_Fuka_C6 : BasePlayerController
{
    public override void OnWeapon(InputAction.CallbackContext callbackContext)
    {
        _animator.SetTrigger(_weaponAnim_ToHash);
    }
}
