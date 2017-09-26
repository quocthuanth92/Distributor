﻿using System;
using System.Collections.Generic;
using System.Text;
using SM.Entities;

namespace SM.Interfaces
{
    /// <summary>
    /// Product Data Service
    /// </summary>
    public interface IRegionDataService : IDataRepository, IDisposable
    {
        ResultMessage Create(Region region);
        ResultMessage Update(Region region);
        ResultMessage Delete(string regionCode);
        Region Get(string regionCode);
        IList<Region> Gets(int currentPageNumber, int pageSize, string sortExpression, string sortDirection, out int totalRows);
    }
}