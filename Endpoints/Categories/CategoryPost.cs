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
            return Results.Ok("Ok");
        }
    }
}
