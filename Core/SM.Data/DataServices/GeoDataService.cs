﻿using SM.Interfaces;
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
        /// Get All Region
        /// </summary>
        /// <returns></returns>
        public IList<Region> GetAll()
        {
            IList<Region> regions = dbConnection.Regions.ToList();
            return regions;
        }

        /// <summary>
        /// Get Region
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

    public class ProvinceDataService : EntityFrameworkService, IProvinceDataService
    {
        private ResultMessage _resultMessage;

        public ProvinceDataService()
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
        public ResultMessage Create(Province province)
        {
            try
            {
                dbConnection.Provinces.Add(province);
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
        public ResultMessage Update(Province province)
        {
            var r = dbConnection.Provinces.Where(x => x.ProvinceCode == province.RegionCode).FirstOrDefault();
            if (r != null)
            {
                try
                {
                    r = province;
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
        public ResultMessage Delete(string provinceCode)
        {
            var region = dbConnection.Provinces.Where(x => x.ProvinceCode == provinceCode).FirstOrDefault();
            if (region != null)
            {
                try
                {
                    dbConnection.Provinces.Remove(region);
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
        public Province Get(string provinceCode)
        {
            Province province = dbConnection.Provinces.Where(x => x.ProvinceCode == provinceCode).FirstOrDefault();
            return province;
        }

        /// <summary>
        /// Get All Province
        /// </summary>
        /// <returns></returns>
        public IList<Province> GetAll()
        {
            IList<Province> products = dbConnection.Provinces.ToList();
            return products;
        }

        /// <summary>
        /// Get Region
        /// </summary>
        /// <param name="currentPageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortExpression"></param>
        /// <param name="sortDirection"></param>
        /// <param name="totalRows"></param>
        /// <returns></returns>
        public IList<Province> Gets(int currentPageNumber, int pageSize, string sortExpression, string sortDirection, out int totalRows)
        {
            totalRows = 0;

            sortExpression = sortExpression + " " + sortDirection;

            totalRows = dbConnection.Products.Count();

            List<Province> provinces = dbConnection.Provinces.OrderBy(sortExpression).Skip((currentPageNumber - 1) * pageSize).Take(pageSize).ToList();

            return provinces;

        }
    }
}
