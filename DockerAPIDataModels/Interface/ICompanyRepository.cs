using DockerAPIDataModels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockerAPIDataModels.Interface
{
    public interface ICompanyRepository
    {
        //Define GetCopanies method
        public Task<IEnumerable<Company>> GetCompanies();

        public Task<Company> GetCompanyById(int id);

        public Task<Company> CreateCompany(Company company);

        public Task UpdateCompany(int id, Company company);
        
        public Task DeleteCompany(int id);

    }
}
