using StateCensusProblem.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace StateCensusProblem.POCO
{
    public class CSVAdapterFactory
    {
        public Dictionary<string, CensusDTO> LoadCsvData(CensusAnalyser.Country country, string csvFilePath, string dataHeader)
        {
            switch(country)
            {
                case (CensusAnalyser.Country.INDIA):
                    return new IndianCensusAdapter().LoadCensusData(csvFilePath, dataHeader);
                case (CensusAnalyser.Country.US):
                    return new IndianCensusAdapter().LoadCensusData(csvFilePath, dataHeader);
                    default:
                    throw new CensusAnalyserException("No such country", CensusAnalyserException.ExceptionType.NO_SUCH_COUNTRY);
            }
        }
    }
}
