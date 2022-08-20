using Dapper;
using IWantApp.Infra.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;

namespace IWantApp.Endpoints.Employees
{
    public class EmployeeGetAll
    {
        public static string Template => "/employee";

        public static string[] Methods => new string[] { HttpMethod.Get.ToString() };

        public static Delegate handle => Action;


        public static IResult Action(int page, int rows, QueryAllUsersWithClaimName query /*UserManager<IdentityUser> userManager*/)
        {
            /*
            var users = userManager.Users.Skip((page -1) * rows).Take(rows).ToList();//Skip é para pular as linhas, take é para pegar as linhas
            var employees = new List<EmployeeResponse>();

            foreach (var item in users)
            {
                var claims = userManager.GetClaimsAsync(item).Result;
                var claimName = claims.FirstOrDefault(c => c.Type == "Name");
                var username = claimName != null ? claimName.Value : string.Empty;

                employees.Add(new EmployeeResponse()
                {
                    Email = item.Email,
                    Name = username
                }
                );
            }*/

            //Utilizando o Dapper para paginação e ordenação: micro ORM

           

            return Results.Ok(query.execute(page, rows));
        }
    }
}
