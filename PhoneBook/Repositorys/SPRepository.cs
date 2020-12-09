using PhoneBook.Classes;
using PhoneBook.SharePointLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation.Runspaces;
using System.Xml;

namespace PhoneBook.Repositorys
{
    public static class SPRepository
    {
        private static readonly Lists _spLists = new Lists { UseDefaultCredentials = true, Url = "http://srv-shpf01/_vti_bin/Lists.asmx" };

        public static List<Employee> GetEmployeeList()
        {
            return _spLists.GetListItems("GlobalList", null, null, null, "10000", null, null)["rs:data"].InnerXml
                .Split(new string[] { "\n   <z:row ", " />" }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => new Employee(x)).Where(x => x.ID > 0).ToList();
        }
        public static void UpdateEmployeeList(List<Employee> createEmployeeList, List<Employee> updateEmployeeList, List<Employee> deleteEmployeeList)
        {
            int __packageSize = 150;
            int __num = 0;
            int GetMethodNum()
                => __num < __packageSize ? ++__num : (__num = 1);

            string viewID = _spLists.GetListAndView("GlobalList", "").ChildNodes[1].Attributes["Name"].Value;

            string BuildCreateMethod(Employee employee)
                => $"<Method ID='{GetMethodNum()}' Cmd='New'>" +
                $"<Field Name='ID'>New</Field>" +
                $"<Field Name='SID'>{employee.SID}</Field>" +
                $"<Field Name='Name'>{employee.Name}</Field>" +
                $"<Field Name='Surname'>{employee.Surname}</Field>" +
                $"<Field Name='FullName'>{employee.FullName}</Field>" +
                $"<Field Name='Phone'>{employee.Phone}</Field>" +
                $"<Field Name='ph_ip'>{employee.IpPhone}</Field>" +
                $"<Field Name='ph_MPerson'>{employee.MPersonPhone}</Field>" +
                $"<Field Name='ph_MCorp'>{employee.СorporatePhone}</Field>" +
                $"<Field Name='Mail'>{employee.Mail}</Field>" +
                $"<Field Name='Role'>{employee.Role}</Field>" +
                $"<Field Name='Description'>{employee.Description?.Replace("\"", "&quot;") ?? null}</Field>" +
                $"<Field Name='Department'>{employee.Department?.Replace("\"", "&quot;") ?? null}</Field>" +
                $"<Field Name='Company'>{employee.Company?.Replace("\"", "&quot;") ?? null}</Field>" +
                $"<Field Name='City'>{employee.City}</Field>" +
                $"<Field Name='Office'>{employee.Office}</Field>" +
                $"<Field Name='PostalCode'>{employee.PostalCode}</Field>" +
                $"<Field Name='Street'>{employee.Street}</Field>" +
                $"<Field Name='Manager'>{employee.Manager}</Field>" +
                $"<Field Name='i_dis'>{(employee.IsDispose ? 1 : 0)}</Field>" +
                $"<Field Name='i_show'>{(employee.IsShow ? 1 : 0)}</Field>" +
                $"</Method>";
            string BuildUpdateMethod(Employee employee)
                => $"<Method ID='{GetMethodNum()}' Cmd='Update'>" +
                $"<Field Name='ID'>{employee.ID}</Field>" +
                $"<Field Name='SID'>{employee.SID}</Field>" +
                $"<Field Name='Name'>{employee.Name}</Field>" +
                $"<Field Name='Surname'>{employee.Surname}</Field>" +
                $"<Field Name='FullName'>{employee.FullName}</Field>" +
                $"<Field Name='Phone'>{employee.Phone}</Field>" +
                $"<Field Name='ph_ip'>{employee.IpPhone}</Field>" +
                $"<Field Name='ph_MPerson'>{employee.MPersonPhone}</Field>" +
                $"<Field Name='ph_MCorp'>{employee.СorporatePhone}</Field>" +
                $"<Field Name='Mail'>{employee.Mail}</Field>" +
                $"<Field Name='Role'>{employee.Role}</Field>" +
                $"<Field Name='Description'>{employee.Description?.Replace("\"", "&quot;") ?? null}</Field>" +
                $"<Field Name='Department'>{employee.Department?.Replace("\"", "&quot;") ?? null}</Field>" +
                $"<Field Name='Company'>{employee.Company?.Replace("\"", "&quot;") ?? null}</Field>" +
                $"<Field Name='City'>{employee.City}</Field>" +
                $"<Field Name='Office'>{employee.Office}</Field>" +
                $"<Field Name='PostalCode'>{employee.PostalCode}</Field>" +
                $"<Field Name='Street'>{employee.Street}</Field>" +
                $"<Field Name='Manager'>{employee.Manager}</Field>" +
                $"<Field Name='i_dis'>{(employee.IsDispose ? 1 : 0)}</Field>" +
                $"<Field Name='i_show'>{(employee.IsShow ? 1 : 0)}</Field>" +
                $"</Method>";
            string BuildDeleteMethod(Employee employee)
                => $"<Method ID='{GetMethodNum()}' Cmd='Delete'><Field Name='ID'>{employee.ID}</Field></Method>";
            XmlElement BuildBatchPocket(IEnumerable<string> methods)
            {
                var batchPocket = new XmlDocument().CreateElement("Batch");
                batchPocket.SetAttribute("OnError", "Continue");
                batchPocket.SetAttribute("ListVersion", "1");
                batchPocket.SetAttribute("ViewName", viewID);
                batchPocket.InnerXml = string.Join("", methods);
                return batchPocket;
            }

            if (createEmployeeList.Count > 0 || updateEmployeeList.Count > 0 || deleteEmployeeList.Count > 0)
            {
                deleteEmployeeList.Select(x => BuildDeleteMethod(x))
                    .Concat(updateEmployeeList.Select(x => BuildUpdateMethod(x)))
                    .Concat(createEmployeeList.Select(x => BuildCreateMethod(x)))
                    .Select((value, index) => (value, index)).GroupBy(x => x.index / __packageSize)
                    .Select(x => BuildBatchPocket(x.Select(y => y.value)))
                    .ToList().ForEach(x => _spLists.UpdateListItems("GlobalList", x));
                UpdateCompanyStructure();
            }
        }

        private static void UpdateCompanyStructure()
        {
            var login = Properties.Settings.Default.UserLogin;
            var password = Cryptography.DecryptPassword(Properties.Settings.Default.UserLogin, Properties.Settings.Default.UserPassword);

            using var runspace = RunspaceFactory.CreateRunspace(RunspaceConfiguration.Create());
            runspace.Open();
            using var pipeline = runspace.CreatePipeline(
                "$cred = (new-object -typename System.Management.Automation.PSCredential " +
                $"-argumentlist '{login}',(convertto-securestring '{password}' -asplaintext -force)); " +
                "Invoke-Command -ComputerName 'srv-shpf01' -Credential $cred -ScriptBlock{ powershell 'C:\\scripts\\UpdateSP.ps1'}");
            pipeline.Invoke();
        }
    }
}
