namespace manga.Domain.Dtos;
public class MangaUpdateDTO
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Author { get; set; } = null!;
}