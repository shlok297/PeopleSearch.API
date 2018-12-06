using System.Collections.Generic;
using System.Threading.Tasks;
using PeopleSearch.API.Models;


namespace PeopleSearch.API.Interface
{
    public interface IPeopleRepository
    {
        Task<List<User>> GetUsers(string name);
        
        void Add(User user);
    
        Task SaveChanges();
    }
    
}