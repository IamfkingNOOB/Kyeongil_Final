//using System.Collections.Generic;
//using System.Linq;
//using UnityEngine;

///// <summary>
///// 메인 화면에 등장하는 발키리(캐릭터)를 관리하는 클래스입니다.
///// </summary>
//public class MainValkyrie : MonoBehaviour
//{
//    #region 유니티 생명 주기 함수

//    // 첫 게임을 시작할 때,
//    private void Start()
//    {
//        // 이미 지정되어 있는 메인 캐릭터가 있는지를 확인합니다.
//        CheckMainValkyrie(PlayerPrefs.GetString("MainValkyrie"));
//    }

//    #endregion 유니티 생명 주기 함수

//    #region 커스텀 함수

//    /// <summary>
//    /// 메인 발키리가 지정되어 있는지를 확인합니다.
//    /// </summary>
//    /// <param name="playerPrefs">PlayerPrefs로 저장된 메인 발키리의 ID</param>
//    private void CheckMainValkyrie(string playerPrefs)
//    {
//        Valkyrie valkyrie;

//        // 만약 없다면,
//        if (string.IsNullOrEmpty(playerPrefs))
//        {
//            // 발키리의 목록 중 무작위로 한 명을 골라, 메인 발키리로 지정합니다.
//            valkyrie = GetRandomValkyrie();
//        }
//        // 만약 있다면,
//        else
//        {
//            // 그 발키리를 메인 발키리로 지정합니다.
//            valkyrie = DataManager.Instance.ValkyrieList[playerPrefs];
//        }

//        SetMainValkyrie(valkyrie);
//    }

//    /// <summary>
//    /// 발키리의 목록 중 한 명을 무작위로 반환합니다.
//    /// </summary>
//    /// <returns>무작위로 선택된 발키리</returns>
//    private Valkyrie GetRandomValkyrie()
//    {
//        // 데이터 매니저로부터 발키리의 목록을 가져옵니다.
//        Dictionary<string, Valkyrie> valkyrieList = DataManager.Instance.ValkyrieList;

//        // 발키리를 무작위로 한 명 고릅니다.
//        Valkyrie randomValkyrie = valkyrieList.ElementAt(Random.Range(0, valkyrieList.Count)).Value;

//        // 고른 발키리를 반환합니다.
//        return randomValkyrie;
//    }

//    /// <summary>
//    /// 메인 발키리를 지정합니다.
//    /// </summary>
//    /// <param name="valkyrie">메인으로 지정할 발키리</param>
//    public void SetMainValkyrie(Valkyrie valkyrie)
//    {
//        // 우선, 이미 지정되어 있는 메인 발키리를 제거합니다. (매개변수로 자식을 보내되, 자기 자신인 부모는 제외합니다.)
//        DestroyChildren(GetComponentsInChildren<Transform>().Skip(1).ToArray());

//        // 매개변수로 받은 발키리를 메인 발키리로 지정합니다.
//        Instantiate(valkyrie.PrefabModel, transform);

//        // 이 값을 기억시켜, 게임을 다시 실행했을 때 마지막으로 지정한 발키리를 자동으로 선택하도록 합니다.
//        PlayerPrefs.SetString("MainValkyrie", valkyrie.Valkyrie_ID);
//    }

//    /// <summary>
//    /// 자식 게임 오브젝트를 전부 파괴합니다.
//    /// </summary>
//    /// <param name="children">자식 목록</param>
//    private void DestroyChildren(Transform[] children)
//    {
//        // 자식을 순회하면서,
//        foreach (Transform child in children)
//        {
//            // 자신을 파괴합니다.
//            Destroy(child.gameObject);
//        }
//    }

//    #endregion 커스텀 함수
//}
