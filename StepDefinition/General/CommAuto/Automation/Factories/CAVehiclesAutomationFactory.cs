using BiBerkLOB.Pages.CommAuto;
using BiBerkLOB.Pages.Other;
using BiBerkLOB.StepDefinition.General.CommAuto.Automation.Models;
using HitachiQA;

namespace BiBerkLOB.StepDefinition.General.CommAuto.Automation.Factories;

public class CAVehiclesAutomationFactory : IAutomationFactory<CAVehiclesAutomation>
{
    private readonly CASummaryObject _caSummaryObject;
    private readonly VehicleCountObj _vehicleCount;
    private readonly ApolloGateway _apolloGateway;

    public CAVehiclesAutomationFactory(CASummaryObject caSummaryObject, VehicleCountObj vehicleCount, ApolloGateway apolloGateway)
    {
        _caSummaryObject = caSummaryObject;
        _vehicleCount = vehicleCount;
        _apolloGateway = apolloGateway;
    }

    public CAVehiclesAutomation CreateAutomation()
    {
        return new CAVehiclesAutomation(_caSummaryObject, _vehicleCount, _apolloGateway);
    }
}