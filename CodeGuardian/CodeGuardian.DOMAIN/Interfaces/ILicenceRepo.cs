using CodeGuardian.DOMAINE.Entity;
namespace CodeGuardian.DOMAINE.Interfaces;

public interface ILicenceRepo
{
    List<License> GetAllLicenses();

    License GetLicenseById(Guid licenceId);

    License AddCreatedLicenceKey(License newLicence);
}