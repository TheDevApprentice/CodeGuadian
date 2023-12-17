using CodeGuardian.DOMAIN.Entity.Application;
using CodeGuardian.DOMAIN.Entity.Client.OrganisationEntity;
using CodeGuardian.DOMAIN.Entity.Users.Dev;
using CodeGuardian.DOMAINE.Entity;
using CodeGuardian.DOMAINE.Interfaces;

namespace CodeGuardian.DOMAINE.Services
{
    public class SuperAdminService : ISuperAdministratorService
    {
        private IAdministratorRepo _administratorRepo;
        private IDevRepo _userRepo;

        private IApplicationRepo _applicationRepo;
        private IOrganisationRepo _orgnaisationRepo;
        private ILicenceRepo _licenceRepo;
        private IPermissionRepo _permissionRepo;

        public SuperAdminService(IAdministratorRepo administratorRepo,
            IApplicationRepo applicationRepo,
            ILicenceRepo licenceRepo,
            IPermissionRepo permissionRepo,
            IDevRepo userRepo,
            IOrganisationRepo orgnaisationRepo)
        {
            this._administratorRepo = administratorRepo;
            this._applicationRepo = applicationRepo;
            this._permissionRepo = permissionRepo;
            this._licenceRepo = licenceRepo;
            this._userRepo = userRepo;
            this._orgnaisationRepo = orgnaisationRepo;
        }

        public Dev AddAnUser(Dev userToAdd)
        {
            if (string.IsNullOrWhiteSpace(userToAdd.FirstName) ||
                string.IsNullOrWhiteSpace(userToAdd.LastName))
            {
                throw new ArgumentException("FirstName or LastName cannot be empty or whitespace.", nameof(userToAdd));

            }

            return _administratorRepo.AddADevelopper(userToAdd);
        }

        Dev ISuperAdministratorService.CreateOrganisationDev(Guid organisationId)
        {
            throw new NotImplementedException();
        }

        bool ISuperAdministratorService.DeleteOrganisation(Guid organisationId)
        {
            throw new NotImplementedException();
        }

        bool ISuperAdministratorService.DeleteOrganisationApp(Guid organisationId, Guid appId)
        {
            throw new NotImplementedException();
        }

        bool ISuperAdministratorService.DeleteOrganisationDev(Guid organisationId, Guid devId)
        {
            throw new NotImplementedException();
        }

        List<Application> ISuperAdministratorService.GetAllApplication()
        {
            return _applicationRepo.GetAllApplication();
        }

        List<License> ISuperAdministratorService.GetAllLicenses()
        {
            return _licenceRepo.GetAllLicenses();
        }

        List<Organisation> ISuperAdministratorService.GetAllOrganisations()
        {
            throw new NotImplementedException();
        }

        List<Permission> ISuperAdministratorService.GetAlPermissions()
        {
            return _permissionRepo.GetAlPermissions();
        }

        Dev ISuperAdministratorService.GetAnUserByName(string username)
        {
            if (username == "")
            {
                throw new ArgumentException("Please enter a valid name, no user has been found.");
            }

            return _userRepo.GetAnUserByName(username);
        }

        Application ISuperAdministratorService.GetApplicationById(Guid id)
        {
            return _applicationRepo.GetApplicationById(id);
        }

        License ISuperAdministratorService.GetLicenseById(Guid licenceId)
        {
            return _licenceRepo.GetLicenseById(licenceId);
        }

        Organisation ISuperAdministratorService.GetOrganisationById(Guid organisationId)
        {
            return _orgnaisationRepo.GetOrganisationById(organisationId);
        }

        Dev ISuperAdministratorService.GetOrganisationDevById(Guid organisationId, Guid devId)
        {
            throw new NotImplementedException();
        }

        List<Dev> ISuperAdministratorService.GetOrganisationDevs(Guid organisationId)
        {
            throw new NotImplementedException();
        }

        Permission ISuperAdministratorService.GetPermissionById(int permissionId)
        {
            return _permissionRepo.GetPermissionById(permissionId);
        }

        Organisation ISuperAdministratorService.ModifyOrganisation(Guid organisationId)
        {
            throw new NotImplementedException();
        }

        Application ISuperAdministratorService.ModifyOrganisationApp(Guid organisationId, Guid appId)
        {
            throw new NotImplementedException();
        }

        Dev ISuperAdministratorService.ModifyOrganisationDev(Guid organisationId, Guid devId)
        {
            throw new NotImplementedException();
        }

        Application ISuperAdministratorService.RegisterAppForOrganisation(Guid organisationId)
        {
            throw new NotImplementedException();
        }
    }
}