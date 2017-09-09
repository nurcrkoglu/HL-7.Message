using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.IO;

namespace HL7
{
    /// <summary>
    /// Summary description for HL7Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class HL7Service : System.Web.Services.WebService
    {
        DBProcess db = new DBProcess();


        [WebMethod]
        public string InsertMSH(string fieldSeparator, string encodingCharacters, string sendingApp, string sendingFacility, string receivingApp, string receivingFacility,  string security, string messageType, string MControlID, string ProcessingID, string versionID, string sequenceNumber, string continuationPointer, string AcceptACKType,string ApplicationACKType, string CountryCode, string CharecterSet, string PrincipalLanOfMSG, string AlternateCharSet)
        {
            string result=db.InsertMSH( fieldSeparator,  encodingCharacters,  sendingApp,  sendingFacility,  receivingApp,  receivingFacility,   security,  messageType,  MControlID,  ProcessingID,  versionID,  sequenceNumber,  continuationPointer,  AcceptACKType, ApplicationACKType,  CountryCode,  CharecterSet, PrincipalLanOfMSG,  AlternateCharSet);

            return result;
            
        }
        [WebMethod]
        public string InsertPV1(string setIDPV1, string patientClass, string assignedPatientLocation, string admissionType, string preadmitNumber, string priorPatientLocation, string attendingDoctor, string referringDoctor, string consultingDoctor, string hospitalService, string temporaryLocation, string preadmitTestIndicator, string reAdmissonIndicator, string admitSource, string ambulatoryStatus, string vıpIndicator, string admittingDoctor, string patientType, string visitNumber, string financialClass, string chargePriceIndicator, string courtesyCode, string creditCode, string contractCode, string contractAmount, string contractPeriod, string ınterertCode, string transferToBadDebtCode, string badDeptAgencyCode, string badDeptTransferAmaunt, string badDeptRecoveryAmount, string deleteAccountIndicator, string dischargeDisposition, string dischargedtoLocation, string dietType, string servicingFacility, string bedStatus, string accountStatus, string pendingLocation, string priorTemporaryLocation, string currentPatientBalance, string totalCharges, string totalAdjustments, string totalPayments, string alternateVisitID, string visitIndicator, string otherHealtcareProvider)
        {
            string result = db.InsertPV1(setIDPV1, patientClass, assignedPatientLocation, admissionType, preadmitNumber, priorPatientLocation,  attendingDoctor, referringDoctor, consultingDoctor, hospitalService, temporaryLocation, preadmitTestIndicator,  reAdmissonIndicator,  admitSource, ambulatoryStatus, vıpIndicator, admittingDoctor, patientType, visitNumber, financialClass,  chargePriceIndicator,  courtesyCode, creditCode, contractCode, contractAmount, contractPeriod, ınterertCode, transferToBadDebtCode,  badDeptAgencyCode, badDeptTransferAmaunt, badDeptRecoveryAmount, deleteAccountIndicator, dischargeDisposition, dischargedtoLocation,  dietType,  servicingFacility,  bedStatus,  accountStatus, pendingLocation, priorTemporaryLocation, currentPatientBalance, totalCharges,  totalAdjustments,  totalPayments,  alternateVisitID, visitIndicator, otherHealtcareProvider);

            return result;
        }
        [WebMethod]
        public string InsertPID(string setIDPID, string patientID, string patientIdenList, string alternatePatientID, string patientName, string mothersMaidenName,  string sex, string patientAlias, string race, string patientAddress, string countyCode, string phoneNumberHome, string phoneNumberBusiness, string primaryLanguage, string maritalStatus, string religion, string patientAccountNumber, string SSNNumberPatient, string DriversLicNumPatient, string mothersIdentifier, string ethnicGroup, string birthPlace, string multipleBirthIndicator, string birthOrder, string citizenship, string veteransMilitaryStatus, string nationality, string patientDeathIndicator)
        {
            string result = db.InsertPID( setIDPID,  patientID,  patientIdenList,  alternatePatientID,  patientName,  mothersMaidenName, sex,  patientAlias,  race,  patientAddress,  countyCode,  phoneNumberHome,  phoneNumberBusiness,  primaryLanguage,  maritalStatus,  religion,  patientAccountNumber,  SSNNumberPatient,  DriversLicNumPatient,  mothersIdentifier,  ethnicGroup,  birthPlace,  multipleBirthIndicator,  birthOrder,  citizenship,  veteransMilitaryStatus,  nationality,   patientDeathIndicator);

            return result;
        }

        [WebMethod]
        public string InsertEVN(int evetTypeCode, string dateTimePlanEvent, string evetReasonCode, int operatorID, string eventOccurred)
        {
            string result = db.InsertEVN( evetTypeCode, dateTimePlanEvent,  evetReasonCode,  operatorID, eventOccurred);

            return result;

        }
        [WebMethod]
        public string InsertAL1(string setIDAL1, string allergyType, string allerygCodeMnemonicDes, string allergySeverity, string allergyReaction)
        {
            string result = db.InsertAL1(setIDAL1, allergyType, allerygCodeMnemonicDes, allergySeverity, allergyReaction);
            return result;
        }

        [WebMethod]
        public string InsertORC(string orderControl, string placerOrderNumber, string fillerOrderNumber, string placerGroupNumber, string orderStatus, string responseFlag, string quantityTiming, string parentOrder, string enteredBy, string verifiedBy, string orderingProvider, string enterersLocation, string callBackPhoneNumber, string orderControlCodeReason, string enteringOrganization, string enteringDevice, string actionBy, string advancedBenNoticeCode, string orderingFacilityName, string orderingFacilityAddress, string orderingFacilityPhonenumber, string orderingProviderAddress)
        {
            string result = db.InsertORC(orderControl, placerOrderNumber, fillerOrderNumber, placerGroupNumber, orderStatus, responseFlag, quantityTiming, parentOrder, enteredBy, verifiedBy, orderingProvider, enterersLocation, callBackPhoneNumber, orderControlCodeReason, enteringOrganization, enteringDevice, actionBy, advancedBenNoticeCode, orderingFacilityName, orderingFacilityAddress, orderingFacilityPhonenumber, orderingProviderAddress);

            return result;
        }
        [WebMethod]
        public string SelectMSH()
        {
            string result = db.SelectMSH();
            return result;
        }
        [WebMethod]
        public string SelectPID()
        {
            string result = db.SelectPID();
            return result;
        }
        [WebMethod]
        public string SelectEVN()
        {
            string result = db.SelectEVN();
            return result;
        }
        [WebMethod]
        public string UpdateMSH(int mshID,string fieldSeparator, string encodingCharacters, string sendingApp, string sendingFacility, string receivingApp, string receivingFacility, string security, string messageType, int MControlID, int ProcessingID, int versionID, int sequenceNumber, string continuationPointer, string AcceptACKType, string ApplicationACKType, string CountryCode, string CharecterSet, string PrincipalLanOfMSG, string AlternateCharSet)
        {
            string result = db.UpdateMSH(mshID,fieldSeparator, encodingCharacters, sendingApp, sendingFacility, receivingApp, receivingFacility, security, messageType, MControlID, ProcessingID, versionID, sequenceNumber, continuationPointer, AcceptACKType, ApplicationACKType, CountryCode, CharecterSet, PrincipalLanOfMSG, AlternateCharSet);

            return result;

        }
        [WebMethod]
        public string UpdatePID(int pıdID, int setIDPID, int patientID, string patientIdenList, int alternatePatientID, string patientName, string mothersMaidenName, string sex, string patientAlias, string race, string patientAddress, string countyCode, int phoneNumberHome, int phoneNumberBusiness, string primaryLanguage, string maritalStatus, string religion, int patientAccountNumber, int SSNNumberPatient, int DriversLicNumPatient, string mothersIdentifier, string ethnicGroup, string birthPlace, string multipleBirthIndicator, string birthOrder, string citizenship, string veteransMilitaryStatus, string nationality, string patientDeathIndicator)
        {
            string result = db.UpdatePID(pıdID,setIDPID, patientID, patientIdenList, alternatePatientID, patientName, mothersMaidenName, sex, patientAlias, race, patientAddress, countyCode, phoneNumberHome, phoneNumberBusiness, primaryLanguage, maritalStatus, religion, patientAccountNumber, SSNNumberPatient, DriversLicNumPatient, mothersIdentifier, ethnicGroup, birthPlace, multipleBirthIndicator, birthOrder, citizenship, veteransMilitaryStatus, nationality, patientDeathIndicator);

            return result;

        }
       





    }
}
