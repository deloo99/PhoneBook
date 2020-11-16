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

            var employes = SearchInformation("(&(objectClass=User))", new string[] { }).Select(x => new Employee(x)).ToList();

            if (Properties.Settings.Default.ContactPriority)
            {
                var contacts = SearchInformation("(&(objectClass=Contact))", new string[] { })
                    .Select(x => new Employee(x)).Where(x => x.IsShow && !x.IsDispose && !string.IsNullOrEmpty(x.Department)
                        && !string.IsNullOrEmpty(x.Company));

                foreach (var contact in contacts)
                    if (employes.FirstOrDefault(y => contact.FullName == y.FullName) is Employee employee)
                    {
                        employes.Remove(employee);
                        contact.SID = employee.SID;
                        employes.Add(contact);
                    }
            }

            return employes.Where(x => x.IsShow && !x.IsDispose && !string.IsNullOrEmpty(x.Department)
                && !string.IsNullOrEmpty(x.Company)).ToList();
            //return SearchInformation("(&(objectClass=Contact))", new string[] { })
            //        .Select(x => new Employee(x)).Where(x => x.IsShow && !x.IsDispose && !string.IsNullOrEmpty(x.Department)
            //            && !string.IsNullOrEmpty(x.Company)).ToList(); 
        }

        public static void DD()
        {
            using var entry = new DirectoryEntry("LDAP://tsm.local");

        }
    }
}
