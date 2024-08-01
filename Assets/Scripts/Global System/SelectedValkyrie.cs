public class ValkyrieSelector : Singleton<ValkyrieSelector>
{
    private Valkyrie _selectedValkyrie;

    public Valkyrie SelectedValkyrie
    {
        get => _selectedValkyrie;
        set => _selectedValkyrie = value;
    }
}
