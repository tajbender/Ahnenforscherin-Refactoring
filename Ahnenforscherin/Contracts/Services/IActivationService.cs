using System.Threading.Tasks;



namespace Ahnenforscherin.Contracts.Services;

public interface IActivationService
{
    Task ActivateAsync(object activationArgs);
}
