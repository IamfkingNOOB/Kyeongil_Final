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
public static class MySceneManager
{
    /// <summary>
    /// SceneManager.LoadScene() 함수를 Enum을 매개변수로 받아 호출합니다.
    /// </summary>
    /// <param name="sceneName">Enum으로 정의한 Scene의 이름</param>
    public static void LoadScene(SceneName sceneName)
    {
        // Enum으로 받은 Scene의 이름을 string으로 변환하여, SceneManager.LoadScene() 함수를 호출합니다.
        string sceneNameToString = ConvertSceneNameToString(sceneName);
        SceneManager.LoadScene(sceneNameToString);
    }

    // Enum으로 받은 Scene의 이름을 string으로 변환합니다.
    private static string ConvertSceneNameToString(SceneName sceneName)
    {
        // 밑줄(_)을 공백으로 바꾸어 변환합니다.
        string sceneNameToString = Enum.GetName(typeof(SceneName), sceneName).Replace('_', ' ');
        return sceneNameToString;
    }
}
