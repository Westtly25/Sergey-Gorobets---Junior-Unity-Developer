using System;

namespace Assets.Project.Code.Runtime.Logic.Fsm
{
    public class Transition<TInitializer>
    {
        public readonly IState<TInitializer> From;
        public readonly IState<TInitializer> To;
        public readonly Func<bool> Condition;

        public Transition(IState<TInitializer> from, IState<TInitializer> to, Func<bool> condition)
        {
            From = from;
            To = to;
            Condition = condition;
        }
    }
}