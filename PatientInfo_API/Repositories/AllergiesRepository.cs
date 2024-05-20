
using PatientInfo_API.Data;
using PatientInfo_API.Models;
using PatientInfo_API.Services;

public class AllergyRepository : IAllergiesServices
{
    private readonly AppDbContext _patientInformationContext;

    public AllergyRepository(AppDbContext patientInformationContext)
    {
        _patientInformationContext = patientInformationContext;
    }

    public async Task<List<Allergy>> getAllAllergies()
    {
        return _patientInformationContext.Allergies.ToList();
    }

    
}