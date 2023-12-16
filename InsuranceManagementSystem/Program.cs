using InsuranceManagementSystem.Model;
using InsuranceManagementSystem.ServiceProvider;
using InsuranceManagementSystem.Utility;
using InsuranceManagementSystem.Exceptions;
using InsuranceManagementSystem.Repository;

IPolicyRepository ipolicyService = new PolicyRepository();

IService repo = new Service();

while (true)
{
    Console.WriteLine("--------------POLICY SERVICES-----------\n");
    Console.WriteLine("1.CreateNewPolicy");
    Console.WriteLine("2.FindPolicy");
    Console.WriteLine("3.List Of All Policies");
    Console.WriteLine("4.Upadate a Policy");
    Console.WriteLine("5.Delete a Policy");
    Console.WriteLine("\n--------------------------------------------\n");
    Console.WriteLine("6.EXIT");

    Console.WriteLine("\n Enter Your Choice \n");


    int choice = int.Parse(Console.ReadLine());

    switch (choice)
    {
        case 1:
            repo.CreatePolicy();
            break;
        case 2:
            repo.GetPolicy();
            break;
        case 3:
            repo.GetAllPolicies();
            break;
        case 4:
            repo.UpdatePolicy();
            break;
        case 5:
            repo.DeletePolicy();
            break;
        case 6:
            string Result = repo.ExitConsole();
            if (Result.ToLower() == "yes")
            {
                Console.WriteLine("Exited successfully");
                Environment.Exit(0);
                break;
            }
            else
            {
                continue;
            }
    }
}