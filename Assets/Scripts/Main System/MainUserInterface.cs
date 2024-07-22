using UnityEngine;

/// <summary>
/// 메인 화면의 UI를 관리하는 클래스입니다.
/// </summary>
public class MainUserInterface : MonoBehaviour
{
    // 장비 버튼 이벤트
    public void OnClickEquipmentButton()
    {
        MySceneManager.LoadScene(SceneName.Equipment_Scene);
    }

    // 협력 캐릭터 버튼 이벤트
    public void OnClickElfButton()
    {
        MySceneManager.LoadScene(SceneName.Elf_Scene);
    }

    // 출격 버튼 이벤트
    public void OnClickBattleButton()
    {
        MySceneManager.LoadScene(SceneName.Battle_Scene);
    }

    // 발키리 버튼 이벤트
    public void OnClickValkyrieButton()
    {
        MySceneManager.LoadScene(SceneName.Valkyrie_Scene);
    }

    // 보급 버튼 이벤트
    public void OnClickGachaButton()
    {
        MySceneManager.LoadScene(SceneName.Gacha_Scene);
    }
}
