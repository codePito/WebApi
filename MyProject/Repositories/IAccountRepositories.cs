using Microsoft.AspNetCore.Identity;
using MyProject.Models;

namespace MyProject.Repositories
{
    public interface IAccountRepositories
    {
        public Task<IdentityResult> SignUpAsync(SignUpModel model);
        public Task<string> SignInAsync(SignInModel model);
    }
}
