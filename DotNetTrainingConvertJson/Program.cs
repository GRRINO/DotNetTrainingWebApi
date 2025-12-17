// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;

Console.WriteLine("Hello, World!");

BlogModel blog = new BlogModel
{
    BlogId = 1,
    BlogTitle = "Introduction to .NET 8",
    BlogAuthor = "Jane Doe",
    BlogContent = "This is a comprehensive guide to the new features in .NET 8..."
};

//string jsonStr = JsonConvert.SerializeObject(blog, Formatting.Indented);

string jsonStr = blog.ToJson();
Console.WriteLine(jsonStr);

string jsonStr2 = """
{
  "BlogId": 1,
  "BlogTitle": "Introduction to .NET 8",
  "BlogAuthor": "Jane Doe",
  "BlogContent": "This is a comprehensive guide to the new features in .NET 8..."
}
""";
//var blog2 = JsonConvert.DeserializeObject<BlogModel>(jsonStr2);

var blog2 = jsonStr2.FromJson<BlogModel>();
Console.WriteLine(blog2.BlogTitle);


Console.ReadLine();
public class BlogModel 
{
    public int BlogId { get; set; }
    public string BlogTitle { get; set; }
    public string BlogAuthor { get; set; }
    public string BlogContent { get; set; }
}

public static class Extensions
{
    public static string ToJson(this object obj)
    {
        string jsonStr = JsonConvert.SerializeObject(obj, Formatting.Indented);
        return jsonStr;
    }

    public static T FromJson<T>(this string json)
    {
        return JsonConvert.DeserializeObject<T>(json);
    }

    


}