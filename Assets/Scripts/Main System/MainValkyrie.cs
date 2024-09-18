using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// 메인 화면에 등장하는 발키리(캐릭터)를 관리하는 클래스입니다.
/// </summary>
public class MainValkyrie : MonoBehaviour
{
    #region 유니티 생명 주기 함수

    // 첫 게임을 시작할 때,
    private void Start()
    {
        // 메인 발키리를 설정합니다.
        SetMainValkyrie();
    }

    #endregion 유니티 생명 주기 함수

    #region 커스텀 함수

    /// <summary>
    /// 메인 발키리를 설정합니다.
    /// </summary>
    private void SetMainValkyrie()
    {
        // 메인 발키리가 이전에 설정된 적이 있는지를 확인하여, 있으면 그 발키리를, 없으면 무작위의 발키리를 가져옵니다.
        int alreadySetMainValkyrieID = PlayerPrefs.GetInt("Main Valkyrie ID"); // 저장된 값이 없을 경우, '0'을 반환합니다.
        Valkyrie mainValkyrie = GetAlreadySetMainValkyrie(alreadySetMainValkyrieID);

        // 우선, 이미 지정되어 있는 메인 발키리를 제거합니다. (매개변수로 자식을 보내되, 자기 자신인 부모는 제외합니다.)
        DestroyChildren(GetComponentsInChildren<Transform>().Skip(1).ToArray());

        // 매개변수로 받은 발키리를 메인 발키리로 지정하여 생성합니다.
        Instantiate(mainValkyrie.Model, transform);

        // 이 값을 기억시켜, 게임을 다시 실행했을 때 마지막으로 지정한 발키리를 자동으로 선택하도록 합니다.
        PlayerPrefs.SetInt("Main Valkyrie ID", mainValkyrie.ValkyrieID);
    }

    /// <summary>
    /// 메인 발키리가 이전에 설정된 적이 있는지를 확인하여, 그 발키리를 반환합니다.
    /// </summary>
    /// <param name="playerPrefs">PlayerPrefs로 저장된 메인 발키리의 ID</param>
    private Valkyrie GetAlreadySetMainValkyrie(int playerPrefs)
    {
        // 발키리 목록을 가져옵니다.
        Dictionary<int, Valkyrie> valkyrieList = DataManager.Instance.ValkyrieList;

        Valkyrie valkyrie;

        // 만약 저장된 메인 발키리가 없다면,
        if (playerPrefs == 0 || valkyrieList[playerPrefs] == null)
        {
            // 발키리 목록에서 무작위로 한 명을 고릅니다.
            valkyrie = GetRandomValkyrie(valkyrieList);
        }
        // 만약 있다면,
        else
        {
            // 발키리 목록에서 그 발키리를 찾습니다.
            valkyrie = valkyrieList[playerPrefs];
        }

        // 그 발키리를 반환합니다.
        return valkyrie;
    }

    /// <summary>
    /// 발키리의 목록 중 한 명을 무작위로 반환합니다.
    /// </summary>
    /// <returns>무작위로 선택된 발키리</returns>
    private Valkyrie GetRandomValkyrie(Dictionary<int, Valkyrie> dictionary)
    {
        // 발키리를 무작위로 한 명 골라, 반환합니다.
        Valkyrie randomValkyrie = dictionary.ElementAt(Random.Range(0, dictionary.Count)).Value;
        return randomValkyrie;
    }

    /// <summary>
    /// 자식 게임 오브젝트를 전부 파괴합니다.
    /// </summary>
    /// <param name="children">자식 목록</param>
    private void DestroyChildren(Transform[] children)
    {
        // 자식을 순회하면서,
        foreach (Transform child in children)
        {
            // 자신을 파괴합니다.
            Destroy(child.gameObject);
        }
    }

    #endregion 커스텀 함수
}
