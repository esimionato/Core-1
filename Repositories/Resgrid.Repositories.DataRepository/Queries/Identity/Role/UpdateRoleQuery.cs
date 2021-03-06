﻿using System;
using Resgrid.Model.Repositories.Queries.Contracts;
using Resgrid.Repositories.DataRepository.Configs;
using Resgrid.Repositories.DataRepository.Extensions;

namespace Identity.Dapper.Queries.Role
{
    public class UpdateRoleQuery : IUpdateQuery
    {
        private readonly SqlConfiguration _sqlConfiguration;
        public UpdateRoleQuery(SqlConfiguration sqlConfiguration)
        {
            _sqlConfiguration = sqlConfiguration;
        }
    
        public string GetQuery<TEntity>(TEntity entity)
        {
            var roleProperties = entity.GetColumns(_sqlConfiguration, ignoreIdProperty: true);

            var setFragment = roleProperties.UpdateQuerySetFragment(_sqlConfiguration.ParameterNotation);

            var query = _sqlConfiguration.UpdateRoleQuery
                                         .ReplaceUpdateQueryParameters(_sqlConfiguration.SchemaName,
                                                                       _sqlConfiguration.RoleTable,
                                                                       setFragment,
                                                                       $"{_sqlConfiguration.ParameterNotation}Id");

            return query;
        }
    }
}
