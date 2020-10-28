using StateCensusProblem.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace StateCensusProblem.DTO
{
    public class CensusDTO
    {
        public int serialNumber;
        public string stateName;
        public string state;
        public int tin;
        public string stateCode;
        public long population;
        public long area;
        public long density;
        public long housingUnits;
        public double totalArea;
        public double waterArea;
        public double landArea;
        public double populationDensity;
        public double housingDensity;
        public CensusDTO(StateCodeDAO stateCodeDao)
        {
            this.serialNumber = stateCodeDao.serialNumber;
            this.stateName = stateCodeDao.stateName;
            this.tin = stateCodeDao.tin;
            this.stateCode = stateCodeDao.stateCode; 
        }
        public CensusDTO(CensusDataDAO censusDataDao)
        {
            this.state = censusDataDao.state;
            this.population = censusDataDao.population;
            this.area = censusDataDao.area;
            this.density = censusDataDao.density;
        }
      /*  public CensusDTO(USCensusDAO uSCensusDAO)
        {
            this.stateCode = uSCensusDAO.state;
            this.stateName = uSCensusDAO.stateName;
            this.population = uSCensusDAO.population;
            this.housingUnits = uSCensusDAO.housingUnits;
            this.totalArea = uSCensusDAO.totalArea;
            this.waterArea = uSCensusDAO.waterArea;
            this.landArea = uSCensusDAO.landArea;
            this.populationDensity = uSCensusDAO.populationDensity;
            this.housingDensity = uSCensusDAO.housingDensity;
        }*/
        

        


    }
}
