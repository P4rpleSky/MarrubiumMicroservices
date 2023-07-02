using System.Collections.Generic;

namespace Marrubium.Services.ProductAPI.HttpModels;

public class CategoryListsModel
{
    public List<string> ProductTypes { get; set; } = new();

    public List<string> Functions { get; set; } = new();

    public List<string> SkinTypes { get; set; } = new();
}