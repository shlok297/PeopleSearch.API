using System.Collections.Generic;
using System.Threading.Tasks;
using PeopleSearch.API.Models;


namespace PeopleSearch.API.Interface
{
    public interface IPeopleRepository
    {
        Task<List<People>> GetOne(string name);
        
        void Add(People people);
    
        Task SaveChanges();
    }
    
}