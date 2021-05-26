﻿using MediatR;
using TrainingProject.Core;

namespace TrainingProject.Application.Queries.StoreDepartments.PatchStoreDepartment
{
    public class PatchStoreDepartmentCommandQuery : IRequest<SchemeType>
    {
        public int StoreId { get; }
        public int DepartmentId { get; }
        public SchemeType Scheme { get; }

        public PatchStoreDepartmentCommandQuery(int storeId, int departmentId, SchemeType scheme)
        {
            StoreId = storeId;
            DepartmentId = departmentId;
            Scheme = scheme;
        }
    }
}
