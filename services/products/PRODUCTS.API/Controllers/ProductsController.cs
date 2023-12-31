namespace ECommerce.Products.Api.Controllers;
public class ProductsController : BaseController
{
    private readonly IProductRepository _productRepository;
    private readonly IMediator _mediator;
    public ProductsController(
            ILogger<ProductsController> logger,
            IMapper mapper,
            IProductRepository productRepository,
            IMediator mediator
        ) : base(logger, mapper)
    {
        _productRepository = productRepository;
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<ProductItemResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetProducts([FromQuery] ProductListQuery query)
    {
        var result = await _mediator.Send(query);

        result.ExposeHeader();

        return Ok(_mapper.Map<List<Product>, List<ProductItemResponse>>(result.Items));
    }

    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateProduct(CreateProductRequest request)
    {
        var result = await _mediator.Send(request);

        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ProductDetailResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetProductDetail(Guid id)
    {
        var query = _productRepository.IncludedQuery;

        var result = await query.FirstOrDefaultAsync(p => p.Id == id);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<Product, ProductDetailResponse>(result));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateProductDetail(Guid id, [FromBody] UpdateProductRequest request)
    {
        if (id != request.Id)
        {
            return BadRequest();
        }

        await _mediator.Send(request);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        return Ok(await _mediator.Send(new DeleteProductRequest { Id = id }));
    }
}