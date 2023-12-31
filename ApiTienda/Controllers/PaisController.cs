using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTienda.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiTienda.Controllers
{
    public class PaisController : BaseApiContoller
    {
         private readonly IUnitOfWork  unitofwork;
         private IMapper mapper;
        public PaisController(IUnitOfWork  unitOfWork,IMapper mapper )
        {
            this.unitofwork =  unitOfWork ;
            this.mapper =  mapper ;

        }

        // [HttpGet]
        // [ProducesResponseType(StatusCodes.Status200OK)]
        // [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // public async Task<ActionResult<IEnumerable<Pais>>> Get()
        // {
        //     var paises = await  unitofwork.Paises.GetAllAsync();
        //     return Ok(paises);
        // }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PaisDto>>> Get()
        {
            var paises = await  unitofwork.Paises.GetAllAsync();
            return mapper.Map<List<PaisDto>>(paises);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<PaisDto>> Get(int id)
        {
            var pais = await unitofwork.Paises.GetByIdAsync(id);
            if (pais == null){
                return NotFound();
            }
            return mapper.Map<PaisDto>(pais);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // public async Task <ActionResult<Pais>> Post(Pais pais)
        // {
        //     unitofwork.Paises.Add(pais);
        //     await unitofwork.SaveAsync();
        //     if(pais == null)
        //     {
        //         return BadRequest();
        //     }
        //     return CreatedAtAction(nameof(Post), new {id = pais.Id}, pais);
        // }
        public async Task <ActionResult<Pais>> Post(PaisDto paisDto)
        {
            var pais = this.mapper.Map<Pais>(paisDto);
            this.unitofwork.Paises.Add(pais);
            await unitofwork.SaveAsync();
            if(pais == null)
            {
                return BadRequest();
            }
            paisDto.Id= pais.Id;
            return CreatedAtAction(nameof(Post), new {id = paisDto.Id}, paisDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<PaisDto>> Put(int id, [ FromBody]PaisDto paisDto){
            if(paisDto == null)
            return NotFound();
            var pais= this.mapper.Map<Pais>(paisDto);
            unitofwork.Paises.Update(pais);
            await unitofwork.SaveAsync();
            return paisDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> Delete(int id){
            var pais= await unitofwork.Paises.GetByIdAsync(id);

            if(pais == null)
            return NotFound();
            unitofwork.Paises.Remove(pais);
            await unitofwork.SaveAsync();
            return NoContent();
        }
    }
}