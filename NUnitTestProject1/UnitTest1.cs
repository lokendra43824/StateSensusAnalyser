using NUnit.Framework;
using System.Collections.Generic;
using StateCensusProblem.POCO;
using StateCensusProblem;
using static IndianStateCensus.CensusAnalyser;
using StateCensusProblem.DTO;
using static StateCensusProblem.POCO.CensusAnalyser;
using Newtonsoft.Json;
namespace NUnitTestProject1
{
    public class Tests
    {
        static string indianStateCensusHeaders = @"State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeaders = @"SrNo,State Name,TIN,StateCode";
        static string indianStateCensusFilePath = @"C:\Users\NAGENDRA AND JANAKI\source\repos\StateCensusProblem\StateCensusProblem\NewFolder\IndiaStateCensusData.csv";
        static string wrongHeaderIndianCensusFilePath = @"C:\Users\NAGENDRA AND JANAKI\source\repos\StateCensusProblem\StateCensusProblem\NewFolder\WrongIndiaStateCensusData.csv";
        static string delimiterIndianCensusFilePath = @"C:\Users\NAGENDRA AND JANAKI\source\repos\StateCensusProblem\StateCensusProblem\NewFolder\DelimiterIndiaStateCensusData.csv";
        static string wrongIndianStateCensusFilePath = @"C:\Users\NAGENDRA AND JANAKI\source\repos\StateCensusProblem\StateCensusProblem\NewFolder\WrongIndiaStateCensusData.csv";
        static string wrongIndianStateCensusFileFileType = @"C:\Users\NAGENDRA AND JANAKI\source\repos\StateCensusProblem\StateCensusProblem\NewFolder\WrongIndiaStateCensusData.csv";
        static string indianStateCodeFilePath = @"C:\Users\NAGENDRA AND JANAKI\source\repos\StateCensusProblem\StateCensusProblem\NewFolder\IndiaStateCode.csv";
        static string wrongindianStateCodeFileType = @"C:\Users\NAGENDRA AND JANAKI\source\repos\StateCensusProblem\StateCensusProblem\NewFolder\WrongIndiaStateCode.csv";
        static string delimiterIndianStateCodeFilePath = @"C:\Users\NAGENDRA AND JANAKI\source\repos\StateCensusProblem\StateCensusProblem\NewFolder\DelimiterIndiaStateCode.csv";
        static string wrongHeaderStateCodeFilePath = @"C:\Users\NAGENDRA AND JANAKI\source\repos\StateCensusProblem\StateCensusProblem\NewFolder\WrongIndiaStateCode.csv";
        StateCensusProblem.POCO.CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;
        private string wrongIndianStateCensusFileType;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new StateCensusProblem.POCO.CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }
        //Test 1
        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCodeFilePath, indianStateCodeHeaders);
            Assert.AreEqual(29, totalRecord.Count);
            Assert.AreEqual(37, stateRecord.Count);


        }
        //TC2
        //given not existing stateCodeFIle should throw FileNotFound Exception
        [Test]
        public void GivenIncorrectStateCodeFile_ShouldThrowException()
        {
            CensusAnalyserException.ExceptionType expected = CensusAnalyserException.ExceptionType.FILE_NOT_FOUND;
            try
            {
                stateRecord = censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCensusFilePath, indianStateCodeHeaders);

            }
            catch (CensusAnalyserException cae)
            {
                CensusAnalyserException.ExceptionType actual = cae.eType;
                Assert.AreEqual(expected, actual);
            }


        }
        //TC3
        //given incorrect stateCodeFIle(.txt) type should throw InvalidFileType Exception
        [Test]
        public void GivenIncorrectStateCodeFileType_ShouldThrowException()
        {
            CensusAnalyserException.ExceptionType expected = CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE;
            try
            {
                stateRecord = censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongindianStateCodeFileType, indianStateCensusHeaders);

            }
            catch (CensusAnalyserException cae)
            {
                CensusAnalyserException.ExceptionType actual = cae.eType;
                Assert.AreEqual(expected, actual);
            }


        }
        //TC4
        //given incorrect stateCode Delimiter  should throw Incorrect_Delimiter Exception
        [Test]
        public void GivenIncorrectStateCodeDelimiter_ShouldThrowException()
        {
            CensusAnalyserException.ExceptionType expected = CensusAnalyserException.ExceptionType.INCORRECT_DELIMETER;
            try
            {
                stateRecord = censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, delimiterIndianStateCodeFilePath, indianStateCodeHeaders);

            }
            catch (CensusAnalyserException cae)
            {
                CensusAnalyserException.ExceptionType actual = cae.eType;
                Assert.AreEqual(expected, actual);
            }


        }

        //TC5
        //given incorrect stateCode Header  should throw Incorrect_Header Exception
        [Test]
        public void GivenIncorrectStateCodeHeader_ShouldThrowException()
        {
            CensusAnalyserException.ExceptionType expected = CensusAnalyserException.ExceptionType.INCORRECT_HEADER;
            try
            {
                stateRecord = censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongHeaderStateCodeFilePath, indianStateCodeHeaders);

            }
            catch (CensusAnalyserException cae)
            {
                CensusAnalyserException.ExceptionType actual = cae.eType;
                Assert.AreEqual(expected, actual);
            }


        }

    }
}