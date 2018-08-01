using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManagementInfoApp.DAL;



namespace StockManagementInfoApp.BLL
{
     public class Manager
    {

         Repository _repository = new Repository();
        public bool Add(Models.Person person)
        {
            if (person.CategoryName.Length==null)
            {
                throw new Exception("Fill Up the form");
                
            }
           
            bool toServer = _repository.Add(person);
            return toServer;
        }

       

        public bool CompanyAdd(Models.Person person)
        {
            if (person.CompanyName.Length==null)
            {
                throw new Exception("Entry the Company Name");
            }
            bool isServer = _repository.companyAdd(person);
            return isServer;
        }

        public bool Update(Models.Person person)
        {
            bool isUpdate = _repository.update(person);
            return isUpdate;
        }
    }
}
