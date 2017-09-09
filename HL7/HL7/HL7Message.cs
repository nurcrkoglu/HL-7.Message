using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace HL7
{
    public class HL7Message
    {
        public static DBProcess db = new DBProcess();

        public class MSH
        {
            //  public string version;                                          SEQ	    LENGTH	 DT	OPT	RPT / #	TBL #	     NAME    
            public string Field_Separator;                                    //MSH.1	1	ST R	1	                       Field Separator
            public string Encoding_Characters;                                //MSH.2	4	ST	R	1		                   Encoding Characters
            public string Sending_Application;                                //MSH.3	180	HD	O	1	        0361	       Sending Application
            public string Sending_Facility;                                   //MSH.4	180	HD	O	1	        0362	       Sending Facility
            public string Receiving_Application;                              //MSH.5	180	HD	O	1	        0361	       Receiving Application
            public string Receiving_Facility;                                //MSH.6	180	HD	O	1	        0362	       Receiving Facility
            public string Date_Time_Of_MSG;                                   // MSH.7	26	TS O	1		                    Date/Time Of Message
            public string Security;                                           //MSH.8	40	ST O	1		                    Security
            public string Message_Type;                                      //MSH.9	7	MSG R	1		                    Message Type
            public string Message_Control_ID;                                 //MSH.10	20	ST R	1		Message Control ID
            public string Processing_ID;                                     //MSH.11	3	PT R	1		Processing ID
            public string Version_ID;                                        //MSH.12	60	VID R	1		Version ID
            public string Sequence_Number;                                   // MSH.13	15	NM O	1		Sequence Number
            public string Continuation_Pointer;                              // MSH.14	180	ST O	1		Continuation Pointer
            public string Accept_ACK_Type;                                   //MSH.15	2	ID O	1	0155	Accept Acknowledgment Type
            public string Application_ACK_Type;                              // MSH.16	2	ID O	1	0155	Application Acknowledgment Type
            public string Country_Code;                                      //MSH.17	2	ID O	1		Country Code
            public string Character_Set;                                     // MSH.18	16	ID O	*	0211	Character Set
            public string Principal_Language_Of_MSG;                        //MSH.19	60	CE O	1		Principal Language Of Message
            public string Alternate_Char_Set;
            public string s = "|";
            // MSH.20	20	ID O	1	0356	Alternate Character Set Handling Scheme

            public override string ToString()
            {
                string result = s + Field_Separator + s + Encoding_Characters + s + Sending_Application + s + Sending_Facility + s + Receiving_Application + s + Receiving_Facility + s + Date_Time_Of_MSG + s + Security + s + Message_Type + s + Message_Control_ID + s + Processing_ID + s + Version_ID + s + Sequence_Number + s + Continuation_Pointer + s + Accept_ACK_Type + s + Application_ACK_Type + s + Country_Code + s + Character_Set + s + Principal_Language_Of_MSG + s + Alternate_Char_Set + s;
                return result;
            }
            public void doldurMSH()
            {
                DataTable dt = db.select("MSH");

                foreach (DataRow row in dt.Rows)
                {
                    foreach (DataColumn column in dt.Columns)
                    {
                        Field_Separator = row["Field_Separator"].ToString();
                        Encoding_Characters = row["Encoding_Characters"].ToString();
                        Sending_Application = row["Sending_Application"].ToString();
                        Sending_Facility = row["Sending_Facility"].ToString();
                        Receiving_Application = row["Receiving_Application"].ToString();
                        Receiving_Facility = row["Receiving_Facility"].ToString();
                        Date_Time_Of_MSG = row["Date_Time_Of_MSG"].ToString();
                        Security = row["Security"].ToString();
                        Message_Type = row["Message_Type"].ToString();
                        Message_Control_ID = row["Message_Control_ID"].ToString();
                        Processing_ID = row["Processing_ID"].ToString();
                        Version_ID = row["Version_ID"].ToString();
                        Sequence_Number = row["Sequence_Number"].ToString();
                        Continuation_Pointer = row["Continuation_Pointer"].ToString();
                        Accept_ACK_Type = row["Accept_ACK_Type"].ToString();
                        Country_Code = row["Country_Code"].ToString();
                        Character_Set = row["Character_Set"].ToString();
                        Principal_Language_Of_MSG = row["Principal_Language_Of_MSG"].ToString();
                        Alternate_Char_Set = row["Alternate_Char_Set"].ToString();
                    }
                }
            }
            public void Parse(string str)
            {
                if (str.Contains("MSH"))
                {
                    int i = str.IndexOf("MSH");
                    string MSH = str.Substring(i);

                    Char delimiter = '|';
                    String[] words = MSH.Split(delimiter);


                    Field_Separator = words[1];
                    Encoding_Characters = words[2];
                    Sending_Application = words[3];
                    Sending_Facility = words[4];
                    Receiving_Application = words[5];
                    Receiving_Facility = words[6];
                    Date_Time_Of_MSG = words[7];
                    Security = words[8];
                    Message_Type = words[9];
                    Message_Control_ID = words[10];
                    Processing_ID = words[11];
                    Version_ID = words[12];
                    Sequence_Number = words[13];
                    Continuation_Pointer = words[14];
                    Accept_ACK_Type = words[15];
                    Application_ACK_Type = words[16];
                    Country_Code = words[17];
                    Character_Set = words[18];
                    Principal_Language_Of_MSG = words[19];
                    Alternate_Char_Set = words[20];

                    
                }

            }
            public void save()
            {

                db.InsertMSH(Field_Separator, Encoding_Characters, Sending_Application, Sending_Facility, Receiving_Application, Receiving_Facility, Security, Message_Type, Message_Control_ID, Processing_ID, Version_ID, Sequence_Number, Continuation_Pointer, Accept_ACK_Type, Application_ACK_Type, Country_Code, Character_Set, Principal_Language_Of_MSG, Alternate_Char_Set);


            }
        }
        public class PID
        {
            public string Set_ID_PID;
            public string Patient_ID;
            public string Patient_Identifier_List;
            public string Alternate_Patient_ID;
            public string Patient_Name;
            public string Mothers_Maiden_Name;
            public string Date_Time_Of_Birth;
            public string Sex;
            public string Patient_Alias;
            public string Race;
            public string Patient_Address;
            public string County_Code;
            public string Phone_Number_Home;
            public string Phone_Number_Business;
            public string Primary_Language;
            public string Marital_Status;
            public string Religion;
            public string Patient_Account_Number;
            public string SSN_Number_Patient;
            public string Drivers_License_Number_Patient;
            public string Mothers_Identifier;
            public string Ethnic_Group;
            public string Birth_Place;
            public string Multiple_Birth_Indicator;
            public string Birth_Order;
            public string Citizenship;
            public string Veterans_Military_Status;
            public string Nationality;
            public string Patient_Death_Date_and_Time;
            public string Patient_Death_Indicator;
            public string s = "|";

            public override string ToString()
            {
                string result = s + Set_ID_PID + s + Patient_ID + s + Patient_Identifier_List + s + Alternate_Patient_ID + s + Patient_Name + s + Mothers_Maiden_Name + s + Date_Time_Of_Birth + s + Sex + s + Patient_Alias + s + Race + s + Patient_Address + s + County_Code + s + Phone_Number_Home + s + Phone_Number_Business + s + Primary_Language + s + Marital_Status + s + Religion + s + Patient_Account_Number + s + SSN_Number_Patient + s + Drivers_License_Number_Patient + s + Mothers_Identifier + s + Ethnic_Group + s + Birth_Place + s + Multiple_Birth_Indicator + s + Birth_Order + s + Citizenship + s + Veterans_Military_Status + s + Nationality + s + Patient_Death_Date_and_Time + s + Patient_Death_Indicator + s;
                return result;
                //  return base.ToString(); bu metotta çalışıyor.
            }
            public void doldurPID()
            {
                DataTable dt = db.select("PID");

                foreach (DataRow row in dt.Rows)
                {
                    foreach (DataColumn column in dt.Columns)
                    {
                        Set_ID_PID = row["Set_ID_PID"].ToString();
                        Patient_ID = row["Patient_ID"].ToString();
                        Patient_Identifier_List = row["Patient_Identifier_List"].ToString();
                        Alternate_Patient_ID = row["Alternate_Patient_ID"].ToString();
                        Patient_Name = row["Patient_Name"].ToString();
                        Mothers_Maiden_Name = row["Mothers_Maiden_Name"].ToString();
                        Date_Time_Of_Birth = row["Date_Time_Of_Birth"].ToString();
                        Sex = row["Sex"].ToString();
                        Patient_Alias = row["Patient_Alias"].ToString();
                        Race = row["Race"].ToString();
                        Patient_Address = row["Patient_Address"].ToString();
                        County_Code = row["County_Code"].ToString();
                        Phone_Number_Home = row["Phone_Number_Home"].ToString();
                        Phone_Number_Business = row["Phone_Number_Business"].ToString();
                        Mothers_Identifier = row["Mothers_Identifier"].ToString();
                        Ethnic_Group = row["Ethnic_Group"].ToString();
                        Birth_Place = row["Birth_Place"].ToString();
                        Multiple_Birth_Indicator = row["Multiple_Birth_Indicator"].ToString();
                        Birth_Order = row["Birth_Order"].ToString();
                        Citizenship = row["Citizenship"].ToString();
                        Veterans_Military_Status = row["Veterans_Military_Status"].ToString();
                        Nationality = row["Nationality"].ToString();
                        Patient_Death_Date_and_Time = row["Patient_Death_Date_and_Time"].ToString();
                        Patient_Death_Indicator = row["Patient_Death_Indicator"].ToString();
                    }
                }
            }
            public void Parse(string text)
            {
                if (text.Contains("PID"))
                {
                    int i = text.IndexOf("PID");//PID nin kaçıncı indexte olduğunu buluyor.
                    string PID = text.Substring(i);

                    Char delimiter = '|';
                    String[] words = PID.Split(delimiter);

                    Set_ID_PID = words[1];
                    Patient_ID = words[2];
                    Patient_Identifier_List = words[3];
                    Alternate_Patient_ID = words[4];
                    Patient_Name = words[5];
                    Mothers_Maiden_Name = words[6];
                    Date_Time_Of_Birth = words[7];
                    Sex = words[8];
                    Patient_Alias = words[9];
                    Race = words[10];
                    Patient_Address = words[11];
                    County_Code = words[12];
                    Phone_Number_Home = words[13];
                    Phone_Number_Business = words[14];
                    Primary_Language = words[15];
                    Marital_Status = words[16];
                    Religion = words[17];
                    Patient_Account_Number = words[18];
                    SSN_Number_Patient = words[19];
                    Drivers_License_Number_Patient = words[20];
                    Mothers_Identifier = words[21];
                    Birth_Place = words[22];
                    Multiple_Birth_Indicator = words[23];
                    Birth_Order = words[24];
                    Citizenship = words[25];
                    Veterans_Military_Status = words[26];
                    Nationality = words[27];
                    Patient_Death_Date_and_Time = words[28];
                    Patient_Death_Indicator = words[29];
                }
            }
            public void Save()
            {
                db.InsertPID(Set_ID_PID, Patient_ID, Patient_Identifier_List, Alternate_Patient_ID, Patient_Name, Mothers_Maiden_Name, Sex, Patient_Alias, Race, Patient_Address, County_Code, Phone_Number_Home, Phone_Number_Business, Primary_Language, Marital_Status, Religion, Patient_Account_Number, SSN_Number_Patient, Drivers_License_Number_Patient, Mothers_Identifier, Ethnic_Group, Birth_Place, Multiple_Birth_Indicator, Birth_Order, Citizenship, Veterans_Military_Status, Nationality, Patient_Death_Indicator);
            }
        }
        public class EVN
        {
            public string Event_Type_Code;
            public string Recorded_Date_Time;
            public string Date_Time_Planned_Event;
            public string Event_Reason_Code;
            public string Operator_ID;
            public string Event_Occurred;
            public string s = "|";

            public override string ToString()
            {
                string result = s + Event_Type_Code + s + Recorded_Date_Time + s + Date_Time_Planned_Event + s + Event_Reason_Code + s + Operator_ID + s + Event_Occurred + s;
                return result;
            }

            public void doldurEVN()
            {
                DataTable dt = db.select("EVN");

                foreach (DataRow row in dt.Rows)
                {
                    foreach (DataColumn column in dt.Columns)
                    {
                        Event_Type_Code = row["Event_Type_Code"].ToString();
                        Recorded_Date_Time = row["Recorded_Date_Time"].ToString();
                        Date_Time_Planned_Event = row["Date_Time_Planned_Event"].ToString();
                        Event_Reason_Code = row["Event_Reason_Code"].ToString();
                        Operator_ID = row["Operator_ID"].ToString();
                        Event_Occurred = row["Event_Occurred"].ToString();
                    }
                }
            }
        }
        public class PV1
        {
            public string Set_ID_PV1;
            public string Patient_Class;
            public string Assigned_Patient_Location;
            public string Admission_Type;
            public string Preadmit_Number;
            public string Prior_Patient_Location;
            public string Attending_Doctor;
            public string Referring_Doctor;
            public string Consulting_Doctor;
            public string Hospital_Service;
            public string Temporary_Location;
            public string Preadmit_Test_Indicator;
            public string Re_admission_Indicator;
            public string Admit_Source;
            public string Ambulatory_Status;
            public string VIP_Indicator;
            public string Admitting_Doctor;
            public string Patient_Type;
            public string Visit_Number;
            public string Financial_Class;
            public string Charge_Price_Indicator;
            public string Courtesy_Code;
            public string Credit_Rating;
            public string Contract_Code;
            public string Contract_Effective_Date;
            public string Contract_Amount;
            public string Contract_Period;
            public string Interest_Code;
            public string Transfer_to_Bad_Debt_Code;
            public string Transfer_to_Bad_Debt_Date;
            public string Bad_Debt_Agency_Code;
            public string Bad_Debt_Transfer_Amount;
            public string Bad_Debt_Recovery_Amount;
            public string Delete_Account_Indicator;
            public string Delete_Account_Date;
            public string Discharge_Disposition;
            public string Discharged_to_Location;
            public string Diet_Type;
            public string Servicing_Facility;
            public string Bed_Status;
            public string Account_Status;
            public string Pending_Location;
            public string Prior_Temporary_Location;
            public string Admit_Date_Time;
            public string Discharge_Date_Time;
            public string Current_Patient_Balance;
            public string Total_Charges;
            public string Total_Adjustments;
            public string Total_Payments;
            public string Alternate_Visit_ID;
            public string Visit_Indicator;
            public string Other_Healthcare_Provider;
            public string s = "|";

            public override string ToString()
            {
                string result = s + Set_ID_PV1 + s + Patient_Class + s + Assigned_Patient_Location + s + Admission_Type + s + Preadmit_Number + s + Prior_Patient_Location + s + Attending_Doctor + s + Referring_Doctor + s + Consulting_Doctor + s + Hospital_Service + s + Temporary_Location + s + Preadmit_Test_Indicator + s + Re_admission_Indicator + s + Admit_Source + s + Ambulatory_Status + s + VIP_Indicator + s + Admitting_Doctor + s + Patient_Type + s + Visit_Number + s + Financial_Class + s + Charge_Price_Indicator + s + Courtesy_Code + s + Credit_Rating + s + Contract_Code + s + Contract_Effective_Date + s + Contract_Amount + s + Contract_Period + s + Interest_Code + s + Transfer_to_Bad_Debt_Code + s + Transfer_to_Bad_Debt_Date + s + Bad_Debt_Agency_Code + s + Bad_Debt_Transfer_Amount + s + Bad_Debt_Recovery_Amount + s + Delete_Account_Indicator + s + Delete_Account_Date + s + Discharge_Disposition + s + Discharged_to_Location + s + Diet_Type + s + Servicing_Facility + s + Bed_Status + s + Account_Status + s + Pending_Location + s + Prior_Temporary_Location + s + Admit_Date_Time + s + Discharge_Date_Time + s + Current_Patient_Balance + s + Total_Charges + s + Total_Adjustments + s + Total_Payments + s + Alternate_Visit_ID + s + Visit_Indicator + s + Other_Healthcare_Provider + s;
                return result;
            }
            public void Parse(string text)
            {
                if (text.Contains("PV1"))
                {
                    int i = text.IndexOf("PV1");//PV1 in hangi indexte olduğunu gösteriyor.
                    string PV1 = text.Substring(i);

                    Char delimiter = '|';
                    String[] words = PV1.Split(delimiter);

                    Set_ID_PV1 = words[1];
                    Patient_Class = words[2];
                    Assigned_Patient_Location = words[3];
                    Admission_Type = words[4];
                    Preadmit_Number = words[5];
                    Prior_Patient_Location = words[6];
                    Attending_Doctor = words[7];
                    Referring_Doctor = words[8];
                    Consulting_Doctor = words[9];
                    Hospital_Service = words[10];
                    Temporary_Location = words[11];
                    Preadmit_Test_Indicator = words[12];
                    Re_admission_Indicator = words[13];
                    Admit_Source = words[14];
                    Ambulatory_Status = words[15];
                    VIP_Indicator = words[16];
                    Admitting_Doctor = words[17];
                    Patient_Type = words[18];
                    Visit_Number = words[19];
                    Financial_Class = words[20];
                    Charge_Price_Indicator = words[21];
                    Courtesy_Code = words[22];
                    Credit_Rating = words[23];
                    Contract_Code = words[24];
                    Contract_Effective_Date = words[25];
                    Contract_Amount = words[26];
                    Contract_Period = words[27];
                    Interest_Code = words[28];
                    Transfer_to_Bad_Debt_Code = words[29];
                    Transfer_to_Bad_Debt_Date = words[30];
                    Bad_Debt_Agency_Code = words[31];
                    Bad_Debt_Transfer_Amount = words[32];
                    Bad_Debt_Recovery_Amount = words[33];
                    Delete_Account_Indicator = words[34];
                    Delete_Account_Date = words[35];
                    Discharge_Disposition = words[36];
                    Discharged_to_Location = words[37];
                    Diet_Type = words[38];
                    Servicing_Facility = words[39];
                    Bed_Status = words[40];
                    Account_Status = words[41];
                    Pending_Location = words[42];
                    Prior_Temporary_Location = words[43];
                    Admit_Date_Time = words[44];
                    Discharge_Date_Time = words[45];
                    Current_Patient_Balance = words[46];
                    Total_Charges = words[47];
                    Total_Adjustments = words[48];
                    Total_Payments = words[49];
                    Alternate_Visit_ID = words[50];
                    Visit_Indicator = words[51];
                    Other_Healthcare_Provider = words[52];
                }
            }
            public void Save()
            {
                db.InsertPV1(Set_ID_PV1, Patient_Class, Assigned_Patient_Location, Admission_Type, Preadmit_Number, Prior_Patient_Location, Attending_Doctor, Referring_Doctor, Consulting_Doctor, Hospital_Service, Temporary_Location, Preadmit_Test_Indicator, Re_admission_Indicator, Admit_Source, Ambulatory_Status, VIP_Indicator, Admitting_Doctor, Patient_Type, Visit_Number, Financial_Class, Charge_Price_Indicator, Courtesy_Code, Credit_Rating, Contract_Code, Contract_Amount, Contract_Period, Interest_Code, Transfer_to_Bad_Debt_Code, Bad_Debt_Agency_Code, Bad_Debt_Transfer_Amount, Bad_Debt_Recovery_Amount, Delete_Account_Indicator, Discharge_Disposition, Discharged_to_Location, Diet_Type, Servicing_Facility, Bed_Status, Account_Status, Pending_Location, Prior_Temporary_Location, Current_Patient_Balance, Total_Charges, Total_Adjustments, Total_Payments, Alternate_Visit_ID, Visit_Indicator, Other_Healthcare_Provider);
            }
        }
        public class ORC
        {
            public string Order_Control;
            public string Placer_Order_Number;
            public string Filler_Order_Number;
            public string Placer_Group_Number;
            public string Order_Status;
            public string Response_Flag;
            public string Quantity_Timing;
            public string Parent_Order;
            public string Date_Time_of_Transaction;
            public string Entered_By;
            public string Verified_By;
            public string Ordering_Provider;
            public string Enterers_Location;
            public string Call_Back_Phone_Number;
            public string Order_Effective_Date_Time;
            public string Order_Control_Code_Reason;
            public string Entering_Organization;
            public string Entering_Device;
            public string Action_By;
            public string Advanced_Beneficiary_Notice_Code;
            public string Ordering_Facility_Name;
            public string Ordering_Facility_Address;
            public string Ordering_Facility_Phone_Number;
            public string Ordering_Provider_Address;
            public string s = "|";

            public override string ToString()
            {
                string result = s + Order_Control + s + Placer_Order_Number + s + Filler_Order_Number + s + Placer_Group_Number + s + Order_Status + s + Response_Flag + s + Quantity_Timing + s + Parent_Order + s + Date_Time_of_Transaction + s + Entered_By + s + Verified_By + s + Ordering_Provider + s + Enterers_Location + s + Call_Back_Phone_Number + s + Order_Effective_Date_Time + s + Order_Control_Code_Reason + s + Entering_Organization + s + Entering_Device + s + Action_By + s + Advanced_Beneficiary_Notice_Code + s + Ordering_Facility_Name + s + Ordering_Facility_Address + s + Ordering_Facility_Phone_Number + s + Ordering_Provider_Address + s;
                return result;
            }
            public void Parse(string text)
            {
                if (text.Contains("ORC"))
                {
                    int i = text.IndexOf("ORC");
                    string ORC = text.Substring(i);

                    Char delimiter = '|';
                    String[] words = ORC.Split(delimiter);

                    Order_Control = words[1];
                    Placer_Order_Number = words[2];
                    Filler_Order_Number = words[3];
                    Placer_Group_Number = words[4];
                    Order_Status = words[5];
                    Response_Flag = words[6];
                    Quantity_Timing = words[7];
                    Parent_Order = words[8];
                    Date_Time_of_Transaction = words[9];
                    Entered_By = words[10];
                    Verified_By = words[11];
                    Ordering_Provider = words[12];
                    Enterers_Location = words[13];
                    Call_Back_Phone_Number = words[14];
                    Order_Effective_Date_Time = words[15];
                    Order_Control_Code_Reason = words[16];
                    Entering_Organization = words[17];
                    Entering_Device = words[18];
                    Action_By = words[19];
                    Advanced_Beneficiary_Notice_Code = words[20];
                    Ordering_Facility_Name = words[21];
                    Ordering_Facility_Address = words[22];
                    Ordering_Facility_Phone_Number = words[23];
                    Ordering_Provider_Address = words[24];
                }
                else
                {

                    Order_Control="";
                    Placer_Order_Number="";
                    Filler_Order_Number = "";
                    Placer_Group_Number = "";
                    Order_Status = "";
                    Response_Flag = "";
                    Quantity_Timing = "";
                    Parent_Order = "";
                    Date_Time_of_Transaction = "";
                    Entered_By = "";
                    Verified_By = "";
                    Ordering_Provider = "";
                    Enterers_Location = "";
                    Call_Back_Phone_Number = "";
                    Order_Effective_Date_Time = "";
                    Order_Control_Code_Reason = "";
                    Entering_Organization = "";
                    Entering_Device = "";
                    Action_By = "";
                    Advanced_Beneficiary_Notice_Code = "";
                    Ordering_Facility_Name = "";
                    Ordering_Facility_Address = "";
                    Ordering_Facility_Phone_Number = "";
                    Ordering_Provider_Address = "";
                }
            }
            public void save()
            {
                db.InsertORC(Order_Control, Placer_Order_Number, Filler_Order_Number, Placer_Group_Number, Order_Status, Response_Flag, Quantity_Timing, Parent_Order, Entered_By, Verified_By, Ordering_Provider, Enterers_Location, Call_Back_Phone_Number, Order_Control_Code_Reason, Entering_Organization, Entering_Device, Action_By, Advanced_Beneficiary_Notice_Code, Ordering_Facility_Name, Ordering_Facility_Address, Ordering_Facility_Phone_Number, Ordering_Provider_Address);
            }

        }
        public class OBR
        {
            public string Set_ID_OBR;
            public string Placer_Order_Number;
            public string Filler_Order_Number;
            public string Universal_Service_ID;
            public string Priority_OBR;
            public string Requested_Date_time;
            public string Observation_Date_Time;
            public string Observation_End_Date_Time;
            public string Collection_Volume;
            public string Collector_Identifier;
            public string Specimen_Action_Code;
            public string Danger_Code;
            public string Relevant_Clinical_Info;
            public string Specimen_Received_Date_Time;
            public string Specimen_Source;
            public string Ordering_Provider;
            public string Order_Callback_Phone_Number;
            public string Placer_Field_1;
            public string Placer_Field_2;
            public string Filler_Field_1;
            public string Filler_Field_2;
            public string Results_Rpt_Status_Chng_Date_Time;
            public string Charge_to_Practice;
            public string Diagnostic_Serv_Sect_ID;
            public string Result_Status;
            public string Parent_Result;
            public string Quantity_Timing;
            public string Result_Copies_To;
            public string Parent_Number;
            public string Transportation_Mode;
            public string Reason_for_Study;
            public string Principal_Result_Interpreter;
            public string Assistant_Result_Interpreter;
            public string Technician;
            public string Transcriptionist;
            public string Scheduled_Date_Time;
            public string Number_of_Sample_Containers;
            public string Transport_Logistics_of_Collected_Sample;
            public string Collectors_Comment;
            public string Transport_Arrangement_Responsibility;
            public string Transport_Arranged;
            public string Escort_Required;
            public string Planned_Patient_Transport_Comment;
            public string Procedure_Code;
            public string Procedure_Code_Modifier;
            public string s = "|";

            public void Parse(string text)
            {
                if (text.Contains("OBR"))
                {
                    int i = text.IndexOf("OBR");
                    string OBR = text.Substring(i);

                    Char delimiter = '|';
                    String[] words = OBR.Split(delimiter);

                    Set_ID_OBR=words[1];
                    Placer_Order_Number=words[2];
                    Filler_Order_Number = words[3];
                    Universal_Service_ID = words[4];
                    Priority_OBR = words[5];
                    Requested_Date_time = words[6];
                    Observation_Date_Time = words[7];
                    Observation_End_Date_Time = words[8];
                    Collection_Volume = words[9];
                    Collector_Identifier = words[10];
                    Specimen_Action_Code = words[11];
                    Danger_Code = words[12];
                    Relevant_Clinical_Info = words[13];
                    Specimen_Received_Date_Time = words[14];
                    Specimen_Source = words[15];
                    Ordering_Provider = words[16];
                    Order_Callback_Phone_Number = words[17];
                    Placer_Field_1 = words[18];
                    Placer_Field_2 = words[19];
                    Filler_Field_1 = words[20];
                    Filler_Field_2 = words[21];
                    Results_Rpt_Status_Chng_Date_Time = words[22];
                    Charge_to_Practice = words[23];
                    Diagnostic_Serv_Sect_ID = words[24];
                    Result_Status = words[25];
                    Parent_Result = words[26];
                    Quantity_Timing = words[27];
                    Result_Copies_To = words[28];
                    Parent_Number = words[29];
                    Transportation_Mode = words[30];
                    Reason_for_Study = words[31];
                    Principal_Result_Interpreter = words[32];
                    Assistant_Result_Interpreter = words[33];
                    Technician = words[34];
                    Transcriptionist = words[35];
                    Scheduled_Date_Time = words[36];
                    Number_of_Sample_Containers = words[37];
                    Transport_Logistics_of_Collected_Sample = words[38];
                    Collectors_Comment = words[39];
                    Transport_Arrangement_Responsibility = words[40];
                    Transport_Arranged = words[41];
                    Escort_Required = words[42];
                    Planned_Patient_Transport_Comment = words[43];
                    Procedure_Code = words[44];
                    Procedure_Code_Modifier = words[45];
                }
            }


        }
        public class AL1
        {
            public string Set_ID_AL1;
            public string Allergy_Type;
            public string Allergy_Code_Mnemonic_Description;
            public string Allergy_Severity;
            public string Allergy_Reaction;
            public string Identification_Date;
            public string s = "|";

            public override string ToString()
            {
                string result = s + Set_ID_AL1 + s + Allergy_Type + s + Allergy_Code_Mnemonic_Description + s + Allergy_Severity + s + Allergy_Reaction + s + Identification_Date + s;
                return result;
            }
            public void Parse(string text)
            {
                if (text.Contains("AL1"))
                {
                    int i = text.IndexOf("AL1");
                    string AL1 = text.Substring(i);

                    Char delimiter = '|';
                    String[] words = AL1.Split(delimiter);

                    Set_ID_AL1 = words[1];
                    Allergy_Type = words[2];
                    Allergy_Code_Mnemonic_Description = words[3];
                    Allergy_Severity = words[4];
                    Allergy_Reaction = words[5];
                    Identification_Date = words[6];
                }
                else
                {
                    Set_ID_AL1="";
                    Allergy_Type="";
                    Allergy_Code_Mnemonic_Description="";
                    Allergy_Severity="";
                    Allergy_Reaction="";
                    Identification_Date="";
                }
            }

            public void Save()
            {
                db.InsertAL1(Set_ID_AL1, Allergy_Type, Allergy_Code_Mnemonic_Description, Allergy_Severity, Allergy_Reaction);
            }
        }
        public class NTE
        {
            public string Set_ID_NTE;
            public string Source_of_Comment;
            public string Comment;
            public string Comment_Type;
            public string s="|";

            public override string ToString()
            {
                string result = s + Set_ID_NTE + s + Source_of_Comment + s + Comment + s + Comment_Type + s ;
                return result;
            }
            public void Parse(string text)
            {
                if (text.Contains("NTE"))
                {
                    int i = text.IndexOf("NTE");
                    string NTE = text.Substring(i);

                    Char delimiter = '|';
                    String[] words = NTE.Split(delimiter);

                    Set_ID_NTE = words[1];
                    Source_of_Comment = words[2];
                    Comment = words[3];
                    Comment_Type = words[4];
                }
                else
                {
                    Set_ID_NTE = " ";
                    Source_of_Comment = " ";
                    Comment = " ";
                    Comment_Type = " ";
                }
            }

        }

    }
}
