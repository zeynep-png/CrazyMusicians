using CrazyMusicians.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrazyMusicians.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusiciansController : ControllerBase
    {
        private static List<Musician> _musicians = new List<Musician>() {
            new Musician  { Id = 1, Name ="Ahmet Çalgı", Profession ="Ahmet Çalgı Çalar", FunFact ="Her zaman yanlış nota çalar, ama çok eğlenceli"   },
            new Musician  { Id = 2, Name ="Zeynep Melodi", Profession ="Popüler Melodi Yazarı", FunFact ="Şarkıları yanlış anlaşılır ama çok popüler"   },
            new Musician  { Id = 3, Name ="Cemil Akor", Profession ="Çılgın Akorist", FunFact ="Akorları sık değiştirir ama şaşırtıcı derecede yetenekli"   },
            new Musician  { Id = 4, Name ="Fatma Nota", Profession ="Süpriz Nota Üreticisi", FunFact ="Nota üretirken sürekli süprizler hazırlar"   },
            new Musician  { Id = 5, Name ="Hasan Ritim", Profession ="Ritim Canavarı", FunFact ="Her ritmi kendi tarzında yapar, hiç uymaz ama komiktir"   },
            new Musician  { Id = 6, Name ="Elif Armoni", Profession ="Armoni Ustası", FunFact ="Armonilerini bazen yanlış çalar ama çok yaratıcı"   },
            new Musician  { Id = 7, Name ="Ali Perde", Profession ="Perde Uygulayıcı", FunFact ="Her perdeyi farklı şekilde çalar, her zaman süprizlidir"   },
            new Musician  { Id = 8, Name ="Ayşe Rezonans", Profession ="Rezonans Uzmanı", FunFact ="Rezonans konusunda uzman, ama bazen çok gürültü çıkarır"   },
            new Musician  { Id = 9, Name ="Murat Ton", Profession ="Tonlama Meraklısı", FunFact ="Tonlamalardaki farklılıklar bazen komik, ama oldukça ilginç"   },
            new Musician  { Id = 10, Name ="Akor Sihirbazı", Profession ="Akor Sihirbazı", FunFact ="Akorları değiştirdiğinde bazen sihirli bir hava yaratır"   },



        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_musicians);
        }

        [HttpGet("{id:int:min(1)}")]
        public IActionResult Get(int id)
        {
            var musicians = _musicians.FirstOrDefault(x => x.Id == id);
            if (musicians == null)
                return NotFound();


            return Ok(musicians);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Musician musician)
        {
            musician.Id = _musicians.Max(x => x.Id) + 1;


            _musicians.Add(musician);

            return CreatedAtAction(nameof(Get), new { id = musician.Id }, musician);
        }
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] Musician newMusician)
        {
            var musician = _musicians.FirstOrDefault(x => x.Id == id);
            if (musician == null)
                return NotFound();

            musician.FunFact = newMusician.FunFact;

            return Ok(musician);
        }

        [HttpGet("searh")]
        public IActionResult Search([FromQuery] string keyword)
        {
            var musicians = _musicians.Where(x => x.FunFact.Contains(keyword) || x.Profession.Contains(keyword) || x.Name.Contains(keyword)).ToList();

            if (musicians.Count == 0) return NotFound();

            return Ok(musicians);
        }

        [HttpPut]
        public IActionResult Put(int id, [FromBody] Musician request)
        {
            if (request == null || id != request.Id)
                return BadRequest();

            var musician = _musicians.FirstOrDefault(x => x.Id == id);


            if (musician == null)
                return NotFound();

            musician.Name = request.Name;
            musician.Profession = request.Profession;
            musician.FunFact = request.FunFact;
            musician.IsDeleted = request.IsDeleted;

            return Ok(musician);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var musician = _musicians.FirstOrDefault(x => x.Id == id);
            if (musician == null) return NotFound();

            musician.IsDeleted = true;


            return Ok(musician);
        }


    }
}
