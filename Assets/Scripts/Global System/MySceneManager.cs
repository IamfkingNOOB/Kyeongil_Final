using System;
using UnityEngine.SceneManagement;

/// <summary>
/// Scene의 이름을 Enum으로 명시합니다.
/// </summary>
public enum SceneName
{
    Main_Scene, // 메인 화면
    Equipment_Scene, // 장비 화면
    Elf_Scene, // 협력 캐릭터 화면
    Battle_Scene, // 출격 화면
    Valkyrie_Scene, // 발키리 화면
    Gacha_Scene, // 보급 화면
}

/// <summary>
/// Scene의 이름을 Enum으로 명시하여 사용하기 위해 사용자 정의한 SceneManager입니다.
/// </summary>
public class MySceneManager : Singleton<MySceneManager>
{
    private string _beforeSceneName;

    /// <summary>
    /// SceneManager.LoadScene() 함수를 Enum을 매개변수로 받아 호출합니다.
    /// </summary>
    /// <param name="sceneName">Enum으로 정의한 Scene의 이름</param>
    public void LoadScene(SceneName sceneName)
    {
        // 현재 열려 있는 Scene의 정보를 저장해 둡니다.
        _beforeSceneName = SceneManager.GetActiveScene().name;
        UnityEngine.Debug.Log($"BeforeScene = {_beforeSceneName}");

        // Enum으로 받은 Scene의 이름을 string으로 변환하여, SceneManager.LoadScene() 함수를 호출합니다.
        string sceneNameToString = ConvertSceneNameToString(sceneName);
        SceneManager.LoadScene(sceneNameToString);
    }

    /// <summary>
    /// 직전에 열었던 Scene을 불러옵니다.
    /// </summary>
    public void LoadBeforeScene()
    {
        UnityEngine.Debug.Log($"BeforeScene = {_beforeSceneName}");
        SceneManager.LoadScene(_beforeSceneName);
    }

    // Enum으로 받은 Scene의 이름을 string으로 변환합니다.
    private string ConvertSceneNameToString(SceneName sceneName)
    {
        // 밑줄(_)을 공백으로 바꾸어 변환합니다.
        string sceneNameToString = Enum.GetName(typeof(SceneName), sceneName).Replace('_', ' ');
        return sceneNameToString;
    }
}
