using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ContactsDataAccess;

namespace ContactWebAPI472.Controllers
{
  //[Route("api/[controller]/[action]")]
  public class ContactController : ApiController
  {
    [HttpGet]
    [ActionName("GetEmployeeContacts")]
    public IEnumerable<app_Contact_TB> GetEmployeeContacts()
    {
      using (ContactEntities contacts = new ContactEntities())
      {
        return contacts.app_Contact_TB.ToList();
      }
    }

    [HttpGet]
    public app_Contact_TB GetEmployeeContactById(int id)
    {
      using (ContactEntities contacts = new ContactEntities())
      {
        return contacts.app_Contact_TB.FirstOrDefault(e => e.ContactId == id);
      }

    }
    [HttpPost]
    public void AddEmployeeContact([FromBody] app_Contact_TB EmployeeContact)
    {
      using (ContactEntities contacts = new ContactEntities())
      {
        if (String.IsNullOrEmpty(Convert.ToString(EmployeeContact.ContactStatus)))
          { EmployeeContact.ContactStatus = true; }
        contacts.app_Contact_TB.Add(EmployeeContact);
        contacts.SaveChanges();
      }

    }
    [HttpDelete]
    public void DeleteEmployeeContactById(int id)
    {
      using (ContactEntities contacts = new ContactEntities())
      {
        var entity = contacts.app_Contact_TB.FirstOrDefault(e => e.ContactId ==id);
        entity.ContactStatus = !entity.ContactStatus;       
        contacts.SaveChanges();
      }
    }
    [HttpPut]
    public void UpdateEmployeeContact([FromBody] app_Contact_TB EmployeeContact)
    {
      using (ContactEntities contacts = new ContactEntities())
      {
        var entity = contacts.app_Contact_TB.FirstOrDefault(e => e.ContactId == EmployeeContact.ContactId);
        entity.FirstName = EmployeeContact.FirstName;
        entity.LastName  = EmployeeContact.LastName;
        entity.Email = EmployeeContact.Email;
        entity.PhoneNumber = EmployeeContact.PhoneNumber;
        entity.ContactStatus = true;
        contacts.SaveChanges();
      }
    }
  }
}
