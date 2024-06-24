interface IPlayerState // 플레이어로서의 캐릭터가 취할 상태를 정의한다.
{
    void Enter();
    void Execute();
    void Exit();
}

// 플레이어로서의 캐릭터가 취할 상태를 다루는 최상위 클래스
public class BasePlayerState : IPlayerState
{
    public virtual void Enter() { }

    public virtual void Execute() { }

    public virtual void Exit() { }
}