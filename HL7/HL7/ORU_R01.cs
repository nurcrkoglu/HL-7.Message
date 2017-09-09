using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HL7
{
    public class ORU_R01:BaseMessage //inheritance
    {
        public HL7Message.PID PID { get; set; } //property //hem read hem write
        public HL7Message.AL1 AL1 { get; set; }
        public HL7Message.EVN EVN { get; set; }
        public HL7Message.OBR OBR { get; set; }
        public HL7Message.ORC ORC { get; set; }
        public HL7Message.PV1 PV1 { get; set; }
        public HL7Message.NTE NTE { get; set; }

        public ORU_R01() //constructor
        {
            _init();
        }
        public ORU_R01(string msg) //constructor
        {
            _init();
            Parse(msg);
        }
        private void _init() //dışardan görünmez.
        {
            PID = new HL7Message.PID();
            AL1 = new HL7Message.AL1();
            EVN = new HL7Message.EVN();
            OBR = new HL7Message.OBR();
            ORC = new HL7Message.ORC();
            PV1 = new HL7Message.PV1();
            MSH = new HL7Message.MSH();
            NTE = new HL7Message.NTE();
        }
        public void Parse(string str)
        {
            PID.Parse(str);          
            AL1.Parse(str);
            ORC.Parse(str);
            PV1.Parse(str);
            MSH.Parse(str);
            NTE.Parse(str);
            OBR.Parse(str);
        }


    }
}