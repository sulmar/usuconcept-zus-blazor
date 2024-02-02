using Fluxor;

namespace BlazorWebAssemblySakilaApp.Features.Counter;

public record CounterState(int CurrentCount);

public class CounterFeature : Feature<CounterState>
{
    public override string GetName() => "Counter";
    protected override CounterState GetInitialState() => new (1);
}

public record CounterIncrementAction;

// public record CounterIncrementByAction(int Value);

public static class CounterReducers
{
    [ReducerMethod(typeof(CounterIncrementAction))]
    public static CounterState OnIncrement(CounterState state)
    {
        return new CounterState(state.CurrentCount + 1);
    }

}