using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Interfaces.AutoMapper
{
    public interface IMapper
    {
        TDestination Map<TDestination, TSoruce>(TSoruce soruce, string? ignore = null);

        IList<TDestination> Map<TDestination, TSoruce>(IList<TSoruce> soruce, string? ignore = null);

        TDestination Map<TDestination>(object soruce, string? ignore = null);
        IList<TDestination> Map<TDestination>(IList<object> soruce, string? ignore = null);
    }
}
