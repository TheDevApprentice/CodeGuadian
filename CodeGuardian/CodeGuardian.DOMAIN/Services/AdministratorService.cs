using CodeGuardian.DOMAINE.Entity;
using CodeGuardian.DOMAINE.Interfaces;

namespace CodeGuardian.DOMAINE.Services
{
    public class AdministratorService : IAdministratorService
    {
        private IAdministratorRepo _administratorRepo;


        public AdministratorService(IAdministratorRepo administratorRepo)
        {
            this._administratorRepo = administratorRepo;
        }

        public User AddAnUser(User userToAdd)
        {
            if (string.IsNullOrWhiteSpace(userToAdd.FirstName) ||
                string.IsNullOrWhiteSpace(userToAdd.LastName))
            {
                throw new ArgumentException("FirstName or LastName cannot be empty or whitespace.", nameof(userToAdd));

            }

            return _administratorRepo.AddAnuser(userToAdd);
        }
    }
}