using System;
using System.Collections.Generic;

namespace Assets.Project.Code.Runtime.Logic.Fsm
{
    public class StateMachine<TInitializer>
    {
        private const int DefaultCollectionSize = 5;

        private readonly Dictionary<Type, IState<TInitializer>> states =
            new Dictionary<Type, IState<TInitializer>>(DefaultCollectionSize);

        private readonly List<Transition<TInitializer>> anyTransitions =
            new List<Transition<TInitializer>>(DefaultCollectionSize);

        private readonly List<Transition<TInitializer>> transitions =
            new List<Transition<TInitializer>>(DefaultCollectionSize);

        public StateMachine() { }

        public StateMachine(params IState<TInitializer>[] states) =>
            AddStates(states);

        public bool TransitionsEnabled { get; set; } = true;
        public bool HasCurrentState { get; private set; }
        public bool HasStatesBeenAdded { get; private set; }

        public IState<TInitializer> CurrentState { get; private set; }
        public Transition<TInitializer> CurrentTransition { get; private set; }

        public void AddStates(params IState<TInitializer>[] states)
        {
#if DEBUG
            if (HasStatesBeenAdded)
                throw new Exception("States have already been added!");

            if (states.Length == 0)
                throw new Exception("You are trying to add an empty state array!");
#endif
            foreach (var state in states)
            {
                AddState(state);
            }

            HasStatesBeenAdded = true;
        }

        public TState GetState<TState>() where TState : IState<TInitializer>
        {
            return (TState)GetState(typeof(TState));
        }

        public void SetState<TState>() where TState : IState<TInitializer>
        {
            SetState(typeof(TState));
        }

        public void AddTransition<TStateFrom, TStateTo>(Func<bool> condition)
            where TStateFrom : IState<TInitializer>
            where TStateTo : IState<TInitializer>
        {
#if DEBUG
            if (condition == null)
                throw new ArgumentNullException(nameof(condition));
#endif
            var stateFrom = GetState(typeof(TStateFrom));
            var stateTo = GetState(typeof(TStateTo));

            transitions.Add(new Transition<TInitializer>(stateFrom, stateTo, condition));
        }

        public void AddAnyTransition<TStateTo>(Func<bool> condition)
            where TStateTo : IState<TInitializer>
        {
#if DEBUG
            if (condition == null)
                throw new ArgumentNullException(nameof(condition));
#endif
            var stateTo = GetState(typeof(TStateTo));

            anyTransitions.Add(new Transition<TInitializer>(null, stateTo, condition));
        }

        public void SetStateByTransitions()
        {
            CurrentTransition = GetTransition();

            if (CurrentTransition == null)
                return;

            if (CurrentState == CurrentTransition.To)
                return;

            SetState(CurrentTransition.To);
        }

        public void Run()
        {
            if (TransitionsEnabled)
                SetStateByTransitions();

            if (HasCurrentState)
                CurrentState.OnRun();
        }

        private void AddState(IState<TInitializer> state)
        {
#if DEBUG
            if (state == null)
                throw new ArgumentNullException(nameof(state));
#endif
            Type stateType = state.GetType();
#if DEBUG
            if (states.ContainsKey(stateType))
                throw new Exception($"You are trying to add the same state twice! The <{stateType}> already exists!");
#endif
            states.Add(stateType, state);
        }

        private IState<TInitializer> GetState(Type type)
        {
            if (states.TryGetValue(type, out var state))
            {
                return state;
            }

            throw new Exception($"You didn't add the <{type}> state!");
        }

        private void SetState(Type type)
        {
            var state = GetState(type);

            SetState(state);
        }

        private void SetState(IState<TInitializer> state)
        {
            if (HasCurrentState)
            {
                CurrentState.OnExit();
            }

            CurrentState = state;
            HasCurrentState = true;
            CurrentState.OnEnter();
        }

        private Transition<TInitializer> GetTransition()
        {
            for (var i = 0; i < anyTransitions.Count; i++)
            {
                if (anyTransitions[i].Condition.Invoke())
                {
                    return anyTransitions[i];
                }
            }

            for (var i = 0; i < transitions.Count; i++)
            {
                if (transitions[i].From != CurrentState)
                {
                    continue;
                }

                if (transitions[i].Condition.Invoke())
                {
                    return transitions[i];
                }
            }

            return null;
        }
    }
}