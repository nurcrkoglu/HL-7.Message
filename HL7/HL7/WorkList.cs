using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HL7
{
    public class WorkList
    {
        public string Status;
        public string patname; //hasta adı
        public string patid; //tc kimlik no
        public string patotherid; // hasta kayıt no
        public string patbirthdate; //doğum tarihi
        public string patbirthtime; //doğum saati
        public string patsex; //cinsiyet
        public string pataddresse; //adres
        public string patmedicalalerts; //tıbbi uyarı
        public string patethnicgroup; //etnik grup
        public string patcontrastallergies; //kontras madde alerjisi
        public string patpregnancystatus; //hamilelik durumu
        public string pathistory; //özgeçmiş
        public string patcomments; //hasta için yorum
        public string specialneeds; //özel ihtiyaç
        public string patstate; //hastanın durumu
        public string patconfidentialconstraint; //gizlilik
        public string accessionnumber; //istek no
        public string referringpysician; //referans eden doktor
        public string requestingservice; //istek departmanı
        public string requestingphysician; //istek yapan doktor
        public string sstationaetitle;//istek yapılacak cihaz
        public string spstartdate; //işlem tarihi
        public string spstarttime; //işlem saati
        public string modatity; //işlem yapılacak cihaz---MR,CR..
        public string sperformingphysician; //işlem yapan doktor(radyolog)
        public string spstepdescription; //işlem adım açıklması
        public string spstepid; //işlem adım kodu
        public string sstationname; //istasyon adı
        public string spsteplocation; // işlem yapılacak yer
        public string premedication; // ilaç öncesi
        public string requestedcontrastagent; //konstrat madde talep
        public string requestedprocedureid; //istenen işlem kodu
        public string proceduredescription; //işlem açıklması
        public string studyinstanceuid; //çalışma örneği kodu
        public string requestedprocedurepriority; //istenen işlem önceliği
        public string patienttransportarrangements;//hasta taşıma düzenlemeleri
        public string readingphysician; //raporu okuyan doktor
        public string currentlocation; //geçerli konum
        public string resultsphysician; //sonuç doktoru
        public string procedurecomments; //işlem yorumu
        public string imagingcomments; //görüntü yorumu
        public string admissionid; //kabul no
        public string admittingdiagnosisdescription; //kabul tanısı
        public string itp_appstatus; //sonucu kontol ediyor.
      
    }
}