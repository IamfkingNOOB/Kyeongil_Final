using UnityEngine.InputSystem;

public class PlayerController_Theresa_C7: BasePlayerController
{
    public override void OnWeapon(InputAction.CallbackContext callbackContext)
    {
        _animator.SetTrigger(_weapon_AnimatorHash);
    }


}
