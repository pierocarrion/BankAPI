using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Test_Backend.Models;

namespace Test_Backend.Services.ReporteService
{
    public interface IReporteService
    {
        Cliente GetEstadoDeCuenta(DateTime dateTimeFrom, DateTime dateTimeTo, int clienteId);
    }
}