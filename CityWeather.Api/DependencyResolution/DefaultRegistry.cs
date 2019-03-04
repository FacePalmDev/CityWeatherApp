// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Reflection;
using CityWeather.Data.Contracts;
using CityWeather.Domain.Contracts;

namespace CityWeather.Api.DependencyResolution {
    using CityWeather.Domain;
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;
    using CityWeather.Data.Contracts.Services;
    using CityWeather.Data.Services;
    using CityWeather.Common.Mappings;
    using CityWeather.Data.Repositories;
    using CityWeather.Data.Models;

    public class DefaultRegistry : Registry {
        #region Constructors and Destructors

        public DefaultRegistry() {
            Scan(
                scan => {
                    scan.TheCallingAssembly();
                    scan.AssemblyContainingType<IMapperFactory>();
                    scan.AssemblyContainingType<MapperFactory>();
                    scan.AssemblyContainingType<ICityDomainService>();
                    scan.AssemblyContainingType<CityDomainService>();
                    scan.AssemblyContainingType<ICityDataService>();
                    scan.AssemblyContainingType<CityDataService>();
                    scan.AssemblyContainingType<IUnitOfWork>();
                    scan.AssemblyContainingType<UnitOfWork>();
                    scan.WithDefaultConventions();
                });

            For(typeof(IRepository<,>)).Use(typeof(Repository<,>));
            // For<>().Use<>();
        }

        #endregion
    }
}