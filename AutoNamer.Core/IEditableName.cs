namespace AutoNamer.Core
{
    public interface IEditableName
    {
        string CurrentName { get; }
        string NewName { get; set; }

        void SaveNew();
    }
}