using System.Data.Entity;

namespace TestNinja.Mocking
{
    public class EmployeeController
    {
        //private EmployeeContext _db;
        private IEmployeeStorage _employeeStorage;

        public EmployeeController(IEmployeeStorage employeeStorage)
        {
            _employeeStorage = employeeStorage;
        }

        public ActionResult DeleteEmployee(int id)
        {
            // path ways
            // id exists in database => remove employee.
            // id inexists in database => dont remove employee.
            // redirect to Employees view = verify the state of redirecting.
            _employeeStorage.RemoveEmployee(id);

            return RedirectToAction("Employees");
        }

        private ActionResult RedirectToAction(string employees)
        {
            return new RedirectResult();
        }
    }

    public class ActionResult { }
 
    public class RedirectResult : ActionResult { }
    
    public class EmployeeContext
    {
        public DbSet<Employee> Employees { get; set; }

        public void SaveChanges()
        {
        }
    }

    public class Employee
    {
    }
}