using BlazorWebAssemblySakilaApp.Services;
using Fluxor;
using Sakila.Model;

namespace BlazorWebAssemblySakilaApp.Features.Rentals;

public record RentalsState(bool IsLoading, List<Rental> Rentals);


public class RentalsFeature : Feature<RentalsState>
{
    public override string GetName() => "Rentals";
    protected override RentalsState GetInitialState() => new(false, Enumerable.Empty<Rental>().ToList());
}

public record FetchRentalsAction;
public record FetchRentalsResultAction(List<Rental> Rentals);

public class Effects
{
    private readonly ApiRentalService Api;

    public Effects(ApiRentalService api)
    {
        Api = api;
    }

    [EffectMethod]
    public async Task HandleFetchRentalAction(FetchRentalsAction action, IDispatcher dispatcher)
    {
        var rentals = await Api.GetAllAsync();

        if (rentals is not null)
        {
            dispatcher.Dispatch(new FetchRentalsResultAction(rentals));
        }
    }
}

public static class Reducers
{
    [ReducerMethod]
    public static RentalsState OnFetchRentalsAction(RentalsState state, FetchRentalsAction action) => new RentalsState(true, null);
   
    [ReducerMethod]
    public static RentalsState OnFetchRentalsResultAction(RentalsState state, FetchRentalsResultAction action) => new RentalsState(false, action.Rentals);
}