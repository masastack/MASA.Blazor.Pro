namespace Masa.Blazor.ProApp.Rcl.Models;

public class Product
{
    public Guid Id { get; init; }

    public string Name { get; init; }

    public string Description { get; init; }

    public double Price { get; init; }

    public string PictureFile { get; init; }

    public string Category { get; set; }

    public int Rating { get; set; }

    public string Brand { get; set; }

    public bool Favorite { get; set; }

    public Product(string name, double price, string pictureFile, string category, int rating, string brand,
        string description)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Price = price;
        PictureFile = pictureFile;
        Category = category;
        Rating = rating;
        Brand = brand;
    }

    public Product(Guid id, string name, double price, string pictureFile, string category, int rating, string brand,
        string description)
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        PictureFile = pictureFile;
        Category = category;
        Rating = rating;
        Brand = brand;
    }
}