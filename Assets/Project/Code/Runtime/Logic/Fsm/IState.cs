namespace Assets.Project.Code.Runtime.Logic.Fsm
{
    public interface IState<out TInitializer>
    {
        TInitializer Initializer { get; }
        void OnEnter();
        void OnRun();
        void OnExit();
    }
}