using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 메인 화면의 UI를 관리하는 클래스입니다.
/// </summary>
public class MainUI : MonoBehaviour
{
    // 발키리 버튼 이벤트
    public void OnClickValkyrieButton()
    {
        SceneManager.LoadScene("Valkyrie Scene");
    }

    // 출격 버튼 이벤트
    public void OnClickBattleButton()
    {
        SceneManager.LoadScene("Battle Scene");
    }

    // 장비 버튼 이벤트
    public void OnClickEquipmentButton()
    {
        SceneManager.LoadScene("Equipment Scene");
    }

    // 보급 버튼 이벤트
    public void OnClickGachaButton()
    {
        SceneManager.LoadScene("Gacha Scene");
    }
}
