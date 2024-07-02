// 플레이어로서의 캐릭터가 취할 상태를 정의한다.
public interface IPlayerState
{
    void Enter();
    void Execute();
    void Exit();
}