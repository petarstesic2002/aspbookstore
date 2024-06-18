using ASPProjekat.ApplicationLayer.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Implementation
{
    public class UserImplementation:IUserUseCase
    {
        public int Id {  get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int RoleId {  get; set; }
        public IEnumerable<int> AllowedUseCases { get; set; }
    }
    public class UnauthorizedUser : IUserUseCase
    {
        public int Id => 0;
        public string FirstName => "Unauthorized";
        public string LastName => "Unauthorized";
        public string Email => "/";
        public int RoleId => 0;
        public IEnumerable<int> AllowedUseCases { get; set; }
    }
}
