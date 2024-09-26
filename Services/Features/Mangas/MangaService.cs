using mangas.Domain.Entities;
using mangas.Infrastructure.Repositories;

namespace mangas.Service.Features.Mangas;

public class MangaService {
    private readonly MangaRepository _mangaRepository;

    public MangaService(MangaRepository mangaRepository) {
        _mangaRepository = mangaRepository;
    }
    public IEnumerable<Manga> GetAll() {
        return _mangaRepository.GetAll();
    }

    public Manga GetById(int id) {
        return _mangaRepository.GetById(id);
    }

    public void Add(Manga manga) {
        _mangaRepository.Add(manga);
    }

    public void Update(Manga mangaToUpdate)
    {
        var manga = GetById(mangaToUpdate.Id);
        if (manga.Id > 0)
            _mangaRepository.Update(mangaToUpdate);
    }

    public void Delete(int id)
    {
        var manga = GetById(id);
        if (manga.Id > 0)
            _mangaRepository.Delete(id);
    }
}