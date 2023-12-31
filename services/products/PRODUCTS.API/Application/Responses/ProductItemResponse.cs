namespace ECommerce.Products.Api.Application.Responses;

public class ProductItemResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public int Price { get; set; }
    public List<string> Tags { get; set; } = new List<string>();
    public ProductCategoryResponse Category { get; set; } = null!;
}

public class ProductItemResponseProfile : Profile
{
    public ProductItemResponseProfile()
    {
        CreateMap<Product, ProductItemResponse>()
            .ForMember(p => p.Category, opt => opt.MapFrom(p => p.Category))
            .ForMember(p => p.Tags, opt => opt.MapFrom(source => source.Tags.Select(t => t.Value)));
    }
}