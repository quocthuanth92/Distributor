using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SM.Entities;


namespace SM.Interfaces
{
    /// <summary>
    /// Customer Data Service
    /// </summary>
    public interface ICustomerDataService : IDataRepository, IDisposable
    {
        void CreateCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        Customer GetCustomer(int customerID);
        List<Customer> GetCustomers(int currentPageNumber, int pageSize, string sortExpression, string sortDirection, out int totalRows);
        void InitializeData();
        void LoadData();  
    }

    /// <summary>
    /// Customer Data Service
    /// </summary>
    public interface ICustomerService : IDataRepository, IDisposable
    {
        void CreateCustomer(CustomerManagement customer);
        void UpdateCustomer(CustomerManagement customer);
        CustomerManagement GetCustomer(string customerID);
        List<CustomerManagement> GetCustomers(int currentPageNumber, int pageSize, string sortExpression, string sortDirection, out int totalRows);
        void InitializeData();
        void LoadData();
    }
}
