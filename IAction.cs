namespace FilPasRouge {
    public interface IAction

    {

        string Name { get; }

        string Description { get; }

        void Action (string[] parameters);

    }
}