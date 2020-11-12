using PhoneBook.Classes;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;

namespace PhoneBook.Repositorys
{
    public static class ADRepository
    {
        public static List<Employee> GetEmployeeList()
        {
            static SearchResult[] SearchInformation(string filter, string[] properties)
            {
                using var entry = new DirectoryEntry("LDAP://tsm.local");
                using var searcher = new DirectorySearcher(entry)
                {
                    PageSize = 10000,
                    SizeLimit = 10000,
                    Filter = filter,
                };
                searcher.PropertiesToLoad.AddRange(properties);
                return searcher.FindAll().Cast<SearchResult>().ToArray();
            }

            return SearchInformation("(&(objectClass=User))", new string[] { })
                .Select(x => new Employee(x)).Where(x => x.IsShow && !x.IsDispose && !string.IsNullOrEmpty(x.Department)
                      && !string.IsNullOrEmpty(x.Company)).ToList();
        }
    }
}
