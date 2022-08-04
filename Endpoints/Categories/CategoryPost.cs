using IWantApp.Domain.Products;
using IWantApp.Infra.Data;

namespace IWantApp.Endpoints.Categories
{
    public class CategoryPost
    {
        //Rota
        public static string Template => "/categories";

        public static string[] Methods => new string[] { HttpMethod.Post.ToString()};

        public static Delegate handle => Action;


        public static IResult Action(CategoryRequest categoryRequest, ApplicationDbContext applicationDbContext) 
        {
            var category = new Category
            {
                Name = categoryRequest.Name,
                CreatedBy = "teste",
                CreatedOn = DateTime.Now,
                EditedBy = "teste",
                EditedOn = DateTime.Now
            };

            applicationDbContext.Categoryes.Add(category);
            applicationDbContext.SaveChanges();


            return Results.Created("/categories/" + category.Id, category.Id);
        }
    }
}
