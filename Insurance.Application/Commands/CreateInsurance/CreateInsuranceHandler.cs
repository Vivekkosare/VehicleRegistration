using MediatR;

namespace Insurance.Application.Commands.CreateInsurance;

public class CreateInsuranceHandler : IRequestHandler<CreateInsuranceCommand, Insurance.Domain.Entities.Insurance>
{
    public Task<Domain.Entities.Insurance> Handle(CreateInsuranceCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
