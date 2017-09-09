using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HL7
{

    public class DBProcess
    {
        HL7Message.MSH msgMSH = new HL7Message.MSH();
        HL7Message.PID msgPID = new HL7Message.PID();
        HL7Message.EVN msgEVN = new HL7Message.EVN();
     
        public SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["HL7"].ConnectionString);
        public SqlCommand cmd = new SqlCommand();

        public DataTable select(string tableName)
        {
            try
            {
                ITPSystem.Log(tableName + "verileri alınıyor.");
                DatabaseOpen();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM " + tableName;

                DataTable dt = new DataTable();

                dt.Load(cmd.ExecuteReader());

                DatabaseClose();
                return dt;

            }
            catch (Exception ex)
            {
                ITPSystem.Log(ex.Message);
                return null;
            }


        }
        public void DatabaseOpen()
        {
            if (conn.State == ConnectionState.Closed)
            {
                try
                {
                    ITPSystem.Log("Bağlantı açılıyor.");
                    conn.Open();
                    cmd.Connection = conn;
                    ITPSystem.Log("Bağlantı açıldı.");
                }
                catch (Exception ex)
                {
                    ITPSystem.Log(ex.Message);
                }
            }
        }
        private void DatabaseClose()
        {
            try
            {
                conn.Close();
                ITPSystem.Log("Bağlantı kapatıldı.");
            }
            catch (Exception ex)
            {
                ITPSystem.Log(ex.Message);
            }
        }

        public string InsertMSH(string fieldSeparator, string encodingCharacters, string sendingApp, string sendingFacility, string receivingApp, string receivingFacility, string security, string messageType, string MControlID, string ProcessingID, string versionID, string sequenceNumber, string continuationPointer, string AcceptACKType, string ApplicationACKType, string CountryCode, string CharecterSet, string PrincipalLanOfMSG, string AlternateCharSet)
        {
            try
            {
                DatabaseOpen();

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO MSH(Field_Separator,Encoding_Characters,Sending_Application,Sending_Facility,Receiving_Application,Receiving_Facility,Date_Time_Of_MSG,Security,Message_Type,Message_Control_ID,Processing_ID,Version_ID,Sequence_Number,Continuation_Pointer,Accept_ACK_Type,Application_ACK_Type,Country_Code,Character_Set,Principal_Language_Of_MSG,Alternate_Char_Set) VALUES(@Field_Separator,@Encoding_Characters,@Sending_Application,@Sending_Facility,@Receiving_Application,@Receiving_Facility,@Date_Time_Of_MSG,@Security,@Message_Type,@Message_Control_ID,@Processing_ID,@Version_ID,@Sequence_Number,@Continuation_Pointer,@Accept_ACK_Type,@Application_ACK_Type,@Country_Code,@Character_Set,@Principal_Language_Of_MSG,@Alternate_Char_Set)";

                ITPSystem.Log("MSH için veriler ekleniyor.");

                cmd.Parameters.AddWithValue("@Field_Separator", fieldSeparator);
                cmd.Parameters.AddWithValue("@Encoding_Characters", encodingCharacters);
                cmd.Parameters.AddWithValue("@Sending_Application", sendingApp);
                cmd.Parameters.AddWithValue("@Sending_Facility", sendingFacility);
                cmd.Parameters.AddWithValue("@Receiving_Application", receivingApp);
                cmd.Parameters.AddWithValue("@Receiving_Facility", receivingFacility);
                cmd.Parameters.AddWithValue("@Date_Time_Of_MSG", DateTime.Now);
                cmd.Parameters.AddWithValue("@Security", security);
                cmd.Parameters.AddWithValue("@Message_Type", messageType);
                cmd.Parameters.AddWithValue("@Message_Control_ID", MControlID);
                cmd.Parameters.AddWithValue("@Processing_ID", ProcessingID);
                cmd.Parameters.AddWithValue("@Version_ID", versionID);
                cmd.Parameters.AddWithValue("@Sequence_Number", sequenceNumber);
                cmd.Parameters.AddWithValue("@Continuation_Pointer", continuationPointer);
                cmd.Parameters.AddWithValue("@Accept_ACK_Type", AcceptACKType);
                cmd.Parameters.AddWithValue("@Application_ACK_Type", ApplicationACKType);
                cmd.Parameters.AddWithValue("@Country_Code", CountryCode);
                cmd.Parameters.AddWithValue("@Character_Set", CharecterSet);
                cmd.Parameters.AddWithValue("@Principal_Language_Of_MSG", PrincipalLanOfMSG);
                cmd.Parameters.AddWithValue("@Alternate_Char_Set", AlternateCharSet);

                cmd.ExecuteNonQuery();
                DatabaseClose();

                return "MSH kaydı başarılı bir şekilde yapıldı.";

            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
        public string InsertPID(string setIDPID, string patientID, string patientIdenList, string alternatePatientID, string patientName, string mothersMaidenName, string sex, string patientAlias, string race, string patientAddress, string countyCode, string phoneNumberHome, string phoneNumberBusiness, string primaryLanguage, string maritalStatus, string religion, string patientAccountNumber, string SSNNumberPatient, string DriversLicNumPatient, string mothersIdentifier, string ethnicGroup, string birthPlace, string multipleBirthIndicator, string birthOrder, string citizenship, string veteransMilitaryStatus, string nationality, string patientDeathIndicator)
        {
            try
            {
                DatabaseOpen();

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO PID(Set_ID_PID,Patient_ID,Patient_Identifier_List,Alternate_Patient_ID,Patient_Name,Mothers_Maiden_Name,Date_Time_Of_Birth,Sex,Patient_Alias,Race,Patient_Address,County_Code,Phone_Number_Home,Phone_Number_Business,Primary_Language,Marital_Status,Religion,Patient_Account_Number,SSN_Number_Patient,Drivers_License_Number_Patient,Mothers_Identifier,Ethnic_Group,Birth_Place,Multiple_Birth_Indicator,Birth_Order,Citizenship,Veterans_Military_Status,Nationality,Patient_Death_Date_and_Time,Patient_Death_Indicator) VALUES(@Set_ID_PID,@Patient_ID,@Patient_Identifier_List,@Alternate_Patient_ID,@Patient_Name,@Mothers_Maiden_Name,@Date_Time_Of_Birth,@Sex,@Patient_Alias,@Race,@Patient_Address,@County_Code,@Phone_Number_Home,@Phone_Number_Business,@Primary_Language,@Marital_Status,@Religion,@Patient_Account_Number,@SSN_Number_Patient,@Drivers_License_Number_Patient,@Mothers_Identifier,@Ethnic_Group,@Birth_Place,@Multiple_Birth_Indicator,@Birth_Order,@Citizenship,@Veterans_Military_Status,@Nationality,@Patient_Death_Date_and_Time,@Patient_Death_Indicator)";

                ITPSystem.Log("PID için veriler ekleniyor.");

                cmd.Parameters.AddWithValue("@Set_ID_PID", setIDPID);
                cmd.Parameters.AddWithValue("@Patient_ID", patientID);
                cmd.Parameters.AddWithValue("@Patient_Identifier_List", patientIdenList);
                cmd.Parameters.AddWithValue("@Alternate_Patient_ID", alternatePatientID);
                cmd.Parameters.AddWithValue("@Patient_Name", patientName);
                cmd.Parameters.AddWithValue("@Mothers_Maiden_Name", mothersMaidenName);
                cmd.Parameters.AddWithValue("@Date_Time_Of_Birth", DateTime.Now);
                cmd.Parameters.AddWithValue("@Sex", sex);
                cmd.Parameters.AddWithValue("@Patient_Alias", patientAlias);
                cmd.Parameters.AddWithValue("@Race", race);
                cmd.Parameters.AddWithValue("@Patient_Address", patientAddress);
                cmd.Parameters.AddWithValue("@County_Code", countyCode);
                cmd.Parameters.AddWithValue("@Phone_Number_Home", phoneNumberHome);
                cmd.Parameters.AddWithValue("@Phone_Number_Business", phoneNumberBusiness);
                cmd.Parameters.AddWithValue("@Primary_Language", primaryLanguage);
                cmd.Parameters.AddWithValue("@Marital_Status", maritalStatus);
                cmd.Parameters.AddWithValue("@Religion", religion);
                cmd.Parameters.AddWithValue("@Patient_Account_Number", patientAccountNumber);
                cmd.Parameters.AddWithValue("@SSN_Number_Patient", SSNNumberPatient);
                cmd.Parameters.AddWithValue("@Drivers_License_Number_Patient", DriversLicNumPatient);
                cmd.Parameters.AddWithValue("@Mothers_Identifier", mothersIdentifier);
                cmd.Parameters.AddWithValue("@Ethnic_Group", ethnicGroup);
                cmd.Parameters.AddWithValue("@Birth_Place", birthPlace);
                cmd.Parameters.AddWithValue("@Multiple_Birth_Indicator", multipleBirthIndicator);
                cmd.Parameters.AddWithValue("@Birth_Order", birthOrder);
                cmd.Parameters.AddWithValue("@Citizenship", citizenship);
                cmd.Parameters.AddWithValue("@Veterans_Military_Status", veteransMilitaryStatus);
                cmd.Parameters.AddWithValue("@Nationality", nationality);
                cmd.Parameters.AddWithValue("@Patient_Death_Date_and_Time", DateTime.Now);
                cmd.Parameters.AddWithValue("@Patient_Death_Indicator", patientDeathIndicator);



                cmd.ExecuteNonQuery();
                DatabaseClose();

                return "PID kaydı başarılı bir şekilde yapıldı.";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string InsertPV1(string setIDPV1, string patientClass, string assignedPatientLocation, string admissionType, string preadmitNumber, string priorPatientLocation, string attendingDoctor, string referringDoctor, string consultingDoctor, string hospitalService, string temporaryLocation, string preadmitTestIndicator, string reAdmissonIndicator, string admitSource, string ambulatoryStatus, string vıpIndicator, string admittingDoctor, string patientType, string visitNumber, string financialClass, string chargePriceIndicator, string courtesyCode, string creditCode, string contractCode, string contractAmount, string contractPeriod, string ınterertCode, string transferToBadDebtCode, string badDeptAgencyCode, string badDeptTransferAmaunt, string badDeptRecoveryAmount, string deleteAccountIndicator, string dischargeDisposition, string dischargedtoLocation, string dietType, string servicingFacility, string bedStatus, string accountStatus, string pendingLocation, string priorTemporaryLocation, string currentPatientBalance, string totalCharges, string totalAdjustments, string totalPayments, string alternateVisitID, string visitIndicator, string otherHealtcareProvider)
        {
            try
            {
                DatabaseOpen();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO PV1(Set_ID_PV1,Patient_Class,Assigned_Patient_Location,Admission_Type,Preadmit_Number,Prior_Patient_Location,Attending_Doctor,Referring_Doctor,Consulting_Doctor,Hospital_Service,Temporary_Location,Preadmit_Test_Indicator,Re_admission_Indicator,Admit_Source,Ambulatory_Status,VIP_Indicator,Admitting_Doctor,Patient_Type,Visit_Number,Financial_Class,Charge_Price_Indicator,Courtesy_Code,Credit_Rating,Contract_Code,Contract_Effective_Date,Contract_Amount,Contract_Period,Interest_Code,Transfer_to_Bad_Debt_Code,Transfer_to_Bad_Debt_Date,Bad_Debt_Agency_Code,Bad_Debt_Transfer_Amount,Bad_Debt_Recovery_Amount,Delete_Account_Indicator,Delete_Account_Date,Discharge_Disposition,Discharged_to_Location,Diet_Type,Servicing_Facility,Bed_Status,Account_Status,Pending_Location,Prior_Temporary_Location,Admit_Date_Time,Discharge_Date_Time,Current_Patient_Balance,Total_Charges,Total_Adjustments,Total_Payments,Alternate_Visit_ID,Visit_Indicator,Other_Healthcare_Provider) VALUES(@Set_ID_PV1,@Patient_Class,@Assigned_Patient_Location,@Admission_Type,@Preadmit_Number,@Prior_Patient_Location,@Attending_Doctor,@Referring_Doctor,@Consulting_Doctor,@Hospital_Service,@Temporary_Location,@Preadmit_Test_Indicator,@Re_admission_Indicator,@Admit_Source,@Ambulatory_Status,@VIP_Indicator,@Admitting_Doctor,@Patient_Type,@Visit_Number,@Financial_Class,@Charge_Price_Indicator,@Courtesy_Code,@Credit_Rating,@Contract_Code,@Contract_Effective_Date,@Contract_Amount,@Contract_Period,@Interest_Code,@Transfer_to_Bad_Debt_Code,@Transfer_to_Bad_Debt_Date,@Bad_Debt_Agency_Code,@Bad_Debt_Transfer_Amount,@Bad_Debt_Recovery_Amount,@Delete_Account_Indicator,@Delete_Account_Date,@Discharge_Disposition,@Discharged_to_Location,@Diet_Type,@Servicing_Facility,@Bed_Status,@Account_Status,@Pending_Location,@Prior_Temporary_Location,@Admit_Date_Time,@Discharge_Date_Time,@Current_Patient_Balance,@Total_Charges,@Total_Adjustments,@Total_Payments,@Alternate_Visit_ID,@Visit_Indicator,@Other_Healthcare_Provider)";

                ITPSystem.Log("PV1 için veriler ekleniyor.");

                cmd.Parameters.AddWithValue("@Set_ID_PV1", setIDPV1);
                cmd.Parameters.AddWithValue("@Patient_Class", patientClass);
                cmd.Parameters.AddWithValue("@Assigned_Patient_Location", assignedPatientLocation);
                cmd.Parameters.AddWithValue("@Admission_Type", admissionType);
                cmd.Parameters.AddWithValue("@Preadmit_Number", preadmitNumber);
                cmd.Parameters.AddWithValue("@Prior_Patient_Location", priorPatientLocation);
                cmd.Parameters.AddWithValue("@Attending_Doctor", attendingDoctor);
                cmd.Parameters.AddWithValue("@Referring_Doctor", referringDoctor);
                cmd.Parameters.AddWithValue("@Consulting_Doctor", consultingDoctor);
                cmd.Parameters.AddWithValue("@Hospital_Service", hospitalService);
                cmd.Parameters.AddWithValue("@Temporary_Location", temporaryLocation);
                cmd.Parameters.AddWithValue("@Preadmit_Test_Indicator", preadmitTestIndicator);
                cmd.Parameters.AddWithValue("@Re_admission_Indicator", reAdmissonIndicator);
                cmd.Parameters.AddWithValue("@Admit_Source", admitSource);
                cmd.Parameters.AddWithValue("@Ambulatory_Status", ambulatoryStatus);
                cmd.Parameters.AddWithValue("@VIP_Indicator", vıpIndicator);
                cmd.Parameters.AddWithValue("@Admitting_Doctor", admittingDoctor);
                cmd.Parameters.AddWithValue("@Patient_Type", patientType);
                cmd.Parameters.AddWithValue("@Visit_Number", visitNumber);
                cmd.Parameters.AddWithValue("@Financial_Class", financialClass);
                cmd.Parameters.AddWithValue("@Charge_Price_Indicator", chargePriceIndicator);
                cmd.Parameters.AddWithValue("@Courtesy_Code", courtesyCode);
                cmd.Parameters.AddWithValue("@Credit_Rating", creditCode);
                cmd.Parameters.AddWithValue("@Contract_Code", contractCode);
                cmd.Parameters.AddWithValue("@Contract_Effective_Date", DateTime.Now);
                cmd.Parameters.AddWithValue("@Contract_Amount", contractAmount);
                cmd.Parameters.AddWithValue("@Contract_Period", contractPeriod);
                cmd.Parameters.AddWithValue("@Interest_Code", ınterertCode);
                cmd.Parameters.AddWithValue("@Transfer_to_Bad_Debt_Code", transferToBadDebtCode);
                cmd.Parameters.AddWithValue("@Transfer_to_Bad_Debt_Date", DateTime.Now);
                cmd.Parameters.AddWithValue("@Bad_Debt_Agency_Code", badDeptAgencyCode);
                cmd.Parameters.AddWithValue("@Bad_Debt_Transfer_Amount", badDeptTransferAmaunt);
                cmd.Parameters.AddWithValue("@Bad_Debt_Recovery_Amount", badDeptRecoveryAmount);
                cmd.Parameters.AddWithValue("@Delete_Account_Indicator", deleteAccountIndicator);
                cmd.Parameters.AddWithValue("@Delete_Account_Date", DateTime.Now);
                cmd.Parameters.AddWithValue("@Discharge_Disposition", dischargeDisposition);
                cmd.Parameters.AddWithValue("@Discharged_to_Location", dischargedtoLocation);
                cmd.Parameters.AddWithValue("@Diet_Type", dietType);
                cmd.Parameters.AddWithValue("@Servicing_Facility", servicingFacility);
                cmd.Parameters.AddWithValue("@Bed_Status", bedStatus);
                cmd.Parameters.AddWithValue("@Account_Status", accountStatus);
                cmd.Parameters.AddWithValue("@Pending_Location", pendingLocation);
                cmd.Parameters.AddWithValue("@Prior_Temporary_Location", priorTemporaryLocation);
                cmd.Parameters.AddWithValue("@Admit_Date_Time", DateTime.Now);
                cmd.Parameters.AddWithValue("@Discharge_Date_Time", DateTime.Now);
                cmd.Parameters.AddWithValue("@Current_Patient_Balance", currentPatientBalance);
                cmd.Parameters.AddWithValue("@Total_Charges", totalCharges);
                cmd.Parameters.AddWithValue("@Total_Adjustments", totalAdjustments);
                cmd.Parameters.AddWithValue("@Total_Payments", totalPayments);
                cmd.Parameters.AddWithValue("@Alternate_Visit_ID", alternateVisitID);
                cmd.Parameters.AddWithValue("@Visit_Indicator", visitIndicator);
                cmd.Parameters.AddWithValue("@Other_Healthcare_Provider", otherHealtcareProvider);


                cmd.ExecuteNonQuery();
                DatabaseClose();

                return "PV1 kaydı başarılı bir şekilde yapıldı";

            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }

        public string InsertAL1(string setIDAL1, string allergyType, string allerygCodeMnemonicDes, string allergySeverity, string allergyReaction)
        {
            try
            {
                DatabaseOpen();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO AL1(Set_ID_AL1,Allergy_Type,Allergy_Code_Mnemonic_Description,Allergy_Severity,Allergy_Reaction,Identification_Date)VALUES(@Set_ID_AL1,@Allergy_Type,@Allergy_Code_Mnemonic_Description,@Allergy_Severity,@Allergy_Reaction,@Identification_Date)";

                ITPSystem.Log("AL1 için veriler ekleniyor.");

                cmd.Parameters.AddWithValue("@Set_ID_AL1", setIDAL1);
                cmd.Parameters.AddWithValue("@Allergy_Type", allergyType);
                cmd.Parameters.AddWithValue("@Allergy_Code_Mnemonic_Description", allerygCodeMnemonicDes);
                cmd.Parameters.AddWithValue("@Allergy_Severity", allergySeverity);
                cmd.Parameters.AddWithValue("@Allergy_Reaction", allergyReaction);
                cmd.Parameters.AddWithValue("@Identification_Date", DateTime.Now);

                cmd.ExecuteNonQuery();
                DatabaseClose();

                return "AL1 kaydı başarılı bir şekilde eklendi";

            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public string InsertEVN(int evetTypeCode, string dateTimePlanEvent, string evetReasonCode, int operatorID, string eventOccurred)
        {
            try
            {
                DatabaseOpen();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO EVN (Event_Type_Code,Recorded_Date_Time,Date_Time_Planned_Event,Event_Reason_Code,Operator_ID,Event_Occurred) VALUES(@Event_Type_Code,@Recorded_Date_Time,@Date_Time_Planned_Event,@Event_Reason_Code,@Operator_ID,@Event_Occurred)";

                ITPSystem.Log("EVN için veriler ekleniyor.");

                cmd.Parameters.AddWithValue("@Event_Type_Code", evetTypeCode);
                cmd.Parameters.AddWithValue("@Recorded_Date_Time", DateTime.Now);
                cmd.Parameters.AddWithValue("@Date_Time_Planned_Event", dateTimePlanEvent);
                cmd.Parameters.AddWithValue("@Event_Reason_Code", evetReasonCode);
                cmd.Parameters.AddWithValue("@Operator_ID", operatorID);
                cmd.Parameters.AddWithValue("@Event_Occurred", eventOccurred);

                cmd.ExecuteNonQuery();
                DatabaseClose();

                return "EVN kaydı başarılı bir şekilde yapıldı.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        //public string InsertWorkList()
        //{
        //    try
        //    {
        //        DatabaseOpen();
        //        cmd.CommandType = CommandType.Text;
        //        cmd.CommandText="INSERT INTO worklist()"
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        public string InsertORC(string orderControl, string placerOrderNumber, string fillerOrderNumber, string placerGroupNumber, string orderStatus, string responseFlag, string quantityTiming, string parentOrder, string enteredBy, string verifiedBy, string orderingProvider, string enterersLocation, string callBackPhoneNumber, string orderControlCodeReason, string enteringOrganization, string enteringDevice, string actionBy, string advancedBenNoticeCode, string orderingFacilityName, string orderingFacilityAddress, string orderingFacilityPhonenumber, string orderingProviderAddress)
        {
            try
            {
                DatabaseOpen();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO ORC(Order_Control,Placer_Order_Number,Filler_Order_Number,Placer_Group_Number,Order_Status,Response_Flag,Quantity_Timing,Parent_Order,Date_Time_of_Transaction,Entered_By,Verified_By,Ordering_Provider,Enterers_Location,Call_Back_Phone_Number,Order_Effective_Date_Time,Order_Control_Code_Reason,Entering_Organization,Entering_Device,Action_By,Advanced_Beneficiary_Notice_Code,Ordering_Facility_Name,Ordering_Facility_Address,Ordering_Facility_Phone_Number,Ordering_Provider_Address) VALUES(@Order_Control,@Placer_Order_Number,@Filler_Order_Number,@Placer_Group_Number,@Order_Status,@Response_Flag,@Quantity_Timing,@Parent_Order,@Date_Time_of_Transaction,@Entered_By,@Verified_By,@Ordering_Provider,@Enterers_Location,@Call_Back_Phone_Number,@Order_Effective_Date_Time,@Order_Control_Code_Reason,@Entering_Organization,@Entering_Device,@Action_By,@Advanced_Beneficiary_Notice_Code,@Ordering_Facility_Name,@Ordering_Facility_Address,@Ordering_Facility_Phone_Number,@Ordering_Provider_Address)";

                ITPSystem.Log("ORC için veriler ekleniyor.");

                cmd.Parameters.AddWithValue("@Order_Control", orderControl);
                cmd.Parameters.AddWithValue("@Placer_Order_Number", placerOrderNumber);
                cmd.Parameters.AddWithValue("@Filler_Order_Number", fillerOrderNumber);
                cmd.Parameters.AddWithValue("@Placer_Group_Number", placerGroupNumber);
                cmd.Parameters.AddWithValue("@Order_Status", orderStatus);
                cmd.Parameters.AddWithValue("@Response_Flag", responseFlag);
                cmd.Parameters.AddWithValue("@Quantity_Timing", quantityTiming);
                cmd.Parameters.AddWithValue("@Parent_Order", parentOrder);
                cmd.Parameters.AddWithValue("@Date_Time_of_Transaction", DateTime.Now);
                cmd.Parameters.AddWithValue("@Entered_By", enteredBy);
                cmd.Parameters.AddWithValue("@Verified_By", verifiedBy);
                cmd.Parameters.AddWithValue("@Ordering_Provider", orderingProvider);
                cmd.Parameters.AddWithValue("@Enterers_Location", enterersLocation);
                cmd.Parameters.AddWithValue("@Call_Back_Phone_Number", callBackPhoneNumber);
                cmd.Parameters.AddWithValue("@Order_Effective_Date_Time", DateTime.Now);
                cmd.Parameters.AddWithValue("@Order_Control_Code_Reason", orderControlCodeReason);
                cmd.Parameters.AddWithValue("@Entering_Organization", enteringOrganization);
                cmd.Parameters.AddWithValue("@Entering_Device", enteringDevice);
                cmd.Parameters.AddWithValue("@Action_By", actionBy);
                cmd.Parameters.AddWithValue("@Advanced_Beneficiary_Notice_Code", advancedBenNoticeCode);
                cmd.Parameters.AddWithValue("@Ordering_Facility_Name", orderingFacilityName);
                cmd.Parameters.AddWithValue("@Ordering_Facility_Address", orderingFacilityAddress);
                cmd.Parameters.AddWithValue("@Ordering_Facility_Phone_Number", orderingFacilityPhonenumber);
                cmd.Parameters.AddWithValue("@Ordering_Provider_Address", orderingProviderAddress);


                cmd.ExecuteNonQuery();
                DatabaseClose();

                return "ORC kaydı başarılı bir şekilde yapıldı.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
        public string SelectMSH()
        {
            ITPSystem.Log("MSH verileri alınıyor.");
            try
            {
                // DatabaseOpen();
                // cmd.CommandType = CommandType.Text;
                // cmd.CommandText = "SELECT * FROM MSH";


                // SqlDataAdapter da = new SqlDataAdapter(cmd);
                // DataSet ds = new DataSet();
                // da.Fill(ds, "MSH");

                // string all = "";



                // foreach (DataRow msgMSH in ds.Tables[0].Rows)
                // {
                //     all = all + "|" + msgMSH[1].ToString() + "|" + msgMSH[2].ToString() + "|" + msgMSH[3].ToString() + "|" + msgMSH[4].ToString() + "|" + msgMSH[5].ToString() + "|" + msgMSH[6].ToString() + "|" + msgMSH[7].ToString() + "|" + msgMSH[8].ToString() + "|" + msgMSH[9].ToString() + "|" + msgMSH[10].ToString() + "|" + msgMSH[11].ToString() + "|" + msgMSH[12].ToString() + "|" + msgMSH[13].ToString() + "|" + msgMSH[14].ToString() + "|" + msgMSH[15].ToString() + "|" + msgMSH[16].ToString() + "|" + msgMSH[17].ToString() + "|" + msgMSH[18].ToString() + "|" + msgMSH[19].ToString() + "|" + msgMSH[20].ToString() + "|";
                // }

                // ITPSystem.Log(all);

                // ds.Dispose();
                // DatabaseClose();

                msgMSH.doldurMSH();
                return "MSH verileri geldi" + msgMSH.ToString();

            }
            catch (Exception ex)
            {
                ITPSystem.Log(ex.Message);
                return null;
            }
        }
        public string SelectPID()
        {
            ITPSystem.Log("PID verileri alınıyor.");
            try
            {
                //    DatabaseOpen();
                //    cmd.CommandType = CommandType.Text;
                //    cmd.CommandText = "SELECT * FROM PID";


                //    SqlDataAdapter da = new SqlDataAdapter(cmd);
                //    DataSet ds = new DataSet();
                //    da.Fill(ds, "PID");

                //    string all = "";

                //    //  all +="|"+ msgMSH.Field_Separator + "|" + msgMSH.Encoding_Characters + "|";

                //    foreach (DataRow msgPID in ds.Tables[0].Rows)
                //    {
                //        all = all + "|" + msgPID[1].ToString() + "|" + msgPID[2].ToString() + "|" + msgPID[3].ToString() + "|" + msgPID[4].ToString() + "|" + msgPID[5].ToString() + "|" + msgPID[6].ToString() + "|" + msgPID[7].ToString() + "|" + msgPID[8].ToString() + "|" + msgPID[9].ToString() + "|" + msgPID[10].ToString() + "|" + msgPID[11].ToString() + "|" + msgPID[12].ToString() + "|" + msgPID[13].ToString() + "|" + msgPID[14].ToString() + "|" + msgPID[15].ToString() + "|" + msgPID[16].ToString() + "|" + msgPID[17].ToString() + "|" + msgPID[18].ToString() + "|" + msgPID[19].ToString() + "|" + msgPID[20].ToString() + "|" + msgPID[21].ToString() + "|" + msgPID[22].ToString() + "|" + msgPID[23].ToString() + "|" + msgPID[24].ToString() + "|" + msgPID[25].ToString() + "|" + msgPID[26].ToString() + "|" + msgPID[27].ToString() + "|" + msgPID[28].ToString() + "|" + msgPID[29].ToString() + "|" + msgPID[30].ToString() + "|";
                //    }

                //    ITPSystem.Log(all);

                //    ds.Dispose();
                //    DatabaseClose();


                msgPID.doldurPID();
                return "PID verileri geldi : " + msgPID.ToString();

            }
            catch (Exception ex)
            {
                ITPSystem.Log(ex.Message);
                return null;
            }
        }
        public string SelectEVN()
        {
            try
            {

                ITPSystem.Log("EVN verileri alınıyor.");
                msgEVN.doldurEVN();
                return "EVN verileri alındı." + msgEVN.ToString();
            }
            catch (Exception ex)
            {
                ITPSystem.Log(ex.Message);
                return null;
            }
        }

        public string UpdateMSH(int mshID, string fieldSeparator, string encodingCharacters, string sendingApp, string sendingFacility, string receivingApp, string receivingFacility, string security, string messageType, int MControlID, int ProcessingID, int versionID, int sequenceNumber, string continuationPointer, string AcceptACKType, string ApplicationACKType, string CountryCode, string CharecterSet, string PrincipalLanOfMSG, string AlternateCharSet)
        {
            try
            {
                DatabaseOpen();

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE MSH SET Field_Separator=@Field_Separator,Encoding_Characters=@Encoding_Characters,Sending_Application=@Sending_Application,Sending_Facility=@Sending_Facility,Receiving_Application=@Receiving_Application,Receiving_Facility=@Receiving_Facility,Date_Time_Of_MSG=@Date_Time_Of_MSG,Security=@Security,Message_Type=@Message_Type,Message_Control_ID=@Message_Control_ID,Processing_ID=@Processing_ID,Version_ID=@Version_ID,Sequence_Number=@Sequence_Number,Continuation_Pointer=@Continuation_Pointer,Accept_ACK_Type=@Accept_ACK_Type,Application_ACK_Type=@Application_ACK_Type,Country_Code=@Country_Code,Character_Set=@Character_Set,Principal_Language_Of_MSG=@Principal_Language_Of_MSG,Alternate_Char_Set=@Alternate_Char_Set WHERE MSH_ID=@MSH_ID";

                ITPSystem.Log("MSH için veriler güncelleniyor..");

                cmd.Parameters.AddWithValue("@MSH_ID", mshID);
                cmd.Parameters.AddWithValue("@Field_Separator", fieldSeparator);
                cmd.Parameters.AddWithValue("@Encoding_Characters", encodingCharacters);
                cmd.Parameters.AddWithValue("@Sending_Application", sendingApp);
                cmd.Parameters.AddWithValue("@Sending_Facility", sendingFacility);
                cmd.Parameters.AddWithValue("@Receiving_Application", receivingApp);
                cmd.Parameters.AddWithValue("@Receiving_Facility", receivingFacility);
                cmd.Parameters.AddWithValue("@Date_Time_Of_MSG", DateTime.Now);
                cmd.Parameters.AddWithValue("@Security", security);
                cmd.Parameters.AddWithValue("@Message_Type", messageType);
                cmd.Parameters.AddWithValue("@Message_Control_ID", MControlID);
                cmd.Parameters.AddWithValue("@Processing_ID", ProcessingID);
                cmd.Parameters.AddWithValue("@Version_ID", versionID);
                cmd.Parameters.AddWithValue("@Sequence_Number", sequenceNumber);
                cmd.Parameters.AddWithValue("@Continuation_Pointer", continuationPointer);
                cmd.Parameters.AddWithValue("@Accept_ACK_Type", AcceptACKType);
                cmd.Parameters.AddWithValue("@Application_ACK_Type", ApplicationACKType);
                cmd.Parameters.AddWithValue("@Country_Code", CountryCode);
                cmd.Parameters.AddWithValue("@Character_Set", CharecterSet);
                cmd.Parameters.AddWithValue("@Principal_Language_Of_MSG", PrincipalLanOfMSG);
                cmd.Parameters.AddWithValue("@Alternate_Char_Set", AlternateCharSet);

                cmd.ExecuteNonQuery();
                DatabaseClose();

                return "MSH kaydı başarılı bir şekilde güncellendi.";


            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public string UpdatePID(int pıdID, int setIDPID, int patientID, string patientIdenList, int alternatePatientID, string patientName, string mothersMaidenName, string sex, string patientAlias, string race, string patientAddress, string countyCode, int phoneNumberHome, int phoneNumberBusiness, string primaryLanguage, string maritalStatus, string religion, int patientAccountNumber, int SSNNumberPatient, int DriversLicNumPatient, string mothersIdentifier, string ethnicGroup, string birthPlace, string multipleBirthIndicator, string birthOrder, string citizenship, string veteransMilitaryStatus, string nationality, string patientDeathIndicator)
        {
            try
            {
                DatabaseOpen();

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE PID SET Set_ID_PID=@Set_ID_PID,Patient_ID=@Patient_ID,Patient_Identifier_List=@Patient_Identifier_List,Alternate_Patient_ID=@Alternate_Patient_ID,Patient_Name=@Patient_Name,Mothers_Maiden_Name=@Mothers_Maiden_Name,Date_Time_Of_Birth=@Date_Time_Of_Birth,Sex=@Sex,Patient_Alias=@Patient_Alias,Race=@Race,Patient_Address=@Patient_Address,County_Code=@County_Code,Phone_Number_Home=@Phone_Number_Home,Phone_Number_Business=@Phone_Number_Business,Primary_Language=@Primary_Language,Marital_Status=@Marital_Status,Religion=@Religion,Patient_Account_Number=@Patient_Account_Number,SSN_Number_Patient=@SSN_Number_Patient,Drivers_License_Number_Patient=@Drivers_License_Number_Patient,Mothers_Identifier=@Mothers_Identifier,Ethnic_Group=@Ethnic_Group,Birth_Place=@Birth_Place,Multiple_Birth_Indicator=@Multiple_Birth_Indicator,Birth_Order=@Birth_Order,Citizenship=@Citizenship,Veterans_Military_Status=@Veterans_Military_Status,Nationality=@Nationality,Patient_Death_Date_and_Time=@Patient_Death_Date_and_Time,Patient_Death_Indicator=@Patient_Death_Indicator WHERE PID_ID=@PID_ID";

                ITPSystem.Log("PID için veriler güncellerniyor.");

                cmd.Parameters.AddWithValue("@PID_ID", pıdID);
                cmd.Parameters.AddWithValue("@Set_ID_PID", setIDPID);
                cmd.Parameters.AddWithValue("@Patient_ID", patientID);
                cmd.Parameters.AddWithValue("@Patient_Identifier_List", patientIdenList);
                cmd.Parameters.AddWithValue("@Alternate_Patient_ID", alternatePatientID);
                cmd.Parameters.AddWithValue("@Patient_Name", patientName);
                cmd.Parameters.AddWithValue("@Mothers_Maiden_Name", mothersMaidenName);
                cmd.Parameters.AddWithValue("@Date_Time_Of_Birth", DateTime.Now);
                cmd.Parameters.AddWithValue("@Sex", sex);
                cmd.Parameters.AddWithValue("@Patient_Alias", patientAlias);
                cmd.Parameters.AddWithValue("@Race", race);
                cmd.Parameters.AddWithValue("@Patient_Address", patientAddress);
                cmd.Parameters.AddWithValue("@County_Code", countyCode);
                cmd.Parameters.AddWithValue("@Phone_Number_Home", phoneNumberHome);
                cmd.Parameters.AddWithValue("@Phone_Number_Business", phoneNumberBusiness);
                cmd.Parameters.AddWithValue("@Primary_Language", primaryLanguage);
                cmd.Parameters.AddWithValue("@Marital_Status", maritalStatus);
                cmd.Parameters.AddWithValue("@Religion", religion);
                cmd.Parameters.AddWithValue("@Patient_Account_Number", patientAccountNumber);
                cmd.Parameters.AddWithValue("@SSN_Number_Patient", SSNNumberPatient);
                cmd.Parameters.AddWithValue("@Drivers_License_Number_Patient", DriversLicNumPatient);
                cmd.Parameters.AddWithValue("@Mothers_Identifier", mothersIdentifier);
                cmd.Parameters.AddWithValue("@Ethnic_Group", ethnicGroup);
                cmd.Parameters.AddWithValue("@Birth_Place", birthPlace);
                cmd.Parameters.AddWithValue("@Multiple_Birth_Indicator", multipleBirthIndicator);
                cmd.Parameters.AddWithValue("@Birth_Order", birthOrder);
                cmd.Parameters.AddWithValue("@Citizenship", citizenship);
                cmd.Parameters.AddWithValue("@Veterans_Military_Status", veteransMilitaryStatus);
                cmd.Parameters.AddWithValue("@Nationality", nationality);
                cmd.Parameters.AddWithValue("@Patient_Death_Date_and_Time", DateTime.Now);
                cmd.Parameters.AddWithValue("@Patient_Death_Indicator", patientDeathIndicator);



                cmd.ExecuteNonQuery();
                DatabaseClose();

                return "PID kaydı başarılı bir şekilde güncellendi.";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string InsertWorkList(WorkList wrklst)
        {
            try
            {
                DatabaseOpen();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO worklist(patname,patid,patotherid,patbirthdate,patbirthtime,patsex,pataddresse,patmedicalalerts,patethnicgroup,patcontrastallergies,patpregnancystatus,pathistory,patcomments,specialneeds,patstate,patconfidentialconstraint,accessionnumber,referringpysician,requestingservice,requestingphysician,sstationaetitle,spstartdate,spstarttime,modatity,sperformingphysician,spstepdescription,spstepid,sstationname,spsteplocation,premedication,requestedcontrastagent,requestedprocedureid,proceduredescription,studyinstanceuid,requestedprocedurepriority,patienttransportarrangements,readingphysician,currentlocation,resultsphysician,procedurecomments,imagingcomments,admissionid,admittingdiagnosisdescription,itp_appstatus) VALUES(@patname,@patid,@patotherid,@patbirthdate,@patbirthtime,@patsex,@pataddresse,@patmedicalalerts,@patethnicgroup,@patcontrastallergies,@patpregnancystatus,@pathistory,@patcomments,@specialneeds,@patstate,@patconfidentialconstraint,@accessionnumber,@referringpysician,@requestingservice,@requestingphysician,@sstationaetitle,@spstartdate,@spstarttime,@modatity,@sperformingphysician,@spstepdescription,@spstepid,@sstationname,@spsteplocation,@premedication,@requestedcontrastagent,@requestedprocedureid,@proceduredescription,@studyinstanceuid,@requestedprocedurepriority,@patienttransportarrangements,@readingphysician,@currentlocation,@resultsphysician,@procedurecomments,@imagingcomments,@admissionid,@admittingdiagnosisdescription,@itp_appstatus)";

                ITPSystem.Log("worklist için veriler ekleniyor.");


              //  cmd.Parameters.AddWithValue("@Status", wrklst.Status);
                cmd.Parameters.AddWithValue("@patname", wrklst.patname);
                cmd.Parameters.AddWithValue("@patid", wrklst.patid);
                cmd.Parameters.AddWithValue("@patotherid", wrklst.patotherid);
                cmd.Parameters.AddWithValue("@patbirthdate", wrklst.patbirthdate);
                cmd.Parameters.AddWithValue("@patbirthtime", wrklst.patbirthtime);
                cmd.Parameters.AddWithValue("@patsex", wrklst.patsex);
                cmd.Parameters.AddWithValue("@pataddresse", wrklst.pataddresse);
                cmd.Parameters.AddWithValue("@patmedicalalerts", wrklst.patmedicalalerts);
                cmd.Parameters.AddWithValue("@patethnicgroup", wrklst.patethnicgroup);
                cmd.Parameters.AddWithValue("@patcontrastallergies", wrklst.patcontrastallergies);
                cmd.Parameters.AddWithValue("@patpregnancystatus", wrklst.patpregnancystatus);
                cmd.Parameters.AddWithValue("@pathistory", " ");
                cmd.Parameters.AddWithValue("@patcomments", wrklst.patcomments);
                cmd.Parameters.AddWithValue("@specialneeds", " ");
                cmd.Parameters.AddWithValue("@patstate", wrklst.patstate);
                cmd.Parameters.AddWithValue("@patconfidentialconstraint", wrklst.patconfidentialconstraint);
                cmd.Parameters.AddWithValue("@accessionnumber", wrklst.accessionnumber);
                cmd.Parameters.AddWithValue("@referringpysician", wrklst.referringpysician);
                cmd.Parameters.AddWithValue("@requestingservice"," ");
                cmd.Parameters.AddWithValue("@requestingphysician", wrklst.requestingphysician);
                cmd.Parameters.AddWithValue("@sstationaetitle", wrklst.sstationaetitle);
                cmd.Parameters.AddWithValue("@spstartdate", wrklst.spstartdate);
                cmd.Parameters.AddWithValue("@spstarttime", wrklst.spstarttime);
                cmd.Parameters.AddWithValue("@modatity", wrklst.modatity);
                cmd.Parameters.AddWithValue("@sperformingphysician", wrklst.sperformingphysician);
                cmd.Parameters.AddWithValue("@spstepdescription"," ");
                cmd.Parameters.AddWithValue("@spstepid", wrklst.spstepid);
                cmd.Parameters.AddWithValue("@sstationname", " ");
                cmd.Parameters.AddWithValue("@spsteplocation", " ");
                cmd.Parameters.AddWithValue("@premedication", " ");
                cmd.Parameters.AddWithValue("@requestedcontrastagent", " ");
                cmd.Parameters.AddWithValue("@requestedprocedureid", wrklst.requestedprocedureid);
                cmd.Parameters.AddWithValue("@proceduredescription", wrklst.proceduredescription);
                cmd.Parameters.AddWithValue("@studyinstanceuid", " ");
                cmd.Parameters.AddWithValue("@requestedprocedurepriority", " ");
                cmd.Parameters.AddWithValue("@patienttransportarrangements", wrklst.patienttransportarrangements);
                cmd.Parameters.AddWithValue("@readingphysician", " ");
                cmd.Parameters.AddWithValue("@currentlocation", wrklst.currentlocation);
                cmd.Parameters.AddWithValue("@resultsphysician", " ");
                cmd.Parameters.AddWithValue("@procedurecomments", " ");
                cmd.Parameters.AddWithValue("@imagingcomments", " ");
                cmd.Parameters.AddWithValue("@admissionid", wrklst.admissionid);
                cmd.Parameters.AddWithValue("@admittingdiagnosisdescription", " ");
                cmd.Parameters.AddWithValue("@itp_appstatus", " ");




                cmd.ExecuteNonQuery();
                DatabaseClose();

                return "worklist kaydı başarılı bir şekilde yapıldı.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}