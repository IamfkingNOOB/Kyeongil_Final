/// <summary>
/// 전투에 들어가기 전에, 필요한 정보들을 담아두기 위한 클래스입니다.
/// </summary>
public class PlayData : Singleton<PlayData>
{
    // 발키리 선택 화면에서 선택한 발키리
    public Valkyrie SelectedValkyrie { get; set; }


}