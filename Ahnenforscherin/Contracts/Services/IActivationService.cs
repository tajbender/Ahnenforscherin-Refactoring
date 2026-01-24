using System.Threading.Tasks;



namespace electrifier.Contracts.Services;

public interface IActivationService
{
    Task ActivateAsync(object activationArgs);
}
