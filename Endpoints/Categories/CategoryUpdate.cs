using IWantApp.Domain.Products;
using IWantApp.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace IWantApp.Endpoints.Categories
{
    public class CategoryUpdate
    {
        //Rota
        public static string Template => "/categories/{id:int}";

        public static string[] Methods => new string[] { HttpMethod.Put.ToString()};

        public static Delegate handle => Action;


        public static IResult Action([FromRoute] int id ,CategoryRequest categoryRequest, ApplicationDbContext applicationDbContext) 
        {
            var category = applicationDbContext.Categoryes.Where(c => c.Id == id).FirstOrDefault();

            if(category == null)
            {
                return Results.NotFound();
            }

            category.EditInfo(categoryRequest.Name, categoryRequest.Active);

            if (!category.IsValid) 
            {
                return Results.ValidationProblem(category.Notifications.ConvertToProblemDetails());
            }


            applicationDbContext.SaveChanges();



            return Results.Ok();
        }
    }
}
