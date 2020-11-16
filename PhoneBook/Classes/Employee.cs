using System;
using System.Data.SqlClient;
using System.DirectoryServices;
using System.Linq;

namespace PhoneBook.Classes
{
    public class Employee
    {
        private class SpAtribute
        {
            public SpAtribute(string source)
            {
                int delimiter = source.IndexOf('=');
                if (delimiter > 0)
                {
                    int vStart = source.IndexOf("\"", delimiter) + 1;
                    if (vStart > 0)
                    {
                        int vEnd = source.IndexOf("\"", vStart);
                        if (vEnd > 0)
                        {
                            Name = source.Substring(0, delimiter).Trim();
                            Value = source.Substring(vStart, vEnd - vStart);
                        }
                    }
                }
            }

            public string Name { get; set; }
            public string Value { get; set; }
            public bool IsEmpty { get => string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Value); }
        }

        public Employee(SearchResult adEmployeeSource)
        {
            string GetPropertyAsString(string propertyName)
            {
                var value = adEmployeeSource.Properties[propertyName];
                return value.Count > 0 ? (string)value[0] : null;
            }
            int GetPropertyAsInt(string propertyName)
            {
                var value = adEmployeeSource.Properties[propertyName];
                return value.Count > 0 ? (int)value[0] : 0;
            }
            string GetPropertySID()
            {
                var bytes = adEmployeeSource.Properties["objectsid"];
                return bytes.Count > 0 ? new System.Security.Principal.SecurityIdentifier((byte[])bytes[0], 0).ToString() : null;
            }


            SID = GetPropertySID();
            Name = GetPropertyAsString("givenName");
            Surname = GetPropertyAsString("sn");
            FullName = GetPropertyAsString("displayName");
            Phone = GetPropertyAsString("telephoneNumber");
            IpPhone = GetPropertyAsString("ipPhone");
            MPersonPhone = GetPropertyAsString("pager");
            СorporatPhone = GetPropertyAsString("mobile");
            Mail = GetPropertyAsString("mail");
            Role = GetPropertyAsString("title");
            Department = GetPropertyAsString("department");
            Company = GetPropertyAsString("company");
            Description = GetPropertyAsString("description");
            City = GetPropertyAsString("l");
            Office = GetPropertyAsString("physicalDeliveryOfficeName");
            PostalCode = GetPropertyAsString("postalCode");
            Street = GetPropertyAsString("streetAddress");
            Manager = GetPropertyAsString("manager");
            IsDispose = (GetPropertyAsInt("userAccountControl") & 2) > 0;
            IsShow = !IsShow;
        }
        public Employee(SqlDataReader sqlReader)
        {
            string GetStringOrNull(int num)
                => sqlReader[num] == DBNull.Value ? null : (string)sqlReader[num];

            ID = sqlReader.GetInt32(0);
            SID = sqlReader.GetString(1);
            Name = GetStringOrNull(2);
            Surname = GetStringOrNull(3);
            FullName = GetStringOrNull(4);
            Phone = GetStringOrNull(5);
            IpPhone = GetStringOrNull(6);
            MPersonPhone = GetStringOrNull(7);
            СorporatPhone = GetStringOrNull(8);
            Mail = GetStringOrNull(9);
            Role = GetStringOrNull(10);
            Department = GetStringOrNull(11);
            Company = GetStringOrNull(12);
            Description = GetStringOrNull(13);
            City = GetStringOrNull(14);
            Office = GetStringOrNull(15);
            PostalCode = GetStringOrNull(16);
            Street = GetStringOrNull(17);
            Manager = GetStringOrNull(18);
            IsDispose = sqlReader.GetBoolean(19);
            IsShow = sqlReader.GetBoolean(20);
        }
        public Employee(string spEmployeeSource)
        {
            var atributes = spEmployeeSource
                .Split(new string[] { "ows_" }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => new SpAtribute(x)).Where(x => !x.IsEmpty).ToArray();

            string GetPropertyAsString(string name)
                => atributes.FirstOrDefault(x => x.Name == name)?.Value ?? null;
            int GetPropertyAsInt(string name)
                => int.TryParse(atributes.FirstOrDefault(x => x.Name == name)?.Value ?? string.Empty, out int value) ? value : 0;

            ID = GetPropertyAsInt("ID");
            SID = GetPropertyAsString("SID");
            Name = GetPropertyAsString("Name");
            Surname = GetPropertyAsString("Surname");
            FullName = GetPropertyAsString("FullName");
            Phone = GetPropertyAsString("ph");
            IpPhone = GetPropertyAsString("ph_ip");
            MPersonPhone = GetPropertyAsString("ph_MPerson");
            СorporatPhone = GetPropertyAsString("ph_MCorp");
            Mail = GetPropertyAsString("Mail");
            Role = GetPropertyAsString("Role");
            Department = GetPropertyAsString("Department")?.Replace("&quot;", "\"") ?? null;
            Company = GetPropertyAsString("Company")?.Replace("&quot;", "\"") ?? null;
            Description = GetPropertyAsString("Description");
            City = GetPropertyAsString("City");
            Office = GetPropertyAsString("Office");
            PostalCode = GetPropertyAsString("PostalCode");
            Street = GetPropertyAsString("Street");
            Manager = GetPropertyAsString("Manager");
            IsDispose = GetPropertyAsInt("i_dis") > 0;
            IsShow = GetPropertyAsInt("i_show") > 0;
        }


        public bool Contains(string findText)
            => (FullName?.ToLower().Contains(findText) ?? false)
            || (Department?.ToLower().Contains(findText) ?? false)
            || (Phone?.ToLower().Contains(findText) ?? false)
            || (IpPhone?.ToLower().Contains(findText) ?? false)
            || (MPersonPhone?.ToLower().Contains(findText) ?? false)
            || (СorporatPhone?.ToLower().Contains(findText) ?? false)
            || (Mail?.ToLower().Contains(findText) ?? false)
            || (Role?.ToLower().Contains(findText) ?? false)
            || (Company?.ToLower().Contains(findText) ?? false);

        public int ID { get; set; }
        public string SID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string IpPhone { get; set; }
        public string MPersonPhone { get; set; }
        public string СorporatPhone { get; set; }
        public string Mail { get; set; }
        public string Role { get; set; }
        public string Department { get; set; }
        public string Company { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Office { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string Manager { get; set; }
        public bool IsDispose { get; set; }
        public bool IsShow { get; set; }

        public bool EqualsWithoutID(object obj)
        {
            return obj is Employee employee
                && employee.SID == SID
                && employee.Name == Name
                && employee.Surname == Surname
                && employee.FullName == FullName
                && employee.Phone == Phone
                && employee.IpPhone == IpPhone
                && employee.MPersonPhone == MPersonPhone
                && employee.СorporatPhone == СorporatPhone
                && employee.Mail == Mail
                && employee.Role == Role
                && employee.Department == Department
                && employee.Company == Company
                && employee.Description == Description
                && employee.City == City
                && employee.Office == Office
                && employee.PostalCode == PostalCode
                && employee.Street == Street
                && employee.Manager == Manager;
        }
        public override string ToString() => FullName;
    }
}
