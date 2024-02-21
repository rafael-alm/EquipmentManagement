﻿using equipmentManagement.application.output.seedWork;

namespace equipmentManagement.application.output.dto.company
{
    public struct ProductPaginationFilter : IFilterPaging
    {
        public ProductPaginationFilter()
        {
                
        }

        public string? SupplierDescription { get; set; }
        public int? Code { get; set; }
        public string? Description { get; set; }
        public int? Status { get; set; }
        public DateTime? ManufacturingDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public int Page { get; set; }
        public int RecordsPerPage { get; set; }
    }
}
