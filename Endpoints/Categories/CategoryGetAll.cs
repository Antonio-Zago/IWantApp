using IWantApp.Domain.Products;
using IWantApp.Infra.Data;

namespace IWantApp.Endpoints.Categories
{
    public class CategoryGetAll
    {
        //Rota
        public static string Template => "/categories";

        public static string[] Methods => new string[] { HttpMethod.Get.ToString()};

        public static Delegate handle => Action;


        public static IResult Action(ApplicationDbContext applicationDbContext) 
        {

            var category = applicationDbContext.Categoryes.ToList();
            var response = category.Select(c => new CategoryResponse { Name = c.Name, Active = c.Active, Id = c.Id});

            return Results.Ok(response);
        }
    }
}
