namespace Eventify.Application.RequestParameters;

// eger problem olsa class ile deyisdir
public record Pagination
{
    public int ItemCount { get; set; } = 5;
    public int PageCount { get; set; } = 0;
}
