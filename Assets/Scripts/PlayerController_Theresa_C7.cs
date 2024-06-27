using UnityEngine.InputSystem;

public class PlayerController_Theresa_C7: BasePlayerController
{
    private int comboCount = 5;
    private int comboIndex = 0;

    public override void OnWeapon(InputAction.CallbackContext callbackContext)
    {
        _animator.SetTrigger(_weapon_AnimatorHash);
    }

    private void SetComboAttack()
    {
        // Question: What is indeed?
        // Answer: Input Buffer, ToNextComboTiming, 

        switch (comboIndex)
        {
            case 0:

                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
        }

        comboIndex++;
        comboIndex %= comboCount;
    }
}
