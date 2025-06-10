using MediatR;

namespace Insurance.Application.Commands.CreateInsurance;

public record CreateInsuranceCommand(Insurance.Domain.Entities.Insurance Insurance) : IRequest<Insurance.Domain.Entities.Insurance>
{
}
