using SM.Interfaces;
using SM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace SM.Data.DataServices
{
    public class RegionDataService : EntityFrameworkService, IRegionDataService
    {
        private ResultMessage _resultMessage;

        public RegionDataService()
        {
            _resultMessage = new ResultMessage()
            {
                Result = false,
                Message = "sdsd"
            };
        }
        
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="product"></param>
        public ResultMessage Create(Region region)
        {
            try
            {
                dbConnection.Regions.Add(region);
                _resultMessage.Result = true;
            }
            catch (Exception ex)
            {
                _resultMessage.Result = false;
                _resultMessage.Message = ex.Message;
                throw;
            }
            return _resultMessage;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="product"></param>
        public ResultMessage Update(Region region)
        {
            var r = dbConnection.Regions.Where(x => x.RegionCode == region.RegionCode).FirstOrDefault();
            if(r != null)
            {
                try
                {
                    r = region;
                    _resultMessage.Result = true;
                }
                catch (Exception ex)
                {
                    _resultMessage.Result = false;
                    _resultMessage.Message = ex.Message;
                    throw;
                }
            }
            else
            {
                _resultMessage.Result = false;
                _resultMessage.Message = "ABC";
            }
            return _resultMessage;
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="product"></param>
        public ResultMessage Delete(string regionCode)
        {
            var region = dbConnection.Regions.Where(x => x.RegionCode == regionCode).FirstOrDefault();
            if(region != null)
            {
                try
                {
                    dbConnection.Regions.Remove(region);
                    _resultMessage.Result = true;
                }
                catch (Exception ex)
                {
                    _resultMessage.Result = false;
                    _resultMessage.Message = ex.Message;
                    throw;
                }
            }
            else
            {
                _resultMessage.Result = false;
                _resultMessage.Message = "ABC";
            }
            
            return _resultMessage;
        }

        /// <summary>
        /// Get Region
        /// </summary>
        /// <param name="regionCode"></param>
        /// <returns></returns>
        public Region Get(string regionCode)
        {
            Region region = dbConnection.Regions.Where(x => x.RegionCode == regionCode).FirstOrDefault();
            return region;
        }

        /// <summary>
        /// Get Products
        /// </summary>
        /// <param name="currentPageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortExpression"></param>
        /// <param name="sortDirection"></param>
        /// <param name="totalRows"></param>
        /// <returns></returns>
        public IList<Region> Gets(int currentPageNumber, int pageSize, string sortExpression, string sortDirection, out int totalRows)
        {
            totalRows = 0;

            sortExpression = sortExpression + " " + sortDirection;

            totalRows = dbConnection.Products.Count();

            List<Region> regions = dbConnection.Regions.OrderBy(sortExpression).Skip((currentPageNumber - 1) * pageSize).Take(pageSize).ToList();

            return regions;

        }
    }
}
