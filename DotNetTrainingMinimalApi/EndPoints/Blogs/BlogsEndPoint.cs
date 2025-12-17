
namespace DotNetTrainingMinimalApi.EndPoints.Blogs
{
    public static class BlogsEndPoint
    {
        public static void MapBlogsEndPoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/Blogs", () => {
                AppDbContext db = new AppDbContext();

                var blogs = db.TblBlogs.AsNoTracking().Where(x => x.IsDelete == false).ToList();
                return Results.Ok(blogs);

            }).WithName("GetBlogs")
          .WithOpenApi();

            app.MapPost("/blogs", (TblBlog blog) =>
            {
                AppDbContext db = new AppDbContext();
                db.TblBlogs.Add(blog);
                db.SaveChanges();
                return Results.Ok(blog);
            }).WithName("CreateBlog")
            .WithOpenApi();

            app.MapPost("/blogs/{id}", (int id, TblBlog blog) =>
            {
                AppDbContext db = new AppDbContext();
                var item = db.TblBlogs.AsNoTracking().Where(x => x.IsDelete == false).FirstOrDefault(x => x.BlogId == id);
                if (item is null)
                {
                    return Results.BadRequest("No data found");
                }
                item.BlogTitle = blog.BlogTitle;
                item.BlogAuthor = blog.BlogAuthor;
                item.BlogContent = blog.BlogContent;

                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return Results.Ok("Update Successful");
            }).WithName("UpdateBlogs")
            .WithOpenApi();

            app.MapDelete("/blogs/{id}", (int id) =>
            {
                AppDbContext db = new AppDbContext();
                var item = db.TblBlogs.AsNoTracking().Where(x => x.IsDelete == false).FirstOrDefault(x => x.BlogId == id);
                if (item is null)
                {
                    return Results.BadRequest("No data found");
                }
                item.IsDelete = true;

                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return Results.Ok("Delete Successful");

            }).WithName("DeleteBlogs")
            .WithOpenApi();

        }
    }
}
