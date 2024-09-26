using Microsoft.AspNetCore.Mvc;
using mangas.Service.Features.Mangas;
using mangas.Domain.Entities;
using AutoMapper;
using manga.Domain.Dtos;

namespace mangas.Controllers.V1;

[ApiController]
[Route("api/[controller]")]

public class MangaController : ControllerBase
{
    private readonly MangaService _mangaService;
    private readonly IMapper _mapper;
    public MangaController(MangaService mangaService, IMapper mapper)
    {
        this._mangaService = mangaService;
        this._mapper = mapper;
    }  

    [HttpGet]
    public IActionResult GetAll()
    {
        var mangas = _mangaService.GetAll();
        var mangaDtos = _mapper.Map<IEnumerable<MangaDTO>>(mangas);

        return Ok(mangaDtos);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById([FromRoute]int id)
    {
        var manga = _mangaService.GetById(id);
        if (manga == null)
        {
            return NotFound();
        }

        var dto = _mapper.Map<MangaDTO>(manga);
        return Ok(dto);
    }

    [HttpPost]
    public IActionResult Add([FromBody]Manga manga)
    {
        var entity = _mapper.Map<Manga>(manga);

        var mangas = _mangaService.GetAll();
        var mangaId = mangas.Count() + 1;

        entity.Id = mangaId;
        _mangaService.Add(entity);

        var dto = _mapper.Map<MangaDTO>(entity);
        return CreatedAtAction(nameof(GetById), new { id = entity.Id }, dto);
    }

    [HttpPut("{id}")]
    public IActionResult Update (int id, MangaUpdateDTO updateMangaDto)
    {
        if (id != updateMangaDto.Id)
        {
            return BadRequest();
        }

        var manga = _mapper.Map<Manga>(updateMangaDto);
        _mangaService.Update(manga);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _mangaService.Delete(id);
        return NoContent();
    }
}