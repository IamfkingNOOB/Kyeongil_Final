using UnityEngine;

/// <summary>
/// 메인 화면의 UI를 관리하는 클래스입니다.
/// </summary>
public class MainUI : MonoBehaviour
{
    // 장비 버튼 이벤트
    public void OnClickEquipmentButton()
    {
        MySceneManager.Instance.LoadScene(SceneName.Equipment_Scene);
    }

    // 협력 캐릭터 버튼 이벤트
    public void OnClickElfButton()
    {
        MySceneManager.Instance.LoadScene(SceneName.Elf_Scene);
    }

    // 출격 버튼 이벤트
    public void OnClickBattleButton()
    {
        MySceneManager.Instance.LoadScene(SceneName.Battle_Scene);
    }

    // 발키리 버튼 이벤트
    public void OnClickValkyrieButton()
    {
        MySceneManager.Instance.LoadScene(SceneName.Valkyrie_Scene);
    }

    // 보급 버튼 이벤트
    public void OnClickGachaButton()
    {
        MySceneManager.Instance.LoadScene(SceneName.Gacha_Scene);
    }
}
