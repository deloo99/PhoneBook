using PhoneBook.Classes;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace PhoneBook.Repositorys
{
    public static class SqlRepository
    {
        private static bool? _hasAdministratorRights;

        public static bool HasAdministratorRights
            => _hasAdministratorRights ??= CheckingAdministratorRights();

        public static List<Employee> GetEmployeeList()
        {
            using var connection = new SqlConnection(@"server=apptestsrv.tsm.local;database=PhoneBook;User ID=PhoneBookView;Password=PhoneBookView;");
            connection.Open();
            using var reader = new SqlCommand("SELECT * FROM Employee", connection).ExecuteReader();

            var result = new List<Employee>();
            while (reader.Read())
                result.Add(new Employee(reader));

            return result;
        }
        public static void UpdateEmployeeList(List<Employee> createEmployeeList, List<Employee> updateEmployeeList, List<Employee> deleteEmployeeList)
        {
            static string NormalizeString(string source)
                => string.IsNullOrEmpty(source) ? "NULL" : "'" + source + "'";

            static string NormalizeBool(bool source)
                => source ? "1" : "0";

            static string BuildCreateQuery(Employee employee)
                => $"INSERT INTO Employee (SID, Name, Surname, FullName, Phone, IpPhone, MPersonPhone, СorporatPhone, Mail, Role, Department" +
                $", Company, Description, City, Office, PostalCode, Street, Manager, IsShow, IsDispose) " +
                $"VALUES ({NormalizeString(employee.SID)}" +
                $", {NormalizeString(employee.Name)}" +
                $", {NormalizeString(employee.Surname)}" +
                $", {NormalizeString(employee.FullName)}" +
                $", {NormalizeString(employee.Phone)}" +
                $", {NormalizeString(employee.IpPhone)}" +
                $", {NormalizeString(employee.MPersonPhone)}" +
                $", {NormalizeString(employee.СorporatePhone)}" +
                $", {NormalizeString(employee.Mail)}" +
                $", {NormalizeString(employee.Role)}" +
                $", {NormalizeString(employee.Department)}" +
                $", {NormalizeString(employee.Company)}" +
                $", {NormalizeString(employee.Description)}" +
                $", {NormalizeString(employee.City)}" +
                $", {NormalizeString(employee.Office)}" +
                $", {NormalizeString(employee.PostalCode)}" +
                $", {NormalizeString(employee.Street)}" +
                $", {NormalizeString(employee.Manager)}" +
                $", {NormalizeBool(employee.IsShow)}" +
                $", {NormalizeBool(employee.IsDispose)});";

            static string BuildUpdateQuery(Employee employee)
                => $"UPDATE Employee SET SID = {NormalizeString(employee.SID)}" +
                $", Name = {NormalizeString(employee.Name)}" +
                $", Surname = {NormalizeString(employee.Surname)}" +
                $", FullName = {NormalizeString(employee.FullName)}" +
                $", Phone = {NormalizeString(employee.Phone)}" +
                $", IpPhone = {NormalizeString(employee.IpPhone)}" +
                $", MPersonPhone = {NormalizeString(employee.MPersonPhone)}" +
                $", СorporatPhone = {NormalizeString(employee.СorporatePhone)}" +
                $", Mail = {NormalizeString(employee.Mail)}" +
                $", Role = {NormalizeString(employee.Role)}" +
                $", Department = {NormalizeString(employee.Department)}" +
                $", Company = {NormalizeString(employee.Company)}" +
                $", Description = {NormalizeString(employee.Description)}" +
                $", City = {NormalizeString(employee.City)}" +
                $", Office = {NormalizeString(employee.Office)}" +
                $", PostalCode = {NormalizeString(employee.PostalCode)}" +
                $", Street = {NormalizeString(employee.Street)}" +
                $", Manager = {NormalizeString(employee.Manager)}" +
                $", IsShow = {NormalizeBool(employee.IsShow)}" +
                $", IsDispose = {NormalizeBool(employee.IsDispose)}" +
                $" WHERE ID = {employee.ID};";

            static string BuildDeleteQuery(Employee employee)
                => $"DELETE Employee WHERE ID = {employee.ID};";

            if (createEmployeeList.Count > 0 || updateEmployeeList.Count > 0 || deleteEmployeeList.Count > 0)
            {
                var query = string.Join("\r\n", deleteEmployeeList.Select(x => BuildDeleteQuery(x))
                      .Concat(updateEmployeeList.Select(x => BuildUpdateQuery(x)))
                      .Concat(createEmployeeList.Select(x => BuildCreateQuery(x))));

                using var connection = new SqlConnection(@"server=apptestsrv;database=PhoneBook;Integrated Security=True");
                connection.Open();
                var count = new SqlCommand(query, connection).ExecuteNonQuery();
            }
        }

        private static bool CheckingAdministratorRights()
        {
            try
            {
                using var connection = new SqlConnection(@"server=apptestsrv;database=PhoneBook;Integrated Security=True");
                connection.Open();

                var query = @"WITH CTE_Roles (role_principal_id) AS (
SELECT role_principal_id FROM sys.database_role_members WHERE member_principal_id = USER_ID() UNION ALL
SELECT drm.role_principal_id FROM sys.database_role_members drm INNER JOIN CTE_Roles CR ON drm.member_principal_id = CR.role_principal_id)
SELECT USER_NAME(role_principal_id) RoleName FROM CTE_Roles UNION ALL SELECT 'public' ORDER BY RoleName;";
                var reader = new SqlCommand(query, connection).ExecuteReader();

                while (reader.Read())
                    if (reader.GetString(0) == "db_owner")
                        return true;
            }
            catch { }

            return false;
        }
    }
}
