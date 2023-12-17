using CodeGuardian.DOMAIN.Entity.Application;
using CodeGuardian.DOMAIN.Entity.Client.OrganisationEntity;
using CodeGuardian.DOMAIN.Entity.Users.Dev;
using CodeGuardian.DOMAINE.Entity;
using CodeGuardian.DOMAINE.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CodeGuardian.INFRA.Repos
{
    public class SuperAdminRepo : ISuperAdministratorRepo
    {
        private CodeGuardianDbContext _dbCodeGuardian;

        public SuperAdminRepo(CodeGuardianDbContext dbCodeGuardian)
        {
            this._dbCodeGuardian = dbCodeGuardian ?? throw new ArgumentNullException(nameof(dbCodeGuardian));
        }

        public Dev AddADevelopper(Dev userToAdd)
        {
            if (userToAdd == null)
            {
                throw new ArgumentNullException(nameof(userToAdd));
            }

            Dev newuser = _dbCodeGuardian.Users.Add(new Dev()
            {
                FirstName = userToAdd.FirstName,
                LastName = userToAdd.LastName
            }).Entity;

            _dbCodeGuardian.SaveChanges();

            return newuser;
        }

        public List<Application> GetAllApplication()
        {
            return _dbCodeGuardian.Applications.ToList();
        }

        public List<License> GetAllLicenses()
        {
            return _dbCodeGuardian.Licenses.ToList();
        }

        public List<Organisation> GetAllOrganisations()
        {
            return _dbCodeGuardian.Organisations.ToList();
        }

        public List<Dev> GetAllUsers()
        {
            return _dbCodeGuardian.Users.Include(u => u.Permissions).ToList();
        }

        public List<Permission> GetAlPermissions()
        {
            return _dbCodeGuardian.Permissions.ToList();
        }

        public Dev GetAnUserByName(string username)
        {
            Dev user = _dbCodeGuardian.Users.FirstOrDefault(user => user.FirstName == username);

            if (user == null)
            {
                return null;
            }

            return user;
        }

        public Application GetApplicationById(int id)
        {
            return _dbCodeGuardian.Applications.FirstOrDefault(licence => licence.Id == id);
        }

        public License GetLicenseById(int licenceId)
        {
            return _dbCodeGuardian.Licenses.FirstOrDefault(licence => licence.Id == licenceId);
        }

        public Organisation GetOrganisationById(Guid organisationId)
        {
            return _dbCodeGuardian.Organisations.FirstOrDefault(org => org.Uuid == organisationId);
        }

        public Dev GetOrganisationDevById(Guid organisationId, Guid devId)
        {
            var user = _dbCodeGuardian.Users
                 .Include(u => u.Permissions)
                 .FirstOrDefault(user => user.Uuid == devId && user.Uuid == organisationId);

            if (user != null)
            {
                return user;
            }

            return null;
        }

        public List<Dev> GetOrganisationDevs(Guid organisationId)
        {
            return _dbCodeGuardian.Users
                .Include(u => u.Permissions)
                .Where(user => user.Uuid == organisationId)
                .ToList();
        }

        public Permission GetPermissionById(int permissionId)
        {
            return _dbCodeGuardian.Permissions.FirstOrDefault(licence => licence.Id == permissionId);
        }

        public Dev GetUserByID(int id)
        {
            return _dbCodeGuardian.Users.FirstOrDefault(user => user.Id == id);
        }

        public bool ModifyOrganisation(Guid organisationId)
        {
            Organisation organisation = _dbCodeGuardian.Organisations.FirstOrDefault(org => org.Uuid == organisationId);

            if (organisation == null)
            {
                return false;
            }

            // Implémenter la logique de modification de l'organisation

            return true;
        }

        Dev ISuperAdministratorRepo.CreateOrganisationDev(Guid organisationId)
        {
            throw new NotImplementedException();
        }

        bool ISuperAdministratorRepo.DeleteOrganisation(Guid organisationId)
        {
            throw new NotImplementedException();
        }

        bool ISuperAdministratorRepo.DeleteOrganisationApp(Guid organisationId, Guid appId)
        {
            throw new NotImplementedException();
        }

        bool ISuperAdministratorRepo.DeleteOrganisationDev(Guid organisationId, Guid devId)
        {
            throw new NotImplementedException();
        }

        Application ISuperAdministratorRepo.GetApplicationById(Guid id)
        {
            throw new NotImplementedException();
        }

        License ISuperAdministratorRepo.GetLicenseById(Guid licenceId)
        {
            throw new NotImplementedException();
        }

        Organisation ISuperAdministratorRepo.ModifyOrganisation(Guid organisationId)
        {
            throw new NotImplementedException();
        }

        Application ISuperAdministratorRepo.ModifyOrganisationApp(Guid organisationId, Guid appId)
        {
            throw new NotImplementedException();
        }

        Dev ISuperAdministratorRepo.ModifyOrganisationDev(Guid organisationId, Guid devId)
        {
            throw new NotImplementedException();
        }

        Application ISuperAdministratorRepo.RegisterAppForOrganisation(Guid organisationId)
        {
            throw new NotImplementedException();
        }
    }
}
