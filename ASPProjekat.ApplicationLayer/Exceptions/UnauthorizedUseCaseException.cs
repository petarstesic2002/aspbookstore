using ASPProjekat.ApplicationLayer.UseCase;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASPProjekat.ApplicationLayer.Exceptions
{
    public class UnauthorizedUseCaseException : Exception
    {
        public UnauthorizedUseCaseException(IUseCase useCase, IUserUseCase actor)
            : base($"Actor with an id of {actor.Id} - {actor.RoleId} tried to execute {useCase.Name}.")
        {

        }
    }
}
