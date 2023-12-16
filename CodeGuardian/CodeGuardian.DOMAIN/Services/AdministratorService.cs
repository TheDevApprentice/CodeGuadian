using CodeGuardian.DOMAIN.Entity.Application;
using CodeGuardian.DOMAIN.Entity.Users.Dev;
using CodeGuardian.DOMAINE.Entity;
using CodeGuardian.DOMAINE.Interfaces;

namespace CodeGuardian.DOMAINE.Services
{
    public class AdministratorService : IAdministratorService
    {
        private IAdministratorRepo _administratorRepo;
        private IDevRepo _userRepo;

        private IApplicationRepo _applicationRepo;
        private ILicenceRepo _licenceRepo;
        private IPermissionRepo _permissionRepo;

        public AdministratorService(IAdministratorRepo administratorRepo,
            IApplicationRepo applicationRepo,
            ILicenceRepo licenceRepo,
            IPermissionRepo permissionRepo,
            IDevRepo userRepo)
        {
            this._administratorRepo = administratorRepo;
            this._applicationRepo = applicationRepo;
            this._permissionRepo = permissionRepo;
            this._licenceRepo = licenceRepo;
            this._userRepo = userRepo;
        }

        public Dev AddAnUser(Dev userToAdd)
        {
            if (string.IsNullOrWhiteSpace(userToAdd.FirstName) ||
                string.IsNullOrWhiteSpace(userToAdd.LastName))
            {
                throw new ArgumentException("FirstName or LastName cannot be empty or whitespace.", nameof(userToAdd));

            }

            return _administratorRepo.AddAnUser(userToAdd);
        }

        Dev IAdministratorService.AddAnUser(Dev userToAdd)
        {
            return _administratorRepo.AddAnUser(userToAdd);
        }

        List<Application> IAdministratorService.GetAllApplication()
        {
            return _applicationRepo.GetAllApplication();
        }

        List<License> IAdministratorService.GetAllLicenses()
        {
            return _licenceRepo.GetAllLicenses();
        }

        List<Dev> IAdministratorService.GetAllUsers()
        {
            return _userRepo.GetAllUsers();
        }

        List<Permission> IAdministratorService.GetAlPermissions()
        {
            return _permissionRepo.GetAlPermissions();
        }

        Dev IAdministratorService.GetAnUserByName(string username)
        {
            if (username == "")
            {
                throw new ArgumentException("Please enter a valid name, no user has been found.");
            }

            return _userRepo.GetAnUserByName(username);
        }

        Application IAdministratorService.GetApplicationById(Guid id)
        {
            return _applicationRepo.GetApplicationById(id);
        }

        License IAdministratorService.GetLicenseById(Guid licenceId)
        {
            return _licenceRepo.GetLicenseById(licenceId);
        }

        Permission IAdministratorService.GetPermissionById(int permissionId)
        {
            return _permissionRepo.GetPermissionById(permissionId);
        }

        Dev IAdministratorService.GetUserByID(int id)
        {
            if (_userRepo.GetUserByID((int)id) == null)
            {
                throw new ArgumentException("Please enter a valid id for the user");
            }

            return _userRepo.GetUserByID((int)id);
        }
    }
}