using Dapper;
using IWantApp.Endpoints.Employees;
using Microsoft.Data.SqlClient;

namespace IWantApp.Infra.Data
{
    public class QueryAllUsersWithClaimName
    {
        private readonly IConfiguration configuration;

        public QueryAllUsersWithClaimName(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IEnumerable<EmployeeResponse> execute(int page, int rows)
        {
            var db = new SqlConnection(configuration["ConnectionStrings:IWantDb"]);
            var query = @"SELECT users.Email ,claim.ClaimValue as Name
                    FROM AspNetUsers users
                    INNER JOIN AspNetUserClaims claim
                        ON users.Id = claim.UserId
                        AND claim.ClaimType = 'Name'
                    ORDER BY Name
                    OFFSET (@page -1) * @rows ROWS FETCH NEXT @rows ROWS ONLY";

            return db.Query<EmployeeResponse>( //Converte a consulta em um objeto do tipo EmployeeResponse
                    query,
                    new { page, rows }
                );
        }
    }
}
