namespace Enemy
{
    public class HerrscherOfDominanceMinion : Monster
    {
        private void Start()
        {
            Data = new();

            InitializeStatus();
        }

        private void InitializeStatus()
        {
            Data.HP = 10000000;
            Data.IsHit = false;
            Data.AttackRange = 3.0f;
            Data.ChaseRange = 10000.0f;
        }
    }

}
